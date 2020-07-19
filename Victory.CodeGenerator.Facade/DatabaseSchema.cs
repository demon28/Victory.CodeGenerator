
using Victory.CodeGenerator.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.CodeGenerator.Facade
{
    public class DatabaseSchema
    {
        public List<ITableSchema> Tables { get; set; }
    }
}
