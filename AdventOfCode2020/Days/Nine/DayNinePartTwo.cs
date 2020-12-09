using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Nine
{
    public class DayNinePartTwo
    {
        private const int SampleSize = 25;

        public long EncryptionWeakness(IEnumerable<string> input)
        {
            var inputArray = input.Select(long.Parse).ToArray();

            var nonMatchingValue = FirstNonMatchingValue(inputArray);

            return FindEncryptionWeakness(inputArray, nonMatchingValue);
        }

        public long FirstNonMatchingValue(long[] inputArray)
        {

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

        public long FindEncryptionWeakness(long[] inputArray, long check)
        {
            var span = inputArray.AsSpan();

            for (var i = 0; i < inputArray.Length - 1; i++)
            {
                for (var j = i + 1; j < inputArray.Length; j++)
                {
                    var sliceArray = span.Slice(i, j - i).ToArray();

                    var result = sliceArray.Sum();

                    if (result > check)
                    {
                        break;
                    }
                    else if (result == check)
                    {
                        return sliceArray.Min() + sliceArray.Max();
                    }
                }
            }

            return 0;
        }
    }
}
