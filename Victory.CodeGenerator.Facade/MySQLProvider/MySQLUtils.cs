using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Victory.CodeGenerator.Facade.MySQLProvider
{
    class MySQLUtils
    {

        public static Type TransformDatabaseType(string dbtype, int scale)
        {
            Type csharpType = null;
            switch (dbtype.ToUpper())
            {
                case "DECIMAL":
                case "FLOAT":
                case "DOUBLE":
                case "REAL":
                case "NUMBER":
                case "NUMERIC":
                case "INT":
                case "INTEGER":
                case "SMALLINT":
                case "TINYINT":
                case "MEDIUMINT":
                    if (scale != 0)
                        csharpType = typeof(decimal);
                    else
                        csharpType = typeof(int);
                    break;
                case "BIGINT":
                    csharpType = typeof(long);
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
                case "TEXT":
                case "TINYTEXT":
                case "MEDIUMTEXT":
                case "BIGTEXT":
                    csharpType = typeof(string); break;
                case "DATE":
                case "DATETIME":
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
            string[] numericTypes = new string[] { "DECIMAL", "INTEGER", "FLOAT", "REAL", "NUMBER", "INT" };
            return numericTypes.Contains(dbtype.ToUpper());
        }
    }
}
