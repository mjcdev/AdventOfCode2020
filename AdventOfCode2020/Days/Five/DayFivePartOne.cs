using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days.Five
{
    public class DayFivePartOne
    {
        public int GetMaximumSeatId(IEnumerable<string> input)
        {
            return input.Max(GetSeatId);
        }

        public int GetSeatId(string input)
        {
            var binaryString = ConvertToBinaryString(input);

            var row = GetRow(binaryString);
            var column = GetColumn(binaryString);

            return (row * 8) + column;
        }

        public string ConvertToBinaryString(string input) =>
            input
                .Replace('F', '0')
                .Replace('B', '1')
                .Replace('L', '0')
                .Replace('R', '1');

        public int GetRow(string input) => Convert.ToInt32(input.Substring(0, 7), 2);

        public int GetColumn(string input) => Convert.ToInt32(input.Substring(7, 3), 2);
    }
}
