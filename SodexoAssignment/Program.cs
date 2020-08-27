using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodexoAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            IService service = new Service(); // create Service instance
            string filesPath = Environment.CurrentDirectory;// set file root path

            string text = File.ReadAllText(filesPath + "\\SameInReverse.sdx");// get text in file

            if (!string.IsNullOrEmpty(text)) // null or empty check
            {
                string foundMaxCharacterSet = service.GetMaxCharacterSet(text); // call service method

                using (StreamWriter file = new StreamWriter(filesPath + "\\SameInReverseFound.sdx")) // create new file or open exist file
                {  
                    file.Write(foundMaxCharacterSet);// write text in file
                }
            }
        }
 }
}
