using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Three
{
    public class DayThreePartTwo
    {
        private const char Tree = '#';
        
        public long CalculateResult(ICollection<string> input)
        {
            var inputArray = input.ToArray();

            return
                CountTreesForTrajectory(inputArray, 1, 1)
                * CountTreesForTrajectory(inputArray, 3, 1)
                * CountTreesForTrajectory(inputArray, 5, 1)
                * CountTreesForTrajectory(inputArray, 7, 1)
                * CountTreesForTrajectory(inputArray, 1, 2);
        }
        
        public long CountTreesForTrajectory(string[] input, int horizontalMovement, int verticalMovement)
        {
            long treeCount = 0;
            var x = 0;
            var y = 0;

            while (y < input.Length)
            {
                if (IsTree(input, x, y))
                {
                    treeCount++;
                }

                x += horizontalMovement;
                y += verticalMovement;
            }

            return treeCount;
        }


        public static bool IsTree(string[] map, int x, int y)
        {
            var xAxis = map[y];
            var xRemainder = XRemainder(xAxis, x);

            return xAxis[xRemainder] == Tree;
        }

        public static int XRemainder(string input, int x)
        {
            return x % input.Length;
        }
    }
}
