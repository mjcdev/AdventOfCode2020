﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2020.Days.Nine;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Nine
{
    public class DayNinePartOneTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Nine/input.txt");

            var result = new DayNinePartOne().FirstNonMatchingValue(lines);
        }

        [Fact]
        public void Match()
        {
            var result = new DayNinePartOne().Matches(Enumerable.Range(1, 50).Select(i => (long)i).ToArray(), 4, 5);
        }
    }
}
