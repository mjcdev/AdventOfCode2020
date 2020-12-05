using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AdventOfCode2020.Days.Five;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests.Five
{
    public class DayFivePartTwoTests
    {
        [Fact]
        public void GetAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Five/input.txt");

            var result = new DayFivePartTwo().GetMissingSeatId(lines);
        }

        [Theory]
        [InlineData(567, "BFFFBBFRRR", 70, 7)]
        [InlineData(119, "FFFBBBFRRR", 14, 7)]
        [InlineData(820, "BBFFBBFRLL", 102, 4)]
        public void TestCases(int expected, string input, int row, int column)
        {
            var day = new DayFivePartOne();

            var binary = day.ConvertToBinaryString(input);

            day.GetRow(binary).Should().Be(row);
            day.GetColumn(binary).Should().Be(column);
            day.GetSeatId(binary).Should().Be(expected);
        }
    }
}
