using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2020.Days.One;
using Xunit;

namespace AdventOfCode2020.Tests.Days.One
{
    public class DayOnePartTwoTests
    {
        [Fact]
        public void Answer()
        {
            var lines = File.ReadAllLines(@"Days/One/input.txt");
            var numbers = lines.Select(int.Parse).ToList();

            var result = new DayOnePartTwo().CalculateResult(numbers);
        }
    }
}
