using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Ten
{
    public class DayTenPartOne
    {
        public int CalculateJoltageMultiplier(IEnumerable<string> input)
        {
            var orderedInputArray = input.Where(i => !string.IsNullOrWhiteSpace(i)).Select(int.Parse).OrderBy(i => i).ToList();

            // add device adapter
            orderedInputArray.Add(orderedInputArray.Max() + 3);

            int oneDifferentials = 0;
            int threeDifferentials = 0;
            
            var currentAdapter = 0;
            

            for (var index = 0; index < orderedInputArray.Count; index++)
            {
                var newAdapter = orderedInputArray[index];

                var difference = newAdapter - currentAdapter;
                
                if (difference == 1)
                {
                    oneDifferentials++;
                }

                if (difference == 3)
                {
                    threeDifferentials++;
                }

                currentAdapter = newAdapter;
            }
            
            return oneDifferentials * threeDifferentials;
        }
    }
}
