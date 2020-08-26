using SqlSugar;
using Victory.CodeGenerator.Facade.Interfaces;
using Victory.CodeGenerator.Facade.Model;
using Victory.CodeGenerator.Facade.SqlServerProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Victory.CodeGenerator.Facade.SqlServerProvider
{
    public class SqlServerDbOperation : IDbOperation
    {
        /// <summary>
        /// 读取外键key时是否加载外键引用表结构
        /// </summary>
        public bool ContainForeignTable { get; set; }
        public SqlServerDbOperation(SqlSugarClient _db) : base(_db)
        {
            ContainForeignTable = true;
        }


        public override DatabaseSchema GetDatabaseSchema()
        {
            string sql = @"SELECT tbs.name ,ds.value as comments ,tbs.xtype as  OBJECT_TYPE ,null as TEXT   
FROM sysobjects tbs 
LEFT JOIN sys.extended_properties ds ON ds.major_id=tbs.id and ds.minor_id=0
where tbs.xtype in ('U','V') ";
            DatabaseSchema schema = new DatabaseSchema();


            schema.Tables = new List<ITableSchema>();
            var data = Db.Ado.GetDataTable(sql);



            foreach (DataRow row in data.Rows)
            {
                var table = new SqlServerTableSchema
                {
                    Name = row["name"] + string.Empty,
                    Comment = row["comments"] + string.Empty
                };
                schema.Tables.Add(table);
            };
            return schema;
        }

        public override DataTable GetTableData(string table_name)
        {
            string sql = "SELECT * FROM " + table_name;

            return Db.Ado.GetDataTable(sql);
        }

        public override ITableSchema GetTableSchema(string table_name)
        {
            string sql = @"SELECT tbs.name ,ds.value as comments ,tbs.xtype as  OBJECT_TYPE ,null as TEXT   
FROM sysobjects tbs 
LEFT JOIN sys.extended_properties ds ON ds.major_id=tbs.id and ds.minor_id=0
where tbs.xtype in ('U','V')  and tbs.name=@TABLE_NAME";



            var data = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", table_name));

            string objectType = data.Rows[0]["OBJECT_TYPE"] + string.Empty;
            SqlServerTableSchema SqlserverTable = new SqlServerTableSchema();
            SqlserverTable.Name = table_name;
            SqlserverTable.Comment = data.Rows[0]["COMMENTS"] + string.Empty;
            SqlserverTable.ObjectType = objectType;
            if (objectType.Trim() == "V")
            {
                SqlserverTable.ViewScript = data.Rows[0]["TEXT"].ToString();
            }

            if (objectType.Trim() == "V")
            {
                SetvViewColumns(SqlserverTable);
            }
            else
            {
                SetColumns(SqlserverTable);
                SetForeignKey(SqlserverTable);
                SetUniqueKey(SqlserverTable);
                SetPrimaryKey(SqlserverTable);
            }
          
           
            return SqlserverTable;
        }


        private void SetvViewColumns(SqlServerTableSchema SqlserverTable)
        {
            if (SqlserverTable == null)
            {
                return;
            }
            SqlserverTable.Columns = new List<IColumn>();

            string sql = @"
Select 
  c.name As COLUMN_NAME ,
  t.name As DATA_TYPE ,
  o.type As OBJECT_TYPE,
  c.length As DATA_LENGTH,
  c.isnullable as NULLABLE,
  isnull(c.scale,0) as DATA_SCALE,
  c.colid as colid
  From SysObjects As o , SysColumns As c , SysTypes As t 
  Where o.type in ('u','v')
  And o.id = c.id 
  And c.xtype = t.xtype 
  and  t.name !='sysname'
  And o.Name =@TABLE_NAME ";



            var table = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", SqlserverTable.Name));

            foreach (DataRow row in table.Rows)
            {
                int scale = Convert.ToInt32(row["DATA_SCALE"]);
                string data_type = row["DATA_TYPE"] + string.Empty;
                int len = Convert.ToInt32(row["DATA_LENGTH"]);
                var column = new SqlServerColumn
                {
                    Name = row["COLUMN_NAME"] + string.Empty,
                    CsharpType = SqlServerUtils.TransformDatabaseType(data_type, len, scale),
                    DbType = data_type,
                  
                    IsNullable = (row["NULLABLE"] + string.Empty) == "1",
                    Length = len,
                    Scale = scale,
                    Table = SqlserverTable,
                
                    IsNumeric = SqlServerUtils.IsNumeric(data_type)
                };
                SqlserverTable.Columns.Add(column);
            }
        }


        private void SetColumns(SqlServerTableSchema SqlserverTable)
        {
            if (SqlserverTable == null)
            {
                return;
            }
            SqlserverTable.Columns = new List<IColumn>();
            string sql = @"SELECT 
a.colorder COLUMN_ID,a.name COLUMN_NAME,
(case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then 1 else 0 end) AUTOINCREMENT,
(case when (SELECT count(*) FROM sysobjects
WHERE (name in (SELECT name FROM sysindexes
WHERE (id = a.id) AND (indid in
(SELECT indid FROM sysindexkeys
WHERE (id = a.id) AND (colid in
(SELECT colid FROM syscolumns WHERE (id = a.id) AND (name = a.name)))))))
AND (xtype = 'PK'))>0 then 1 else 0 end) PK,b.name DATA_TYPE,a.length BYTE_LEN,
COLUMNPROPERTY(a.id,a.name,'PRECISION') as DATA_LENGTH,
isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0) as DATA_SCALE,(case when a.isnullable=1 then 1 else 0 end) NULLABLE,
isnull(e.text,'') DATA_DEFAULT,isnull(g.[value], ' ') AS  COMMENTS
FROM syscolumns a
left join systypes b on a.xtype=b.xusertype
inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties'
left join syscomments e on a.cdefault=e.id
left join sys.extended_properties g on a.id=g.major_id AND a.colid=g.minor_id
left join sys.extended_properties f on d.id=f.class and f.minor_id=0
where b.name is not null
and d.name=@table_name 
order by a.id,a.colorder";
            List<IColumn> columns = new List<IColumn>();


            var table = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", SqlserverTable.Name));

            foreach (DataRow row in table.Rows)
            {
                int scale = Convert.ToInt32(row["DATA_SCALE"]);
                string data_type = row["DATA_TYPE"] + string.Empty;
                int len = Convert.ToInt32(row["DATA_LENGTH"]);
                var column = new SqlServerColumn
                {
                    Name = row["COLUMN_NAME"] + string.Empty,
                    Comment = row["COMMENTS"] + string.Empty,
                    CsharpType = SqlServerUtils.TransformDatabaseType(data_type, len, scale),
                    DbType = data_type,
                    DefaultValue = (row["DATA_DEFAULT"] + string.Empty).Trim('\r', '\n'),
                    IsNullable = (row["NULLABLE"] + string.Empty) == "Y",
                    Length = len,
                    Scale = scale,
                    Table = SqlserverTable,
                    IsAutoIncrement = Convert.ToInt32(row["AUTOINCREMENT"]) == 1,
                    IsNumeric = SqlServerUtils.IsNumeric(data_type)
                };
                SqlserverTable.Columns.Add(column);
            }
        }
        private void SetForeignKey(SqlServerTableSchema SqlserverTable)
        {
            if (SqlserverTable == null)
            {
                return;
            }
            if (SqlserverTable.Columns == null || SqlserverTable.Columns.Count <= 0)
            {
                SetColumns(SqlserverTable);
            }
            string sql = @"select obj.name CONSTRAINT_NAME,
main_col.name COLUMN_NAME,
sub.name FOREIGN_TABLE_NAME 
from sysforeignkeys fk left join sys.tables main on fk.fkeyid=main.object_id
left join sys.tables sub on sub.object_id=fk.rkeyid
left join syscolumns main_col on fk.fkey=main_col.colid and fk.fkeyid=main_col.id
left join sysobjects obj on obj.id=fk.constid
where main.name=@TABLE_NAME";

            var table = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", SqlserverTable.Name));

            SqlserverTable.ForiegnKeys = new List<Common.ForeignKey>();

            foreach (DataRow row in table.Rows)
            {
                string column_name = row["COLUMN_NAME"] + string.Empty;
                string constraint_name = row["CONSTRAINT_NAME"] + string.Empty;

                Common.ForeignKey key = new Common.ForeignKey();
                key.Columns = new List<IColumn>();
                key.ConstraintName = constraint_name;
                if (key.ForeignTable == null && ContainForeignTable)
                {
                    string forignTable = row["FOREIGN_TABLE_NAME"] + string.Empty;
                    
                    var fac = new SqlServerDbOperation(Db);

                    fac.ContainForeignTable = false;
                    key.ForeignTable = fac.GetTableSchema(forignTable);
                }
                key.Columns.Add(SqlserverTable.Columns.Find(it => it.Name == column_name));
                SqlserverTable.ForiegnKeys.Add(key);
            }
        }
        private void SetUniqueKey(SqlServerTableSchema SqlserverTable)
        {
            if (SqlserverTable == null)
            {
                return;
            }
            if (SqlserverTable.Columns == null || SqlserverTable.Columns.Count <= 0)
            {
                SetColumns(SqlserverTable);
            }
            string sql = @"SELECT  IDX.NAME AS CONSTRAINT_NAME,  COL.NAME AS COLUMN_NAME
FROM      SYS.INDEXES IDX JOIN
                SYS.INDEX_COLUMNS IDXCOL ON (IDX.OBJECT_ID = IDXCOL.OBJECT_ID AND IDX.INDEX_ID = IDXCOL.INDEX_ID AND
                IDX.IS_UNIQUE_CONSTRAINT = 1) JOIN
                SYS.TABLES TAB ON (IDX.OBJECT_ID = TAB.OBJECT_ID) JOIN
                SYS.COLUMNS COL ON (IDX.OBJECT_ID = COL.OBJECT_ID AND IDXCOL.COLUMN_ID = COL.COLUMN_ID) where tab.name=@TABLE_NAME";

            var table = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", SqlserverTable.Name));

            List<Common.UniqueKey> uniques = new List<Common.UniqueKey>();

            foreach (DataRow row in table.Rows)
            {
                string column_name = row["COLUMN_NAME"] + string.Empty;
                string constraint_name = row["CONSTRAINT_NAME"] + string.Empty;
                Common.UniqueKey key = uniques.Find(it => it.ConstraintName == constraint_name);
                if (key == null)
                {
                    key = new Common.UniqueKey();
                    key.Columns = new List<IColumn>();
                    key.ConstraintName = constraint_name;
                    uniques.Add(key);
                }
                key.Columns.Add(SqlserverTable.Columns.Find(it => it.Name == column_name));
            }
            SqlserverTable.UniqueKeys = uniques;
        }
        private void SetPrimaryKey(SqlServerTableSchema SqlserverTable)
        {
            if (SqlserverTable == null)
            {
                return;
            }
            if (SqlserverTable.Columns == null || SqlserverTable.Columns.Count <= 0)
            {
                SetColumns(SqlserverTable);
            }
            string sql = @"SELECT    IDX.NAME AS CONSTRAINT_NAME,
                 COL.NAME AS COLUMN_NAME
FROM SYS.INDEXES IDX JOIN
                SYS.INDEX_COLUMNS IDXCOL ON (IDX.OBJECT_ID = IDXCOL.OBJECT_ID AND IDX.INDEX_ID = IDXCOL.INDEX_ID AND
                IDX.IS_PRIMARY_KEY = 1) JOIN
                SYS.TABLES TAB ON (IDX.OBJECT_ID = TAB.OBJECT_ID) JOIN
                SYS.COLUMNS COL ON (IDX.OBJECT_ID = COL.OBJECT_ID AND IDXCOL.COLUMN_ID = COL.COLUMN_ID) where tab.name=@TABLE_NAME";

            var table = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", SqlserverTable.Name));

            Common.PrimaryKey key = new Common.PrimaryKey();
            key.Columns = new List<IColumn>();
            foreach (DataRow row in table.Rows)
            {
                string column_name = row["COLUMN_NAME"] + string.Empty;
                string constraint_name = row["CONSTRAINT_NAME"] + string.Empty;
                key.ConstraintName = constraint_name;
                key.Columns.Add(SqlserverTable.Columns.Find(it => it.Name == column_name));
            }
            SqlserverTable.PrimaryKey = key;
        }
    }
}
