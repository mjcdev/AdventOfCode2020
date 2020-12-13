using System.IO;
using AdventOfCode2020.Days.Twelve;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Twelve
{
    public class DayTwelvePartOneTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Twelve/input.txt");
            
            var result = new DayTwelvePartOne().CalculateFinalDestinationManhattanDistance(lines);
        }
    }
}
