using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2020.Days.One;
using AdventOfCode2020.Days.Two;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Two
{
    public class DayTwoPartTwoTests
    {
        [Fact]
        public void Answer()
        {
            var lines = File.ReadAllLines(@"Days/Two/input.txt");
            var input = lines.ToList();

            var result = new DayTwoPartTwo().CalculateNumberOfValidPasswords(input);
        }
    }
}
