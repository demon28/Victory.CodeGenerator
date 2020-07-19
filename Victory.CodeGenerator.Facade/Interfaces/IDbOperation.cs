using SqlSugar;
using Victory.CodeGenerator.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Victory.CodeGenerator.Facade
{
    public abstract class IDbOperation
    {
       public SqlSugarClient Db { get; set; }


        public IDbOperation(SqlSugarClient _db)
        {

            this.Db = _db;

        }

      

        public abstract DatabaseSchema GetDatabaseSchema();
        public abstract ITableSchema GetTableSchema(string table_name);
  
        public abstract  DataTable GetTableData(string table_name);


    }
}
