using System.IO;
using AdventOfCode2020.Days.Six;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Six
{
    public class DaySixPartOneTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Six/input.txt");

            var result = new DaySixPartOne().CountGroupedAnswers(lines);
        }
    }
}
