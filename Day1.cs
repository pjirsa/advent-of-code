using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code
{
    public class Day1
    {
        public void Run(IEnumerable<string> input)
        {
            var values = input.Select(s => Int32.Parse(s)).ToArray();
            int part1 = FindPairs(values, 2020);
            Console.WriteLine($"Part 1 answer: {part1}");

            int part2 = FindTrio(values, 2020);
            Console.WriteLine($"Part 2 answer: {part2}");
        }

        private static int FindPairs(int[] values, int searchValue)
        {
            values = values.OrderBy(s => s).ToArray();

            for (int i = 0; i < values.Length / 2; i++)
            {
                for (int j = values.Length - 1; j >= 0; j--)
                {
                    int sum = values[i] + values[j];

                    if (sum == searchValue)
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