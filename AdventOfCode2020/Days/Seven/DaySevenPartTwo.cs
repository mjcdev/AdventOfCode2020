using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days.Seven
{
    public class DaySevenPartTwo
    {
        public int CountNumberOfContainingBags(IEnumerable<string> input, string colour)
        {
            var models = input.Select(BinTheBags).Select(BuildModel).ToList();

            var matches = new List<string>();

            Recurse(models, colour, matches);

            return matches.Count();
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

        public DayModelPartTwo BuildModel(string input)
        {
            var queue = new Queue<string>(input.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)));

            var colour = BuildColourString(queue.Dequeue(), queue.Dequeue());

            var containsCount = new Dictionary<string, int>();
            
            while (queue.Any())
            {
                var count = int.Parse(queue.Dequeue());

                var containedColour = BuildColourString(queue.Dequeue(), queue.Dequeue());
                
                containsCount.Add(containedColour, count);
            }

            return new DayModelPartTwo()
            {
                Colour = colour,
                ContainsCount = containsCount
            };
        }

        private string BuildColourString(string description, string colour) => $"{description} {colour}";

        public void Recurse(List<DayModelPartTwo> inputs, string matchingColour, List<string> matchingColours)
        {
            var matchForInputColour = inputs.FirstOrDefault(i => i.Colour == matchingColour);

            foreach (var containedBag in matchForInputColour.ContainsCount)
            {
                var colour = containedBag.Key;

                for (var bagCount = 0; bagCount < containedBag.Value; bagCount++)
                {
                    matchingColours.Add(colour);
                    Recurse(inputs, colour, matchingColours);
                }
            }
        }

    }
}
