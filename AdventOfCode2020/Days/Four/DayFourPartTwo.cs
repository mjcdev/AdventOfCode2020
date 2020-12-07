using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Days.Four
{
    public class DayFourPartTwo
    {
        public int CountValidPassports(IEnumerable<string> input)
        {
            var passports = BuildPassports(input);

            return passports.Count(IsValidPassport);
        }

        public Dictionary<string, Func<string, bool>> Rules = new Dictionary<string, Func<string, bool>>()
        {
            ["byr"] = ByrRule,
            ["iyr"] = IyrRule,
            ["eyr"] = EyrRule,
            ["hgt"] = HgtRule,
            ["hcl"] = HclRule,
            ["ecl"] = EclRule,
            ["pid"] = PidRule
        };

        public static HashSet<string> EyeColours = new HashSet<string>()
        {
            "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
        };

        //byr(Birth Year) - four digits; at least 1920 and at most 2002.
        //iyr(Issue Year) - four digits; at least 2010 and at most 2020.
        //eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
        //hgt(Height) - a number followed by either cm or in:
            //If cm, the number must be at least 150 and at most 193.
            //If in, the number must be at least 59 and at most 76.
        //hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        //ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        //pid(Passport ID) - a nine-digit number, including leading zeroes.
        //cid(Country ID) - ignored, missing or not.
        public bool IsValidPassport(Dictionary<string, string> passport)
        {
            return Rules.Keys.All(passport.ContainsKey) && Rules.All(r => ApplyValidityAndPredicateFor(passport, r.Key, r.Value));
        }

        public bool ApplyValidityAndPredicateFor(Dictionary<string, string> passport, string key, Func<string, bool> predicate)
        {
            if (passport.TryGetValue(key, out string value))
            {
                return predicate(value);
            };

            return false;
        }

        //ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        public static bool EclRule(string value) => EyeColours.Contains(value);

        //pid(Passport ID) - a nine-digit number, including leading zeroes.
        public static bool PidRule(string value) => Regex.IsMatch(value, @"^[0-9]{9}$");

        //hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        public static bool HclRule(string value) => Regex.IsMatch(value, @"^#[0-9|a-f]{6}$");

        //byr(Birth Year) - four digits; at least 1920 and at most 2002.
        public static bool ByrRule(string value) => RangeRule(value, 1920, 2002, 4);

        //iyr(Issue Year) - four digits; at least 2010 and at most 2020.
        public static bool IyrRule(string value) => RangeRule(value, 2010, 2020, 4);

        //eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
        public static bool EyrRule(string value) => RangeRule(value, 2020, 2030, 4);

        //hgt(Height) - a number followed by either cm or in:
        //If cm, the number must be at least 150 and at most 193.
        //If in, the number must be at least 59 and at most 76.
        public static bool HgtRule(string value)
        {
            if (value.EndsWith("cm"))
            {
                return RangeRule(value.Substring(0, value.Length - 2), 150, 193, 3);
            }

            if (value.EndsWith("in"))
            {
                return RangeRule(value.Substring(0, value.Length - 2), 59, 76, 2);
            }

            return false;
        }

        public static bool RangeRule(string value, int min, int max, int length)
        {
            var numeric = int.Parse(value);

            return value.Length == length && numeric >= min && numeric <= max;
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
