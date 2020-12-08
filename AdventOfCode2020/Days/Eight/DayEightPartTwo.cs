using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Eight
{
    public class DayEightPartTwo
    {
        private const string Accumulate = "acc";
        private const string Jump = "jmp";
        private const string NoOperation = "nop";

        public int CalculateAccumulatorForFixed(IEnumerable<string> input)
        {
            var count = input.Count();
            
            for (var index = 0; index < count; index++)
            {
                var inputArray = input.ToArray();

                var current = inputArray[index];

                if (current.StartsWith(Accumulate))
                {
                    continue;
                }
                else if (current.StartsWith(NoOperation))
                {
                    inputArray[index] = current.Replace(NoOperation, Jump);
                }
                else if (current.StartsWith(Jump))
                {
                    inputArray[index] = current.Replace(Jump, NoOperation);
                }

                var result = CalculateAccumulatorForLoop(inputArray);

                if (result != null)
                {
                    return result.Value;
                }
            }

            return 0;
        }

        public int? CalculateAccumulatorForLoop(IEnumerable<string> input)
        {
            var visited = new HashSet<int>();
            var currentIndex = 0;
            var accumulator = 0;
            var instructions = input.ToArray();

            while (true)
            {
                var split = instructions[currentIndex].Split(' ');
                var instruction = split[0];
                var offset = int.Parse(split[1]);

                switch (instruction)
                {
                    case Accumulate:
                        accumulator += offset;
                        currentIndex++;
                        break;
                    case Jump:
                        currentIndex += offset;
                        break;
                    case NoOperation:
                        currentIndex++;
                        break;
                }

                if (currentIndex == instructions.Length)
                {
                    return accumulator;
                }

                if (visited.Contains(currentIndex))
                {
                    return null;
                }

                visited.Add(currentIndex);
            }
            
            return null;
        }
    }
}
