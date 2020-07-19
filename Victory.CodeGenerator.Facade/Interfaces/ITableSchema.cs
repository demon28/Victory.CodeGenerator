using Victory.CodeGenerator.Facade.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Victory.CodeGenerator.Facade.Interfaces
{
 
        public interface ITableSchema
        {
        /// <summary>
        /// 表名
        /// </summary>
            string Name { get; set; }
        /// <summary>
        /// 表备注
        /// </summary>
            string Comment { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
            List<IColumn> Columns { get; set; }
        /// <summary>
        /// 外键集合
        /// </summary>
            List<ForeignKey> ForiegnKeys { get; set; }
        /// <summary>
        /// 唯一键集合
        /// </summary>
            List<UniqueKey> UniqueKeys { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
            PrimaryKey PrimaryKey { get; set; }
            /// <summary>
            /// 对象类型，TABLE or VIEW
            /// </summary>
            string ObjectType { get; set; }
            /// <summary>
            /// 视图脚本
            /// </summary>
            string ViewScript { get; set; }
        }
    
}
