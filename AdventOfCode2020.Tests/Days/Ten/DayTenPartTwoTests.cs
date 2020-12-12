using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2020.Days.Ten;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Ten
{
    public class DayTenPartTwoTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Ten/input.txt");

            var result = new DayTenPartTwo().CalculateUniqueArrangements(lines);
        }

        [Fact]
        public void SimpleTestCase()
        {
            var lines = File.ReadAllLines(@"Days/Ten/simpletestcase.txt");
            var day = new DayTenPartTwo();

            var result = day.CalculateUniqueArrangements(lines);

            result.Should().Be(8);
        }

        [Fact]
        public void TestCase()
        {
            var lines = File.ReadAllLines(@"Days/Ten/testcase.txt");
            var day = new DayTenPartTwo();

            var result = day.CalculateUniqueArrangements(lines);

            result.Should().Be(19208);
        }


        [Fact]
        public void Split()
        {
            var input =  new[] {  0, 1, 2, 3, 4, 7, 10, 11, 12, 15 };

            var result = new DayTenPartTwo().Split(input).ToList();

            result[0].Should().HaveCount(5);
            result[1].Should().HaveCount(1);
            result[2].Should().HaveCount(3);
            result[3].Should().HaveCount(1);

            result.Should().HaveCount(4);
        }

    }
}
