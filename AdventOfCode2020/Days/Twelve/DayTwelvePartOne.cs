using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Twelve
{
    public class DayTwelvePartOne
    {
        private int X = 0;
        private int Y = 0;
        private int Direction = 90;

        public int CalculateFinalDestinationManhattanDistance(IEnumerable<string> input)
        {
            foreach (var instruction in input)
            {
                DoInstruction(instruction);
            }

            return CalculateManhattanDistance();
        }

        public void DoInstruction(string instruction)
        {
            var description = instruction[0];
            var quantity = int.Parse(instruction.Substring(1));

            switch (description)
            {
                case 'N':
                    MoveNorth(quantity);
                    break;
                case 'E':
                    MoveEast(quantity);
                    break;
                case 'S':
                    MoveSouth(quantity);
                    break;
                case 'W':
                    MoveWest(quantity);
                    break;
                case 'L':
                    TurnLeft(quantity);
                    break;
                case 'R':
                    TurnRight(quantity);
                    break;
                case 'F':
                    MoveForward(quantity);
                    break;
            }
        }


        public void MoveEast(int distance) => X += distance;

        public void MoveWest(int distance) => X -= distance;

        public void MoveNorth(int distance) => Y += distance;

        public void MoveSouth(int distance) => Y -= distance;

        public void TurnLeft(int degrees) => Direction -= degrees;

        public void TurnRight(int degrees) => Direction += degrees;

        public void MoveForward(int distance)
        {
            var direction = Get360BasedDirection();

            if (direction == 0)
            {
                MoveNorth(distance);
            }

            if (direction == 90)
            {
                MoveEast(distance);
            }

            if (direction == 180)
            {
                MoveSouth(distance);
            }

            if (direction == 270)
            {
                MoveWest(distance);
            }
        }

        public int Get360BasedDirection()
        {
            var direction = Direction;

            while (direction < 0)
            {
                direction += 360;
            }

            return direction % 360;
        }

        public int CalculateManhattanDistance() => Math.Abs(X) + Math.Abs(Y);
    }
}
