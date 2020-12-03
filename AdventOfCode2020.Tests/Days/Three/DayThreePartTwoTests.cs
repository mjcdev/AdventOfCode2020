using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2020.Days.One;
using AdventOfCode2020.Days.Three;
using AdventOfCode2020.Days.Two;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Three
{
    public class DayThreePartTwoTests
    {
        [Fact]
        public void Answer()
        {
            var lines = File.ReadAllLines(@"Days/Three/input.txt");
            var input = lines.ToList();

            var result = new DayThreePartTwo().CalculateResult(input);
        }
    }
}
