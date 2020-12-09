using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Nine
{
    public class DayNinePartOne
    {
        private const int SampleSize = 25;

        public long FirstNonMatchingValue(IEnumerable<string> input)
        {
            var inputArray = input.Select(long.Parse).ToArray();

            for (var index = SampleSize; index < inputArray.Length; index++)
            {
                var check = inputArray[index];

                if (!Matches(inputArray, index, check))
                {
                    return check;
                }
            }

            return 0;
        }

        public bool Matches(long[] input, int index, long check)
        {
            for (var i = index - SampleSize; i < index; i++)
            {
               for (var j = i + 1; i < j && j < index; j++)
               {
                   if (input[i] + input[j] == check)
                   {
                       return true;
                   }
               }
            }

            return false;
        }
    }
}
