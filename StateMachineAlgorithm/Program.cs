﻿using System;

namespace StateMachineAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the text: ");
            string text = Console.ReadLine();
            Console.WriteLine("Input the pattern: ");
            string pattern = Console.ReadLine();

            var indexes = SMA.SearchAllMathcedIndexes(pattern, text);
            Console.WriteLine("Pattern found in indexes:");
            foreach (var index in indexes)
                Console.Write($"{index} ");
        }
    }
}
