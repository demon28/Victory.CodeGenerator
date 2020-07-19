using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Victory.CodeGenerator.Facade
{
   public static class DbHelper
    {

        public static SqlSugarClient Db(string conn,Facade.Enums.DbTypes _dbType)
        {


            var dbType = ConvertDbType(_dbType);

            SqlSugarClient db=   new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = conn,
                DbType = dbType,

                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });

            return db;
        }

        public static SqlSugar.DbType ConvertDbType(Facade.Enums.DbTypes _dbType)
        {


            switch (_dbType)
            {
                case Enums.DbTypes.Oracle:
                    return SqlSugar.DbType.Oracle;
                   
                case Enums.DbTypes.SqlServer:
                    return SqlSugar.DbType.SqlServer; 
                case Enums.DbTypes.MySQL:
                    return SqlSugar.DbType.MySql; 
                case Enums.DbTypes.SQLite:
                    return SqlSugar.DbType.Sqlite;
                default:
                    return SqlSugar.DbType.Oracle;
            }

        }



    }
}
