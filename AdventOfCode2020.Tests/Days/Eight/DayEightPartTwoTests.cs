using System.IO;
using AdventOfCode2020.Days.Eight;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Eight
{
    public class DayEightPartTwoTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Eight/input.txt");

            var result = new DayEightPartTwo().CalculateAccumulatorForFixed(lines);
        }
    }
}
