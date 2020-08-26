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

            if (!string.IsNullOrEmpty(text))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filesPath + "SameInReverseFound.sdx"))
                {
                    // write text in file
                    file.Write(GetMaxCharacterSetReverse(text));
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
                    if (text[i + 1] == text[i])
                    {
                        k = 1;
                        found.Append(text[i] + "" + text[i + 1]);
                        while (text[i - k] == text[i + k + 1])
                        {


                            found.Insert(0, text[i - k]);
                            found.Append(text[i + k + 1]);
                            k++;
                        }
                        if (found.Length > maxCharacterFound.Length)
                        {
                            maxCharacterFound.Clear();
                            maxCharacterFound.Append(found.ToString());
                        }
                        found.Clear();

                    }

                    if (text[i + 1] == text[i - 1])
                    {
                        k = 1;
                        found.Append(text[i]);
                        while (text[i - k] == text[i + k])
                        {
                            found.Insert(0, text[i - k]);
                            found.Append(text[i + k]);
                            k++;
                        }
                        if (found.Length > maxCharacterFound.Length)
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
