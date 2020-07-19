using System;
using System.Collections.Generic;
using System.Text;

namespace Victory.CodeGenerator.Facade.Interfaces
{
    /// <summary>
    /// 数据列接口
    /// </summary>
    public interface IColumn
    {
        /// <summary>
        /// 列名
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 列数据长度
        /// </summary>
        int Length { get; set; }
        /// <summary>
        /// 列精度
        /// </summary>
        int Scale { get; set; }
        /// <summary>
        /// 数据库类型【char,number...等等】
        /// </summary>
        string DbType { get; set; }
        /// <summary>
        /// 数据库类型转换为Csharp类型
        /// </summary>
        Type CsharpType { get; set; }
        /// <summary>
        /// 转换为基元类型
        /// </summary>
        string PrimativeTypeName { get; set; }
        /// <summary>
        /// 列默认值
        /// </summary>
        string DefaultValue { get; set; }
        /// <summary>
        /// 列描述
        /// </summary>
        string Comment { get; set; }
        /// <summary>
        /// 是否可空
        /// </summary>
        bool IsNullable { get; set; }
        /// <summary>
        /// 是否为数字类型
        /// </summary>
        bool IsNumeric { get; set; }
        /// <summary>
        /// 是否自动增长
        /// </summary>
        bool IsAutoIncrement { get; set; }
        /// <summary>
        /// 列所属表
        /// </summary>
        ITableSchema Table { get; set; }

        /// <summary>
        /// 驼峰命名
        /// </summary>
        string CaseCamelName { get; set; }
    }
}
