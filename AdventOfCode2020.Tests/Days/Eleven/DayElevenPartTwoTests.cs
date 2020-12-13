using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2020.Days.Eleven;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Eleven
{
    public class DayElevenPartTwoTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Eleven/input.txt");

            var result = new DayElevenPartTwo().CalculateNumberOfStablePopulatedSeats(lines);
        }

        [Fact]
        public void TestCase()
        {
            var lines = File.ReadAllLines(@"Days/Eleven/testcase.txt");

            var result = new DayElevenPartTwo().CalculateNumberOfStablePopulatedSeats(lines);
        }

        [Fact]
        public void CountAdjacentOccupiedSeats()
        {
            var lines = File.ReadAllLines(@"Days/Eleven/testcase.txt");

            var map = lines.Select(s => s.ToCharArray()).ToArray();

            var day = new DayElevenPartTwo();

            var result = day.CountAdjacentOccupiedSeats(map, 0, 0, 10, 10);
        }

        [Fact]
        public void CountAdjacentOccupiedSeats_Occupied()
        {
            var lines = new List<string>
            {
                ".#.#.",
                "#...#",
                ".....",
                "#...#",
                ".#.#."
            };

            var map = lines.Select(s => s.ToCharArray()).ToArray();

            var day = new DayElevenPartTwo();

            day.CountAdjacentOccupiedSeats(map, 0, 0, 5, 5).Should().Be(2);
            day.CountAdjacentOccupiedSeats(map, 1, 1, 5, 5).Should().Be(4);
            day.CountAdjacentOccupiedSeats(map, 2, 2, 5, 5).Should().Be(0);
        }

    }
}
