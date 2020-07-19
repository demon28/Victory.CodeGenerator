using SqlSugar;
using Victory.CodeGenerator.Facade.Interfaces;
using Victory.CodeGenerator.Facade.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Victory.CodeGenerator.Facade;

namespace Victory.CodeGenerator.SQLiteProvider
{
    public class SQLiteDbOperation : IDbOperation
    {
        public bool ContainForeignTable { get; set; }
        public SQLiteDbOperation(SqlSugarClient _db) : base(_db)
        {
            ContainForeignTable = true;
        }

       

        public override DatabaseSchema GetDatabaseSchema()
        {
            throw new NotImplementedException();
        }

        public override DataTable GetTableData(string table_name)
        {
            throw new NotImplementedException();
        }

        public override ITableSchema GetTableSchema(string table_name)
        {
            throw new NotImplementedException();
        }
    }
}
