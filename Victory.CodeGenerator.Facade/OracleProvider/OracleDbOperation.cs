using SqlSugar;
using Victory.CodeGenerator.Facade.Interfaces;
using Victory.CodeGenerator.Facade.Model;
using Victory.CodeGenerator.Facade.OracleProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Victory.CodeGenerator.Facade.OracleProvider
{
    public class OracleDbOperation : IDbOperation
    {

        /// <summary>
        /// 读取外键key时是否加载外键引用表结构
        /// </summary>
        public bool ContainForeignTable { get; set; }
        public OracleDbOperation(SqlSugarClient _db) : base(_db)
        {
            ContainForeignTable = true;
        }


         

     

        

        /// <summary>
        ///  获得数据库所有表
        /// </summary>
        /// <returns></returns>
        public override DatabaseSchema GetDatabaseSchema()
        {

            DatabaseSchema db = new DatabaseSchema();
            db.Tables = new List<ITableSchema>();
            string sql = @"SELECT UO.OBJECT_NAME AS TABLE_NAME,UO.OBJECT_TYPE,UC.COMMENTS,UV.TEXT FROM USER_OBJECTS UO 
LEFT JOIN USER_TAB_COMMENTS UC ON UC.TABLE_NAME=UO.OBJECT_NAME 
LEFT JOIN USER_VIEWS UV ON UV.VIEW_NAME=UO.OBJECT_NAME
WHERE UO.OBJECT_TYPE IN ('VIEW','TABLE') ORDER BY UO.OBJECT_NAME ASC";

            var data = Db.Ado.GetDataTable(sql);

            foreach (DataRow row in data.Rows)
            {
                OracleTableSchema table = new OracleTableSchema();
                table.Name = row["TABLE_NAME"] + string.Empty;
                table.Comment = row["COMMENTS"] + string.Empty;
                db.Tables.Add(table);
            }


            return db;

        }

        /// <summary>
        /// 获取指定表字段信息
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public override DataTable GetTableData(string table_name)
        {
            string sql = "SELECT * FROM " + table_name;
            return Db.Ado.GetDataTable(sql);
        }

        /// <summary>
        /// 获取指定表信息
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public override ITableSchema GetTableSchema(string table_name)
        {
            string sql = @"SELECT UO.OBJECT_NAME AS TABLE_NAME,UO.OBJECT_TYPE,UC.COMMENTS,UV.TEXT FROM USER_OBJECTS UO 
LEFT JOIN USER_TAB_COMMENTS UC ON UC.TABLE_NAME=UO.OBJECT_NAME 
LEFT JOIN USER_VIEWS UV ON UV.VIEW_NAME=UO.OBJECT_NAME
WHERE UO.OBJECT_TYPE IN ('VIEW','TABLE') AND UO.OBJECT_NAME=:TABLE_NAME ORDER BY UO.OBJECT_NAME ASC";

            var data = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", table_name));


            string objectType = data.Rows[0]["OBJECT_TYPE"] + string.Empty;
            OracleTableSchema oracleTable = new OracleTableSchema();

            oracleTable.Name = table_name;
            oracleTable.Comment = data.Rows[0]["COMMENTS"] + string.Empty;
            oracleTable.ObjectType = objectType;
            if (objectType == "VIEW")
            {
                oracleTable.ViewScript = data.Rows[0]["TEXT"].ToString();
            }
            SetColumns(oracleTable);
            SetForeignKey(oracleTable);
            SetUniqueKey(oracleTable);
            SetPrimaryKey(oracleTable);
            return oracleTable;


        }

        private void SetColumns(OracleTableSchema oracleTable)
        {
            if (oracleTable == null)
            {
                return;
            }
            oracleTable.Columns = new List<IColumn>();
            string sql = @"SELECT TC.COLUMN_NAME,
       TC.DATA_TYPE,
       NVL(DECODE(TC.CHAR_LENGTH,0,TC.DATA_PRECISION,TC.CHAR_LENGTH),TC.DATA_LENGTH) AS DATA_LENGTH,
       TC.DATA_PRECISION,
       NVL(TC.DATA_SCALE, -1) DATA_SCALE,
       TC.NULLABLE,
       TC.DATA_DEFAULT,
       CC.COMMENTS
  FROM USER_TAB_COLUMNS TC
  LEFT JOIN USER_COL_COMMENTS CC
    ON TC.COLUMN_NAME = CC.COLUMN_NAME
   AND TC.TABLE_NAME = CC.TABLE_NAME
   WHERE TC.TABLE_NAME=:TABLE_NAME ORDER BY TC.COLUMN_ID ASC";
            List<IColumn> columns = new List<IColumn>();
         
          
            var table = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", oracleTable.Name));

            foreach (DataRow row in table.Rows)
            {
                int scale = Convert.ToInt32(row["DATA_SCALE"]);
                string data_type = row["DATA_TYPE"] + string.Empty;
                OracleColumn column = new OracleColumn();

                column.Name = row["COLUMN_NAME"].ToString();
                column.Comment = row["COMMENTS"] + string.Empty;
                column.CsharpType = OracleUtils.TransformDatabaseType(data_type, scale);
                column.DbType = data_type;
                column.DefaultValue = (row["DATA_DEFAULT"] + string.Empty).Trim('\r', '\n');
                column.IsNullable = (row["NULLABLE"].ToString().ToUpper()) == "Y";
                column.Length = Convert.ToInt32(row["DATA_LENGTH"]);
                column.Scale = scale;
                column.Table = oracleTable;
                column.IsNumeric = OracleUtils.IsNumeric(data_type);
                
                oracleTable.Columns.Add(column);
            }
        }
        private void SetForeignKey(OracleTableSchema oracleTable)
        {
            if (oracleTable == null)
            {
                return;
            }
            if (oracleTable.Columns == null || oracleTable.Columns.Count <= 0)
            {
                SetColumns(oracleTable);
            }
            string sql = @"SELECT UCC.CONSTRAINT_NAME, UCC.COLUMN_NAME,UC1.TABLE_NAME FOREIGN_TABLE_NAME
  FROM USER_CONSTRAINTS UC
  LEFT JOIN USER_CONS_COLUMNS UCC
    ON UC.CONSTRAINT_NAME = UCC.CONSTRAINT_NAME
  LEFT JOIN USER_CONSTRAINTS UC1 ON UC.R_CONSTRAINT_NAME=UC1.CONSTRAINT_NAME
 WHERE UC.CONSTRAINT_TYPE = 'R'
   AND UC.TABLE_NAME =:TABLE_NAME";




            var table = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", oracleTable.Name));

            oracleTable.ForiegnKeys = new List<Common.ForeignKey>();

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
                    var fac = new OracleDbOperation(this.Db);
                    fac.ContainForeignTable = false;
                    key.ForeignTable = fac.GetTableSchema(forignTable);
                }
                key.Columns.Add(oracleTable.Columns.Find(it => it.Name == column_name));
                oracleTable.ForiegnKeys.Add(key);
            }
        }

        private void SetUniqueKey(OracleTableSchema oracleTable)
        {
            if (oracleTable == null)
            {
                return;
            }
            if (oracleTable.Columns == null || oracleTable.Columns.Count <= 0)
            {
                SetColumns(oracleTable);
            }
            string sql = @"SELECT UCC.CONSTRAINT_NAME, UCC.COLUMN_NAME
  FROM USER_CONSTRAINTS UC
  LEFT JOIN USER_CONS_COLUMNS UCC
    ON UC.CONSTRAINT_NAME = UCC.CONSTRAINT_NAME
 WHERE UC.CONSTRAINT_TYPE = 'U'
   AND UC.TABLE_NAME =:TABLE_NAME";
          
            var table = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", oracleTable.Name));

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
                key.Columns.Add(oracleTable.Columns.Find(it => it.Name == column_name));
            }
            oracleTable.UniqueKeys = uniques;
        }


        private void SetPrimaryKey(OracleTableSchema oracleTable)
        {
            if (oracleTable == null)
            {
                return;
            }
            if (oracleTable.Columns == null || oracleTable.Columns.Count <= 0)
            {
                SetColumns(oracleTable);
            }
            string sql = @"SELECT UCC.CONSTRAINT_NAME, UCC.COLUMN_NAME
  FROM USER_CONSTRAINTS UC
  LEFT JOIN USER_CONS_COLUMNS UCC
    ON UC.CONSTRAINT_NAME = UCC.CONSTRAINT_NAME
 WHERE UC.CONSTRAINT_TYPE = 'P'
   AND UC.TABLE_NAME =:TABLE_NAME";


            var table = Db.Ado.GetDataTable(sql, new SugarParameter("TABLE_NAME", oracleTable.Name));

            Common.PrimaryKey key = new Common.PrimaryKey();
            key.Columns = new List<IColumn>();
            foreach (DataRow row in table.Rows)
            {
                string column_name = row["COLUMN_NAME"] + string.Empty;
                string constraint_name = row["CONSTRAINT_NAME"] + string.Empty;
                key.ConstraintName = constraint_name;
                key.Columns.Add(oracleTable.Columns.Find(it => it.Name == column_name));
            }
            oracleTable.PrimaryKey = key;
        }
    }
}
