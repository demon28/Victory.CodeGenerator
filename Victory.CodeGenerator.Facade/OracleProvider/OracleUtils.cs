using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.CodeGenerator.Facade.OracleProvider
{
    public class OracleUtils
    {
        public static Type TransformDatabaseType(string dbtype, int scale)
        {
            Type csharpType = null;
            switch (dbtype.ToUpper())
            {
                case "DECIMAL":
                case "INTEGER":
                case "FLOAT":
                case "REAL":
                case "NUMBER":
                    if (scale != 0)
                        csharpType = typeof(decimal);
                    else
                        csharpType = typeof(int);
                    break;
                case "NVARCHAR":
                case "VARCHAR":
                case "CHAR":
                case "NVARCHAR2":
                case "VARCHAR2":
                case "NCHAR":
                case "CLOB":
                case "NCLOB":
                case "LONG":
                    csharpType = typeof(string); break;
                case "DATE":
                    csharpType = typeof(DateTime); break;
                case "BLOB":
                case "RAW":
                case "LONG RAW":
                case "BFILE":
                default:
                    csharpType = typeof(object); break;
            }
            return csharpType;
        }

        public static bool IsNumeric(string dbtype)
        {
            string[] numericTypes = new string[] { "DECIMAL", "INTEGER", "FLOAT", "REAL", "NUMBER" };
            return numericTypes.Contains(dbtype.ToUpper());
        }
    }
}
