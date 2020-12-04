using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Four
{
    public class DayFourPartOne
    {
        private static readonly List<string> RequiredProperties = new List<string>()
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
            
        };


        public int CountValidPassports(IEnumerable<string> input)
        {
            var passports = BuildPassports(input);

            return passports.Count(IsValidPassport);
        }

        public bool IsValidPassport(Dictionary<string, string> passport)
        {
            return RequiredProperties.All(passport.ContainsKey);
        }

        public IList<Dictionary<string, string>> BuildPassports(IEnumerable<string> input)
        {
            var passports = new List<Dictionary<string, string>>();

            var tempPassport = new Dictionary<string, string>();

            foreach (var line in input)
            {   
                if (string.IsNullOrWhiteSpace(line))
                {
                    passports.Add(new Dictionary<string, string>(tempPassport));

                    tempPassport.Clear();
                    continue;
                }

                var items = line.Split(' ');

                foreach (var item in items)
                {
                    var values = item.Split(':');

                    tempPassport.Add(values[0], values[1]);
                }
            }

            if (tempPassport.Any())
            {
                passports.Add(new Dictionary<string, string>(tempPassport));
            }

            return passports;
        }
    }
}
