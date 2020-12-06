using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days.Six
{
    public class DaySixPartOne
    {
        public int CountGroupedAnswers(IEnumerable<string> input)
        {
            var group = string.Empty;
            var count = 0;

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    count += group.Distinct().Count();

                    group = string.Empty;
                }

                group += line;
            }

            if (!string.IsNullOrWhiteSpace(group))
            {
                count += group.Distinct().Count();
            }

            return count;
        }
    }
}
