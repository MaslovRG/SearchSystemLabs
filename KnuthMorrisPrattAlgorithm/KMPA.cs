using System;
using System.Collections.Generic;
using System.Text;

namespace KnuthMorrisPrattAlgorithm
{
    public class KMPA
    {
        public readonly static int alphabetPower = 256;

        static public List<int> SearchAllMathcedIndexes(string pattern, string text)
        {
            List<int> indexes = new List<int>();

            int[] lps = new int[pattern.Length];
            ComputeLPSArray(pattern, lps);

            int i = 0, j = 0;
            while (i < text.Length)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == pattern.Length)
                {
                    indexes.Add(i - j);
                    j = lps[j - 1];
                }
                else if (i < text.Length && pattern[j] != text[i])
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i += 1;
                }
            }

            return indexes;
        }

        static void ComputeLPSArray(string pattern, int[] lps)
        {
            int len = 0;
            int i = 1;
            lps[0] = 0; // lps[0] всегда 0 

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                { 
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }
    }
}
