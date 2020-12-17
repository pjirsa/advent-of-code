using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var results = ReadInputFile("input1.txt");

            Console.WriteLine($"Found {results.Count()} results");
          
            var product = FindPairs(results);
            Console.WriteLine(product);

            var trioproduct = FindTrio(results, 2020);
            Console.WriteLine(trioproduct);
        }

        private static int[] ReadInputFile(string filename)
        {
            var fileContents = File.ReadAllLines(filename);

            return fileContents.Select(s => Int32.Parse(s)).ToArray();
        }

        private static int FindPairs(int[] values)
        {
            values = values.OrderBy(s => s).ToArray();

            for (int i = 0; i < values.Length / 2; i++)
            {
                for (int j = values.Length - 1; j >=0; j--)
                {
                    int sum = values[i] + values[j];
                    
                    if (sum == 2020)
                    {
                        Console.WriteLine($"{values[i]} + {values[j]} = {sum}");
                        return values[i] * values[j];
                    }
                }
            }
            
            return 0;
        }

        private static int FindTrio(int[] values, int searchValue)
        {
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 1; j < values.Length; j++)
                {
                    for (int k = 2; k < values.Length; k++)
                    {
                        int sum = values[i] + values[j] + values[k];
                        if (sum == searchValue)
                        {
                            Console.WriteLine($"{values[i]} + {values[j]} + {values[k]} = {sum}");
                            return values[i] * values[j] * values[k];
                        }
                    }
                }
            }

            return 0;
        }
    }
}
