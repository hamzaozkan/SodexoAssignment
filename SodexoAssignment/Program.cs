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
            IService service = new Service();
            // set file path
            string filesPath = "C:\\Users\\Hamza\\source\\repos\\SodexoAssignment\\SodexoAssignment\\Files\\";

            // get text in file
            string text = File.ReadAllText(filesPath + "SameInReverse.sdx");

            if (!string.IsNullOrEmpty(text)) // null or empty check
            {
                string foundMaxCharacterSet = service.GetMaxCharacterSet(text); // call service method

                using (StreamWriter file = new StreamWriter(filesPath + "SameInReverseFound.sdx")) // create new file 
                {  
                    file.Write(foundMaxCharacterSet);// write text in file
                }
            }
        }
 }
}
