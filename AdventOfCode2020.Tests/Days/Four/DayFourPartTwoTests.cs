using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AdventOfCode2020.Days.Four;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Four
{
    public class DayFourPartTwoTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var result = CountValidPassportsForFile(@"Days/Four/input.txt");
        }

        [Fact]
        public void Valid()
        {
            var result = CountValidPassportsForFile(@"Days/Four/valid.txt");
        }

        [Fact]
        public void Invalid()
        {
            var result = CountValidPassportsForFile(@"Days/Four/invalid.txt");
        }

        private int CountValidPassportsForFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            return new DayFourPartTwo().CountValidPassports(lines);
        }
    }
}
