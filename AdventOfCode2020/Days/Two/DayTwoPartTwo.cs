﻿using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days.Two
{
    public class DayTwoPartTwo
    {
        public int CalculateNumberOfValidPasswords(IEnumerable<string> inputLines)
        {
            var inputs = inputLines.Select(BuildModel).ToArray();

            return inputs.Count(IsValid);
        }

        //1-3 a: abcde
        private InputModel BuildModel(string line)
        {
            var segments = line.Split('-', ':', ' ');

            var model = new InputModel()
            {
                First = int.Parse(segments[0]),
                Second = int.Parse(segments[1]),
                Character = segments[2][0],
                Password = segments[4]
            };

            return model;
        }

        private bool IsValid(InputModel input)
        {
            var firstIndex = input.First - 1;
            var secondIndex = input.Second - 1;

            var firstMatch = input.Password[firstIndex] == input.Character;
            var secondMatch = input.Password[secondIndex] == input.Character;

            return firstMatch != secondMatch;
        }
    }
}
