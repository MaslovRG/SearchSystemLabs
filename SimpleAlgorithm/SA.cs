using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAlgorithm
{
    public class SA
    {
        static public List<int> SearchAllMathcedIndexes(string pattern, string text)
        {
            List<int> indexes = new List<int>();
            
            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                bool isEq = true; 
                for (int j = 0; j < pattern.Length && isEq; j++)
                {
                    isEq = (pattern[j] == text[i + j]); 
                }
                if (isEq)
                    indexes.Add(i); 
            }

            return indexes;
        }
    }
}
