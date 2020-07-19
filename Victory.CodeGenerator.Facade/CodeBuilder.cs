using SqlSugar;
using Victory.CodeGenerator.Facade.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RazorEngine;
using Victory.CodeGenerator.Facade.Interfaces;
using RazorEngine.Templating;
using System.Runtime.CompilerServices;

namespace Victory.CodeGenerator.Facade
{
    public class CodeBuilder
    {

        public List<string> Tables { get; set; }
        public string NameSpace { get; set; }
        public string Conn { get; set; }

        public Enums.DbTypes DbType { get; set; }

        public string TempPath { get; set; }

        public string SavePath { get; set; }

        public string MyFilename { get; set; }

        public CodeBuilder(List<string> _tables, string _namespace, string _conn, Enums.DbTypes _dbType, string _temppath, string _savepath, string _myfilename)
        {

            Tables = _tables;
            NameSpace = _namespace;
            Conn = _conn;
            DbType = _dbType;
            TempPath = _temppath;
            SavePath = _savepath;
            MyFilename = _myfilename;

        }



        public bool Build()
        {
            try
            {
                var Db = DbFactory.DbOperation(this.DbType, this.Conn);

                var Template = File.ReadAllText(this.TempPath, System.Text.Encoding.Default);

                var TempName = Path.GetFileNameWithoutExtension(TempPath);

           


                foreach (var item in Tables)
                {
                    var table = Db.GetTableSchema(item);

                    DynamicViewBag viewBag = new DynamicViewBag();
                    viewBag.AddValue("NameSpace", NameSpace);
                    viewBag.AddValue("Date", DateTime.Now.ToString("yyyy-MM-dd"));



                    string content = Engine.Razor.RunCompile(Template, TempName, typeof(ITableSchema), table, viewBag);

                    string filename = ChartCase.convertToCamelCase(item) + "." + TempName + ".cs";

                    if (!string.IsNullOrEmpty(MyFilename))
                    {
                        filename = MyFilename;
                    }


                    string fullpath = SavePath + "\\" + filename;

                    if (File.Exists(fullpath))
                    {
                        File.Delete(fullpath);
                    }

                    File.WriteAllText(fullpath, content);


                }

                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return false;
            }
        }

        public string PerView()
        {
            try
            {
                var Db = DbFactory.DbOperation(this.DbType, this.Conn);

                var Template = File.ReadAllText(this.TempPath, System.Text.Encoding.Default);

                var TempName = Path.GetFileNameWithoutExtension(TempPath);


                var table = Db.GetTableSchema(Tables[0]);

                DynamicViewBag viewBag = new DynamicViewBag();
                viewBag.AddValue("NameSpace", NameSpace);


                string content = Engine.Razor.RunCompile(Template, TempName, typeof(ITableSchema), table, viewBag);

                return content;

            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return "";
            }
        }
    }
}
