

![img](https://img2020.cnblogs.com/blog/161176/202007/161176-20200717213331969-1091439631.png)


### 数据库支持

<table>
    <tr><td>数据库</td><td>是否支持</td></tr>
    <tr><td>Oracle</td><td>支持</td></tr>
     <tr><td>Sqlserver</td><td>支持</td></tr>
     <tr><td>MySql</td><td>支持</td></tr>
     <tr><td>Sqlite</td><td>暂不支持</td></tr>
 </table>    


### 怎么写模板

所有的代码生成器，一个基本的原则都是 **关键字替换**， 但是有了引擎的加持，我们就可以 使用 编程语言，比如 for，if 这些。

我贴一个最简单 的model 实体生成 的模板代码：

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

```
using System;
using System.Linq;
using System.Text;
using SqlSugar;


namespace @ViewBag.NameSpace
{
    /// <summary>
    ///  @Model.Comment
    ///</summary>
    public class   @Model.Name
    {

       public @(Model.Name)()
       {
      
       }

    @foreach (var item in @Model.Columns)
    {
        @:///<summary>
        @:///描述：@(item.Comment)
        @:///</summary>
        @:public @item.PrimativeTypeName @item.CaseCamelName { get; set; }
 
      }

    }
 }
```

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

 

简单的说一下，这里面的替换的内容都是哪来的，比如： 

```
@ViewBag.NameSpace

viewBag,就不多说了，熟悉asp.net mvc 的朋友都知道，一般在控制写写ViewBig ，前端就可以获取的到，这里也一样 
ViewBag ,是我在执行代码生成 之前加的：
```

![img](https://img2020.cnblogs.com/blog/161176/202007/161176-20200717214825152-1863895973.png)

 

 

上面看到，我在viewbag里面 还加了一个时间，不过我模板里面没有用到，一般有些人会加自己的 名字，联系方式什么的，

都可以通过viewbag 去加。

 

至于其他的内容则来自数据库，比如字段信息，表名，主外键，等等。。

大体来说分成两个部分，一个是表信息，一个是字段信息, 如下：

 

这是表信息：

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

```
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
```

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

 

 

 

 我们就可以在模板里面取这些信息，比如： 

```
 @Model.Name   表名
 @Model.Comment  表备注

其他的以此类推，至于为什么是Model点出来的，因为是把整个对象扔进去了，对象在Razor里面就是Model这个变量。


字段信息，就很好理解了，就在  List<IColumn> Columns { get; set; }  里面，遍历它就可以了
```

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

```
using System;
using System.Collections.Generic;
using System.Text;

namespace SugarWinner.CodeGenerator.Facade.Interfaces
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
```

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

 

关于一些代码生成器Oracle 全大写，生成出来的字段就全大写了，所以我这里特地加了驼峰命名法，解决了Oracle 数据库的问题。

### 特别鸣谢：Jason
