using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days.Six
{
    public class DaySixPartTwo
    {
        public int CountGroupedAnswers(IEnumerable<string> input)
        {
            var group = string.Empty;
            var count = 0;
            var countInGroup = 0;

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    var countForGroup = CountForGroup(group, countInGroup);

                    count += countForGroup;

                    group = string.Empty;
                    countInGroup = 0;
                }
                else
                {
                    group += line;
                    countInGroup++;
                }
            }

            if (!string.IsNullOrWhiteSpace(group))
            {
                count += CountForGroup(group, countInGroup);
            }

            return count;
        }

        public int CountForGroup(string groupAnswers, int countInGroup)
        {
            return groupAnswers
                .GroupBy(g => g)
                .Select(g => new { Char = g.Key, Count = g.Count() })
                .Where(c => c.Count == countInGroup)
                .Count();
        }
    }
}
