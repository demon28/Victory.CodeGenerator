using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Victory.CodeGenerator.Facade.SqlServerProvider
{
    public class SqlServerUtils
    {
        public static Type TransformDatabaseType(string dbtype, int len, int scale)
        {
            Type csharpType;
            switch (dbtype.ToUpper())
            {
                case "DECIMAL":
                case "INTEGER":
                case "FLOAT":
                case "REAL":
                case "NUMBER":
                case "INT":
                case "TINYINT":
                case "SMALLINT":
                case "BYTE":
                case "MONEY":
                    if (scale != 0)
                        csharpType = typeof(decimal);
                    else
                        csharpType = len <= 10 ? typeof(int) : typeof(long);
                    break;
                case "BIGINT":
                    csharpType = typeof(long);
                    break;
                case "BIT":
                    csharpType = typeof(bool);
                    break;
                case "UNIQUEIDENTIFIER":
                    csharpType = typeof(Guid);
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
                case "NTEXT":
                    csharpType = typeof(string); break;
                case "DATE":
                case "DATETIME":
                case "DATETIME2":
                case "SMALLDATETIME":
                case "TIME":
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
            string[] numericTypes = new string[] { "DECIMAL", "INTEGER", "FLOAT", "REAL", "NUMBER", "INT", "BIGINT", "SMALLINT", "TINYINT" };
            return numericTypes.Contains(dbtype.ToUpper());
        }
    }
}
