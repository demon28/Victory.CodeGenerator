
using Victory.CodeGenerator.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.CodeGenerator.Facade
{
    public abstract class ConstraintKeyBase
    {
        public List<IColumn> Columns { get; set; }
        public string ConstraintName { get; set; }
    }
}
