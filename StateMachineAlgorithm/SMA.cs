using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachineAlgorithm
{
    public class SMA
    {
        public char[,] Table;

        //public readonly static string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789";
        private readonly static int alphabetPower = 256; 

        static public List<int> SearchAllMathcedIndexes(string pattern, string text)
        {
            List<int> indexes = new List<int>();

            var n = text.Length;
            var state = 0;
            var delta = ComputeTransitionFunction(pattern);
            for (int i = 0; i < n; i++)
            {                
                state = delta[state, text[i]];

                if (state == pattern.Length)
                {
                    indexes.Add(i - pattern.Length + 1);
                }                     
            }

            return indexes; 
        }

        static private int[,] ComputeTransitionFunction(string pattern)
        {
            int[,] delta = new int[pattern.Length + 1, alphabetPower];           

            for (int state = 0; state <= pattern.Length; state++)
            {
                for (int x = 0; x < alphabetPower; x++)
                {                    
                    delta[state, x] = GetNextState(pattern, state, x); 
                }
            }
            return delta; 
        }

        static private int GetNextState(string pattern, int state, int x)
        {
            if (state < pattern.Length && x == pattern[state])
                return state + 1;

            int nextState, i; 
            for (nextState = state; nextState > 0; nextState--)
            {
                if (pattern[nextState - 1] == x)
                {
                    for (i = 0; i < nextState - 1; i++)
                    {
                        if (pattern[i] != pattern[state - nextState + 1 + i])
                        {
                            break;
                        }
                    }
                    if (i == nextState - 1)
                    {
                        return nextState;
                    }
                }
            }

            return 0;
        }
    }
}
