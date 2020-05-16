using System;

namespace BoyerMooreAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the text: ");
            string text = Console.ReadLine();
            Console.WriteLine("Input the pattern: ");
            string pattern = Console.ReadLine();

            var index = BMA.SearchMathcedIndex(pattern, text);
            Console.WriteLine($"Pattern found in index: {index}");
        }
    }
}
