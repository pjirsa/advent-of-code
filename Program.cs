using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code
{
    public class Program
    {
        static void Main(string[] args)
        {
            new Program().RunAsync().Wait();
        }

        private async Task RunAsync()
        {
            var day1input = await ReadInputFileAsync("input1.txt");
            var day1 = new Day1();
            day1.Run(day1input);

            var day2input = await ReadInputFileAsync("input2.txt");
            var day2 = new Day2();
            day2.Run(day2input);
        }

        private async Task<string[]> ReadInputFileAsync(string filename)
        {
            var fileContents = await File.ReadAllLinesAsync(filename);
            return fileContents.ToArray();
        }
        
    }
}
