using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodexoAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string filesPath = "C:\\Users\\Hamza\\source\\repos\\SodexoAssignment\\SodexoAssignment\\Files\\";

            // get text in file
            string text = System.IO.File.ReadAllText(filesPath + "SameInReverse.sdx");

            if (!string.IsNullOrEmpty(text)) // null or empty check
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filesPath + "SameInReverseFound.sdx")) // create new file 
                {
                    // write text in file
                    string foundMaxCharacterSet = GetMaxCharacterSetReverse(text);
                    file.Write(foundMaxCharacterSet);
                }
            }
        }

       static string GetMaxCharacterSetReverse(string text)
        {

            var found = new StringBuilder();
            var maxCharacterFound = new StringBuilder();
            int k = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (i != 0 && i != text.Length - 1)
                {
                    if (text[i + 1] == text[i]) // for example aa
                    {
                        k = 1;
                        found.Append(text[i] + "" + text[i + 1]);
                        while (text[i - k] == text[i + k + 1])
                        {


                            found.Insert(0, text[i - k]);
                            found.Append(text[i + k + 1]);
                            k++;
                        }
                        if (found.Length > maxCharacterFound.Length) // check found character set is max character set
                        {
                            maxCharacterFound.Clear();
                            maxCharacterFound.Append(found.ToString());
                        }
                        found.Clear();

                    }

                    if (text[i + 1] == text[i - 1]) // for example aba
                    {
                        k = 1;
                        found.Append(text[i]);
                        while (text[i - k] == text[i + k])
                        {
                            found.Insert(0, text[i - k]);
                            found.Append(text[i + k]);
                            k++;
                        }

                        if (found.Length > maxCharacterFound.Length) // check found character set is max character set
                        {
                            maxCharacterFound.Clear();
                            maxCharacterFound.Append(found.ToString());
                        }

                        found.Clear();
                    }


                }

            }
            return maxCharacterFound.ToString();
        }
    }
}
