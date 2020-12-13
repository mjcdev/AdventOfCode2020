using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace AdventOfCode2020.Days.Eleven
{
    public class DayElevenPartTwo
    {
        private const char Occupied = '#';
        private const char Unoccupied = 'L';
        private const char Floor = '.';

        public int CalculateNumberOfStablePopulatedSeats(IEnumerable<string> input)
        {
            var map = BuildMap(input);
            var height = map.Length;
            var width = map[0].Length;

            var finalMap = StartLoop(map, width, height);

            var count = finalMap.SelectMany(s => s).Count(c => c == Occupied);
            return count;
        }

        public char[][] BuildMap(IEnumerable<string> input) => input.Where(a => !string.IsNullOrWhiteSpace(a)).Select(i => i.ToCharArray()).ToArray();

        // Assume edges of Map are Floor
        public char? GetCoordinate(char[][] map, int x, int y, int width, int height)
        {
            if (x < 0 || y < 0 || x >= width || y >= height)
            {
                return null;
            }

            return map[y][x];
        }

        public char[][] StartLoop(char[][] map, int width, int height)
        {
            var numberOfChanges = 0;
            var daysStatic = 0;
            var today = map;
            var newDay = today;

            do
            {
                newDay = today.Select(y => y.ToArray()).ToArray();

                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var start = GetCoordinate(today, x, y, width, height);

                        var next = NextState(today, x, y, width, height);

                        newDay[y][x] = next;

                        if (start != next)
                        {
                            numberOfChanges++;
                        }
                    }
                }


                if (numberOfChanges == 0)
                {
                    daysStatic++;
                }

                numberOfChanges = 0;
                today = newDay;
            } while (daysStatic < 3);


            return newDay;
        }

        public char NextState(char[][] map, int x, int y, int width, int height)
        {
            var current = GetCoordinate(map, x, y, width, height);

            if (current == Floor)
            {
                return Floor;
            }

            var adjacentOccupiedSeats = CountAdjacentOccupiedSeats(map, x, y, width, height);

            if (current == Unoccupied && adjacentOccupiedSeats == 0)
            {
                return Occupied;
            }

            if (current == Occupied && adjacentOccupiedSeats >= 5)
            {
                return Unoccupied;
            }

            return current.Value;
        }

        public int CountAdjacentOccupiedSeats(char[][] map, int x, int y, int width, int height)
        {
            var adjacentOccupiedSeats = 0;

            for (var vectorY = -1; vectorY <= 1; vectorY++)
            for (var vectorX = -1; vectorX <= 1; vectorX++)
            {
                if (vectorX == 0 && vectorY == 0)
                {
                    continue;
                }

                var foundSeatOrEdge = false;

                var checkX = x;
                var checkY = y;

                while (!foundSeatOrEdge)
                {
                    var coordinate = GetCoordinate(map, checkX += vectorX, checkY += vectorY, width, height);

                    if (coordinate == Occupied || coordinate == Unoccupied || !coordinate.HasValue)
                    {
                        foundSeatOrEdge = true;
                    }

                    if (coordinate == Occupied)
                    {
                        adjacentOccupiedSeats++;
                    }
                }

            }

            return adjacentOccupiedSeats;
        }
    }
}
