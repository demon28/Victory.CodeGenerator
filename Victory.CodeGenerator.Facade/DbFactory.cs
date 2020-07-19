
using System;
using System.Collections.Generic;
using System.Text;
using Victory.CodeGenerator.Facade.MySQLProvider;
using Victory.CodeGenerator.Facade.OracleProvider;
using Victory.CodeGenerator.Facade.SqlServerProvider;
using Victory.CodeGenerator.SQLiteProvider;

namespace Victory.CodeGenerator.Facade
{
    public  class DbFactory
    {

        public static IDbOperation DbOperation(Facade.Enums.DbTypes type,string conn)
        {

           var db=  DbHelper.Db(conn, type);

            switch (type)
            {
                case Enums.DbTypes.Oracle:
                    return new  OracleDbOperation(db);

                case Enums.DbTypes.SqlServer:
                    return new SqlServerDbOperation(db);

                case Enums.DbTypes.MySQL:
                    return new MySQLDbOperation(db);

                case Enums.DbTypes.SQLite:
                    return new SQLiteDbOperation(db);

                default:
                         return new  OracleDbOperation(db);
             
            }


        }


    }
}
