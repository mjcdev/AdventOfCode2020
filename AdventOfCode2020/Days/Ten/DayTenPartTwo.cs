using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace AdventOfCode2020.Days.Ten
{
    public class DayTenPartTwo
    {
        public long CalculateUniqueArrangements(IEnumerable<string> input)
        {
            var inputList = input.Where(i => !string.IsNullOrWhiteSpace(i)).Select(int.Parse).ToList();

            // power supply and device
            inputList.Add(0);
            inputList.Add(inputList.Max() + 3);

            var orderedInputArray = inputList.OrderBy(i => i).ToArray();

            var splitArray = Split(orderedInputArray);

            var combinationCountSets = splitArray.Select(CountCombinations).ToList();

            long product = 1;

            foreach (var combinationCount in combinationCountSets)
            {
                product *= combinationCount;
            }

            return product;
        }


        public IEnumerable<List<int>> Split(int[] inputArray)
        {
            var list = new List<int>();

            for (int index = 0; index < inputArray.Length - 1; index++)
            {
                var difference = inputArray[index + 1] - inputArray[index];

                list.Add(inputArray[index]);

                if (difference == 3)
                {
                    yield return list.ToList();
                    list.Clear();
                }
            }

            list.Add(inputArray[^1]);

            yield return list.ToList();
        }

        public long CountCombinations(List<int> inputList)
        {
            var length = inputList.Count;

            switch (length)
            {
                case 1:
                    return 1;
                case 2:
                    return 1;
                case 3:
                    return 2;
                case 4:
                    return 4;
                case 5:
                    return 7;
            }

            return 0;
        }
    }
}
