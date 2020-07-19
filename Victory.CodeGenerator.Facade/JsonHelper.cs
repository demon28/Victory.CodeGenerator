using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Victory.CodeGenerator.Facade.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace Victory.CodeGenerator.Facade
{
   public  class JsonHelper
    {
        public static string FilePath = AppDomain.CurrentDomain.BaseDirectory + "/AppSetting.json";


        public  JsonModel Read()
        {

            try
            {

                string josnString = File.ReadAllText(FilePath, Encoding.Default);
             
                return JsonConvert.DeserializeObject<JsonModel>(josnString); ;
            }
            catch (Exception e)
            {
               
                throw;
            }
        }


        public  bool Add(ConnectionString model) {

            try
            {
                string josnString = File.ReadAllText(FilePath, Encoding.Default);
                JsonModel json = new JsonModel();
                json = JsonConvert.DeserializeObject<JsonModel>(josnString);



                json.ConnectionString.Add(model);

                string output = JsonConvert.SerializeObject(json, Formatting.Indented);
                File.WriteAllText(FilePath, output);
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public  bool Del(string name)
        {

            try
            {
                string josnString = File.ReadAllText(FilePath, Encoding.Default);
                JsonModel json = new JsonModel();
                json = JsonConvert.DeserializeObject<JsonModel>(josnString);


                if (json.ConnectionString.Count<=0)
                {
                    return false;
                }

                var conns = json.ConnectionString;


                for (int i = 0; i < conns.Count(); i++)
                {
                    if (json.ConnectionString[i].name == name)
                    {
                        json.ConnectionString.Remove(json.ConnectionString[i]);
                    }
                }

                string output = JsonConvert.SerializeObject(json, Formatting.Indented);
                File.WriteAllText(FilePath, output);

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }


        public  bool SetPath(string path)
        {

            try
            {
                string josnString = File.ReadAllText(FilePath, Encoding.Default);
                JsonModel json = new JsonModel();
                json = JsonConvert.DeserializeObject<JsonModel>(josnString);

                json.FilePath = path;

                string output = JsonConvert.SerializeObject(json, Formatting.Indented);
                File.WriteAllText(FilePath, output);

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public  bool SetSpace(string space)
        {

            try
            {
                string josnString = File.ReadAllText(FilePath, Encoding.Default);
                JsonModel json = new JsonModel();
                json = JsonConvert.DeserializeObject<JsonModel>(josnString);

                json.NameSpace = space;

                string output = JsonConvert.SerializeObject(json, Formatting.Indented);
                File.WriteAllText(FilePath, output);


                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }




    }
}
