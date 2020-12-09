using System;
using Common;

namespace Day3
{
    internal class Program
    {
        private const char TreeCharacter = '#';

        public static void Main(string[] args)
        {
            var lines = FileHelpers.ReadLines(args[0]);

            int part1Count = CountOfTrees(lines);
            Console.WriteLine("part 1 tree count: " + part1Count);

            int part2Count = part1Count;
            part2Count *= CountOfTrees(lines, 1, 1);
            part2Count *= CountOfTrees(lines, 5, 1);
            part2Count *= CountOfTrees(lines, 7, 1);
            part2Count *= CountOfTrees(lines, 1, 2);

            Console.WriteLine("part 2 tree product: " + part2Count);
        }

        private static bool IsTreeAtPosition(string[] grid, int x, int y)
        {
            var row = grid[y];
            var rowPosition = x % row.Length;
            return row[rowPosition] == TreeCharacter;
        }

        private static int CountOfTrees(string[] grid, int deltaX = 3, int deltaY = 1)
        {
            int count = 0;
            int x = 0;
            int y = 0;

            while (y < grid.Length)
            {
                if (IsTreeAtPosition(grid, x, y))
                {
                    count++;
                }

                x += deltaX;
                y += deltaY;
            }

            return count;
        }

        private static (int x, int y) AdvanceToNextSpace(int x, int y, int deltaX = 3, int deltaY = 1)
        {
            return (x + deltaX, y + deltaY);
        }
    }
}
