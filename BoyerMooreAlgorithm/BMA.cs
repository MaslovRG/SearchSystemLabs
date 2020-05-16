using System;
using System.Collections.Generic;
using System.Text;

namespace BoyerMooreAlgorithm
{
    public class BMA
    {
        public readonly static int alphabetPower = 256;

        static public int SearchMathcedIndex(string pattern, string text)
        {
            int textLength, patternLength;

            textLength = text.Length;
            patternLength = pattern.Length;

            int i, position;
            int[] table = new int[alphabetPower];
            for (i = 0; i < alphabetPower; i++)
            {
                table[i] = patternLength;
            }

            for (i = patternLength - 1; i >= 0; i--)
            {
                if (table[pattern[i]] == patternLength)
                {
                    table[pattern[i]] = patternLength - i - 1;
                }
            }

            position = patternLength - 1;
            while (position < textLength)
            {
                if (pattern[patternLength - 1] != text[position])
                {
                    position += table[text[position]];
                }
                else
                {
                    for (i = patternLength - 2; i >= 0; i--)
                    {
                        if (pattern[i] != text[position - patternLength + i + 1])
                        {
                            position += table[text[position - patternLength + i + 1]] - 1;
                            break;
                        }
                        else if (i == 0)
                        {
                            return position - patternLength + 1;
                        }
                    }
                }
            }
            return -1;
        }
    }
}
