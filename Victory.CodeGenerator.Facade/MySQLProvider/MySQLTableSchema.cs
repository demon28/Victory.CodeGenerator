using Victory.CodeGenerator.Facade.Common;
using Victory.CodeGenerator.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Victory.CodeGenerator.Facade.MySQLProvider
{
    public class MySQLTableSchema : ITableSchema
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public List<IColumn> Columns { get; set; }
        public List<ForeignKey> ForiegnKeys { get; set; }
        public PrimaryKey PrimaryKey { get; set; }
        public List<UniqueKey> UniqueKeys { get; set; }
        public string ObjectType { get; set; }
        public string ViewScript { get; set; }
    }
}
