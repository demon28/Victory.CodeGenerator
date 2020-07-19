using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.CodeGenerator.Facade
{
    public static class ExtendFunctions
    {
        public static string GetString(this DataRow row, string columnName)
        {
            object b = row[columnName];
            if (b == DBNull.Value || b == null)
            {
                return string.Empty;
            }
            return b.ToString();
        }
        public static int GetInt(this DataRow row, string columnName)
        {
            object b = row[columnName];
            if (b == DBNull.Value || b == null)
            {
                return 0;
            }
            return Convert.ToInt32(b);
        }
        public static decimal GetDecimal(this DataRow row, string columnName)
        {
            object ob = row[columnName];
            if (ob == null || ob == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(ob);
        }

        public static event Action<int> Progress;

        public static void OnProcess(int v)
        {
            Progress?.Invoke(v);
        }
    }
}
