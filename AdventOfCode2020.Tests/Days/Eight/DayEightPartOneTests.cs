using System.IO;
using AdventOfCode2020.Days.Eight;
using Xunit;

namespace AdventOfCode2020.Tests.Days.Eight
{
    public class DayEightPartOneTests
    {
        [Fact]
        public void CalculateAnswer()
        {
            var lines = File.ReadAllLines(@"Days/Eight/input.txt");

            var result = new DayEightPartOne(lines).CalculateAccumulatorForLoop();
        }
    }
}
