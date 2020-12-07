using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days.One
{
    public class DayOnePartOne
    {
        private const int TwentyTwenty = 2020;

        public int CalculateResult(ICollection<int> numbers)
        {
            var numbersArray = numbers.ToArray();

            for (var outer = 0; outer <= numbers.Count; outer++)
            for (var inner = 0; inner <= numbers.Count; inner++)
            {
                if (outer == inner)
                {
                    break;
                }
                

                if (NumbersMatch(numbersArray[inner], numbersArray[outer]))
                {
                    return numbersArray[inner] * numbersArray[outer];
                }

            }

            return 0;
        }


        public bool NumbersMatch(int one, int two) => (one + two) == TwentyTwenty;
    }
}
