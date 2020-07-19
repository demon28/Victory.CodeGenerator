using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Victory.CodeGenerator.Facade
{
   public  class ChartCase
    {



        public static String convertToCamelCase(string name)
        {
            string[] array = name.Split('_');

          StringBuilder sb =new  StringBuilder();

            foreach (var item in array)
            {

                string first = item.Substring(0, 1);
                string orther = item.Substring(1, item.Length-1);

                var word= first.ToUpper() + orther.ToLower();

                word += "_";

                sb.Append(word);
            }

            var newword = sb.ToString();
            newword = newword.Substring(0, newword.LastIndexOf('_'));

            return newword;

        }





    }
}
