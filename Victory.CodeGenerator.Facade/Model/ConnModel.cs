using System;
using System.Collections.Generic;
using System.Text;

namespace Victory.CodeGenerator.Facade.Model
{

    public class JsonModel {


        public List<ConnectionString> ConnectionString { get; set; }

        public string FilePath { get; set; }
        public string NameSpace { get; set; }


    }


  public   class ConnectionString
    {

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        public string type { get; set; }
        public string conn { get; set; }

    }
}
