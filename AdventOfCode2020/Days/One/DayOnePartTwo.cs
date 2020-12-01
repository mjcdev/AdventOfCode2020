using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.One
{
    public class DayOnePartTwo
    {
        private const int TwentyTwenty = 2020;

        public int CalculateResult(ICollection<int> numbers)
        {
            var numbersArray = numbers.ToArray();

            for (var a = 0; a < numbers.Count; a++)
            for (var b = 0; b < numbers.Count; b++)
            for (var c = 0; b < numbers.Count; c++)
            {
                if (a == b || b == c || a == c)
                {
                    break;
                }

                if (NumbersMatch(numbersArray[a], numbersArray[b], numbersArray[c]))
                {
                    return numbersArray[a] * numbersArray[b] * numbersArray[c];
                }

            }

            return 0;
        }


        public bool NumbersMatch(params int[] numbers) => numbers.Sum() == TwentyTwenty;
    }
}
