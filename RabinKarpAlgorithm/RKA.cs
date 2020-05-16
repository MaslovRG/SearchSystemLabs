using System;
using System.Collections.Generic;
using System.Text;

namespace RabinKarpAlgorithm
{
    public class RKA
    {
        public readonly static int alphabetPower = 256;

        static public List<int> SearchAllMathcedIndexes(string pattern, string text, int prime)
        {
            List<int> indexes = new List<int>();
            int i, j;

            int hashForPattern = 0; 
            int hashForText = 0;
            int h = 1;

            for (i = 0; i < pattern.Length - 1; i++)
                h = (h * alphabetPower) % prime;

            for (i = 0; i < pattern.Length; i++)
            {
                hashForPattern = (alphabetPower * hashForPattern + pattern[i]) % prime;
                hashForText = (alphabetPower * hashForText + text[i]) % prime;
            }

            for (i = 0; i <= text.Length - pattern.Length; i++)
            {
                if (hashForPattern == hashForText)
                {
                    for (j = 0; j < pattern.Length; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }

                    if (j == pattern.Length)
                        indexes.Add(i); 
                }

                if (i < text.Length - pattern.Length)
                {
                    hashForText = (alphabetPower * (hashForText - text[i] * h) + text[i + pattern.Length]) % prime;

                    if (hashForText < 0)
                        hashForText = (hashForText + prime);
                }
            }

            return indexes; 
        }
    }
}
