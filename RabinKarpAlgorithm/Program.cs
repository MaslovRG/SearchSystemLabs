using System;

namespace RabinKarpAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the text: ");
            string text = Console.ReadLine();
            Console.WriteLine("Input the pattern: "); 
            string pattern = Console.ReadLine();

            int prime = 101;

            var indexes = RKA.SearchAllMathcedIndexes(pattern, text, prime);
            Console.WriteLine("Pattern found in indexes:");
            foreach (var index in indexes)
                Console.Write($"{index} "); 
        }
    }
}
