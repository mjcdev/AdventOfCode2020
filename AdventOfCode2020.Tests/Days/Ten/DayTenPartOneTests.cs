using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AdventOfCode2020.Days.Ten;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Ten
{
    public class DayTenPartOneTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Ten/input.txt");

            var result = new DayTenPartOne().CalculateJoltageMultiplier(lines);
        }

        [Fact]
        public void TestCase()
        {
            var lines = File.ReadAllLines(@"Days/Ten/testcase.txt");

            var result = new DayTenPartOne().CalculateJoltageMultiplier(lines);

            result.Should().Be(220);
        }
    }
}
