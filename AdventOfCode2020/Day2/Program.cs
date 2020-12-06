using System;
using System.Linq;
using Common;

namespace Day2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var lines = FileHelpers.ReadLines(args[0]);
            var partOneCount = lines.Where(IsPasswordLineValidRange).Count();
            var partTwoCount = lines.Where(IsPasswordLineValidPosition).Count();

            Console.WriteLine("part 1");
            Console.WriteLine("valid count: " + partOneCount);

            Console.WriteLine("part 2");
            Console.WriteLine("valid count: " + partTwoCount);
        }

        static bool IsPasswordLineValidRange(string line)
        {
            (string requirementsStr, string passwordStr) = ParseLine(line);
            (var matchCharacter, var min, var max) = ParseRange(requirementsStr);

            int matchCharacterCount = 0;
            for (int i = 0; i < passwordStr.Length; i++)
            {
                if (passwordStr[i].ToString() == matchCharacter) matchCharacterCount++;
            }

            return matchCharacterCount >= min && matchCharacterCount <= max;
        }

        static bool IsPasswordLineValidPosition(string line)
        {
            (string requirementsStr, string passwordStr) = ParseLine(line);
            (var matchCharacter, var firstPosition, var secondPosition) = ParsePosition(requirementsStr);

            if (firstPosition >= passwordStr.Length || secondPosition >= passwordStr.Length) return false;

            var firstCharacter = passwordStr[firstPosition].ToString();
            var secondCharacter = passwordStr[secondPosition].ToString();

            if (firstCharacter == matchCharacter && secondCharacter == matchCharacter) return false;
            return firstCharacter == matchCharacter || secondCharacter == matchCharacter;
        }

        static (string, string) ParseLine(string line)
        {
            var split = line.Split(':');
            return (split[0], split[1].TrimStart());
        }

        /// <summary>
        /// Returns the range of how many of each string can be present
        /// </summary>
        /// <param name="requirements"></param>
        /// <returns></returns>
        static (string, int, int) ParseRange(string requirements)
        {
            string[] parts = requirements.Split(' ');
            string rangeStr = parts[0];
            string[] rangeArr = rangeStr.Split('-');

            return (parts[1], int.Parse(rangeArr[0]), int.Parse(rangeArr[1]));
        }

        static (string, int, int) ParsePosition(string requirements)
        {
            string[] parts = requirements.Split(' ');
            string rangeStr = parts[0];
            string[] rangeArr = rangeStr.Split('-');

            return (parts[1], int.Parse(rangeArr[0]) - 1, int.Parse(rangeArr[1]) - 1);
        }
    }
}
