using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AdventOfCode2020.Days.Four;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Four
{
    public class DayFourPartOneTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Four/input.txt");

            var result = new DayFourPartOne().CountValidPassports(lines);
        }
    }
}
