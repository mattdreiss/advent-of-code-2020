using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = ReadInput(args[0]);
            IReadOnlyList<int> amounts = ParseAsIntegers(lines).ToList();

            (int a, int b) = FindTwoSummingInts(amounts);

            Console.WriteLine("** Part One **");
            Console.WriteLine("a: " + a);
            Console.WriteLine("b: " + b);
            Console.WriteLine("a * b: " + a * b);

            (int x, int y, int z) = FindThreeSummingInts(amounts);

            Console.WriteLine("** Part Two **");
            Console.WriteLine("x: " + x);
            Console.WriteLine("y: " + y);
            Console.WriteLine("z: " + z);
            Console.WriteLine("x * y * z: " + x * y * z);
        }

        static (int a, int b) FindTwoSummingInts(IReadOnlyList<int> input, int target = 2020)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (input[i] + input[j] == target)
                    {
                        return (input[i], input[j]);
                    }
                }
            }

            return (0, 0);
        }

        static (int a, int b, int c) FindThreeSummingInts(IReadOnlyList<int> input, int target = 2020)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    for (int k = j + 1; k < input.Count; k++) {
                        if (input[i] + input[j] + input[k] == target)
                        {
                            return (input[i], input[j], input[k]);
                        }
                    }
                }
            }

            return (0, 0, 0);
        }

        #region InputHelpers

        static IEnumerable<int> ParseAsIntegers(string[] lines)
        {
            return lines.Select(line => int.Parse(line));
        }

        static string[] ReadInput(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception)
            {
                return new string[] { };
            }
        }

        #endregion

    }
}
