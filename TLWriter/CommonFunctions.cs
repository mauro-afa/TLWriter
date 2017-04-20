using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLWriter
{
    class CommonFunctions
    {
        public string[] translateStep(string Exec_type, string importance)
        {
            string[] result = new string[2];

            switch(Exec_type)
            {
                case "Manual":
                    result[0] ="1";
                    break;
                case "Automated":
                    result[0] = "2";
                    break;
                case "1":
                    result[0] = "Manual";
                    break;
                case "2":
                    result[0] = "Automated";
                    break;   
            }
              switch(importance)
            {
                case "Low":
                    result[1] = "1";
                    break;
                case "Medium":
                    result[1] = "2";
                    break;
                case "High":
                    result[1] = "3";
                    break;
                case "1":
                    result[1] = "Low";
                    break;
                case "2":
                    result[1] = "Medium";
                    break;
                case "3":
                    result[1] = "High";
                    break;
            }
            return result;
        }
    }
}
