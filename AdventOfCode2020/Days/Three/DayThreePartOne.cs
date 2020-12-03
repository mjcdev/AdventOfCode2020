using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Three
{
    public class DayThreePartOne
    {
        private const int VerticalMovement = 1;
        private const int HorizontalMovement = 3;

        private const char Tree = '#';

        private int X = 0;
        private int Y = 0;

        private int TreeCount = 0;

        public int CalculateResult(ICollection<string> input)
        {
            var inputArray = input.ToArray();

            while (Y < inputArray.Length)
            {
                if (IsTree(inputArray, X, Y))
                {
                    TreeCount++;
                }

                X += HorizontalMovement;
                Y += VerticalMovement;
            }

            return TreeCount;
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
