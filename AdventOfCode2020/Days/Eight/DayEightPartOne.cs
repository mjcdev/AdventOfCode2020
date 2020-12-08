using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Eight
{
    public class DayEightPartOne
    {
        private const string Accumulate = "acc";

        private const string Jump = "jmp";

        private const string NoOperation = "nop";

        private HashSet<int> _visited = new HashSet<int>();
        private int _currentIndex = 0;
        private int _accumulator = 0;
        private string[] _instructions;

        public DayEightPartOne(IEnumerable<string> input)
        {
            _instructions = input.ToArray();
        }

        public int CalculateAccumulatorForLoop()
        {
            while (true)
            {
                var split = _instructions[_currentIndex].Split(' ');
                var instruction = split[0];
                var offset = int.Parse(split[1]);

                switch (instruction)
                {
                    case Accumulate:
                        _accumulator += offset;
                        _currentIndex++;
                        break;
                    case Jump:
                        _currentIndex += offset;
                        break;
                    case NoOperation:
                        _currentIndex++;
                        break;
                }

                if (_visited.Contains(_currentIndex))
                {
                    return _accumulator;
                }

                _visited.Add(_currentIndex);
            }


            return 0;
        }

        private bool Turn()
        {
            return false;
        }
    }
}
