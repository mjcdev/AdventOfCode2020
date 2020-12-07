using System.IO;
using AdventOfCode2020.Days.Seven;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Seven
{
    public class DaySevenPartTwoTests
    {

        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Seven/input.txt");

            var result = new DaySevenPartTwo().CountNumberOfContainingBags(lines, "shiny gold");
        }

    }
}
