using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days.Seven
{
    public class DaySevenPartOne
    {
        public int CountNumberOfContainingBags(IEnumerable<string> input, string colour)
        {
            var models = input.Select(BinTheBags).Select(BuildModel).ToList();

            var matches = new List<string>();

            Recurse(models, colour, matches);

            return matches.Distinct().Count();
        }

        public string BinTheBags(string input)
        {
            return input
                .Replace(" no other bags", string.Empty)
                .Replace(" bags", string.Empty)
                .Replace(" bag", string.Empty)
                .Replace(".", string.Empty)
                .Replace(",", string.Empty)
                .Replace("contain", string.Empty);
        }

        public DayModelPartOne BuildModel(string input)
        {
            var queue = new Queue<string>(input.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)));

            var colour = BuildColourString(queue.Dequeue(), queue.Dequeue());

            var contains = new HashSet<string>();
            
            while (queue.Any())
            {
                // bin number
                queue.Dequeue();

                var containedColour = BuildColourString(queue.Dequeue(), queue.Dequeue());
                
                contains.Add(containedColour);
            }

            return new DayModelPartOne()
            {
                Colour = colour,
                Contains = contains
            };
        }

        private string BuildColourString(string description, string colour) => $"{description} {colour}";

        public List<string> GetMatchingContainingBags(string colour, IEnumerable<DayModelPartOne> input)
        {
            return input.Where(i => i.Contains.Contains(colour)).Select(c => c.Colour).ToList();
        }

        public void Recurse(List<DayModelPartOne> inputs, string matchingColour, List<string> matchingColours)
        {
            var matchesForInputColour = GetMatchingContainingBags(matchingColour, inputs);

            foreach (var colour in matchesForInputColour)
            {
                matchingColours.Add(colour);
                Recurse(inputs, colour, matchingColours);
            }
        }

    }
}
