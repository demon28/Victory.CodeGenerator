using Victory.CodeGenerator.Facade.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Victory.CodeGenerator.Facade
{
  public static  class BuilderConnString
    {



        public static string ConnString(Facade.Enums.DbTypes dbTypes, OperationModel model)
        {

            switch (dbTypes)
            {
                case Enums.DbTypes.Oracle:
                    return OracleConnString(model);
                case Enums.DbTypes.SqlServer:
                    return SqlServerConnString(model);
                case Enums.DbTypes.MySQL:
                    return MySQLConnString(model);
                case Enums.DbTypes.SQLite:
                    return SqliteString(model);
                default:
                    return OracleConnString(model);
            }
        



        }


        private static string SqliteString(OperationModel model)
        {

            string str = string.Format("Data Source={0};Version=3;Password={1};",
              model.ip,
                  model.pwd
              );

            return str;
        }

        private static string OracleConnString(OperationModel model)
        {
            string str = string.Format("Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST ={0})(PORT = 1521))" +
                  "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME ={1})));Persist Security Info=True;User ID={2};Password={3}",
                  model.ip,
                  model.instance,
                  model.account,
                  model.pwd
                  );

            return str;
        }

        private static string SqlServerConnString(OperationModel model)
        {
            string str = string.Format("Data Source={0};Initial Catalog={1}; User Id={2};Password={3}",

                   model.ip,
                 model.instance,
                 model.account,
                 model.pwd

                );
            return str;
        }

        private  static string MySQLConnString(OperationModel model)
        {
            string str = string.Format("server={0};database={1};user={2};pwd={3}",
                model.ip,
                model.instance,
                model.account,
                model.pwd
                );

            return str;
        }


    }
}
