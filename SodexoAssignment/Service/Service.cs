using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodexoAssignment
{
    public class Service: IService
    {
        public string GetMaxCharacterSet(string text)
        {
            var found = new StringBuilder();
            var maxCharacterFound = new StringBuilder();
            int k = 1;
            for (int i = 0; i < text.Length; i++)
            {
                if (i != 0 && i != text.Length - 1)
                {
                    if (text[i + 1] == text[i]) // for example baab
                    {
                        k = 1;
                        found.Append(text[i] + "" + text[i + 1]); // set aa
                        while (text[i - k] == text[i + k + 1])
                        {
                            SetFound(text[i - k], ref found, ref k); // set baab
                        }
                        SetMaxCharacterFound(ref found, ref maxCharacterFound);

                    }

                    if (text[i + 1] == text[i - 1]) // for example bab
                    {
                        k = 1;
                        found.Append(text[i]); // set a
                        while (text[i - k] == text[i + k])
                        {
                            SetFound(text[i - k], ref found, ref k); // set bab
                        }

                        SetMaxCharacterFound(ref found, ref maxCharacterFound);
                    }

                }

            }
            return maxCharacterFound.ToString();
        }

        public void SetMaxCharacterFound(ref StringBuilder found, ref StringBuilder maxCharacterFound)
        {
            if (found.Length > maxCharacterFound.Length) // check found character set is max character set
            {
                maxCharacterFound.Clear();
                maxCharacterFound.Append(found.ToString());
            }

            found.Clear();
        }

        public void SetFound(char fChar, ref StringBuilder found, ref int k)
        {
            found.Insert(0, fChar); // ab
            found.Append(fChar); // aba
            k++;
        }
    }
}
