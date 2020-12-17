using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code
{
    public class Day2
    {
        public void Run(IEnumerable<string> input)
        {
            var entries = input.Select(s => PasswordEntry.Parse(s));
            var results = entries.Where(e => e.IsValid());

            Console.WriteLine($"{results.Count()} valid passwords");
        }
        
    }

    public class PasswordEntry
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public char Character { get; set; }
        public string Value { get; set; }

        public static PasswordEntry Parse(string entry)
        {
            string[] tokens = entry.Split(':');            
            if (tokens.Length != 2)
                throw new ArgumentException("Invalid input entry", "entry");

            string[] rules = tokens[0].Split(' ');
            string[] minmax = rules[0].Split('-');

            var result = new PasswordEntry();
            result.Value = tokens[1].Trim();
            result.Character = rules[1][0];
            result.Minimum = Int32.Parse(minmax[0]);
            result.Maximum = Int32.Parse(minmax[1]);
            return result;
        }

        public bool IsValid()
        {
            try
            {
                return (Value[Minimum-1] == Character && Value[Maximum-1] != Character) || (Value[Minimum-1] != Character && Value[Maximum-1] == Character);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Min: {Minimum}, Max: {Maximum}, Character: {Character}, Password: {Value}";
        }
    }

    
}