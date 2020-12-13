using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Twelve
{
    public class DayTwelvePartTwo
    {
        private int X = 0;
        private int Y = 0;
        private int Direction = 90;

        private int WaypointX = 10;
        private int WaypointY = 1;

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


        public void MoveEast(int distance) => WaypointX += distance;

        public void MoveWest(int distance) => WaypointX -= distance;

        public void MoveNorth(int distance) => WaypointY += distance;

        public void MoveSouth(int distance) => WaypointY -= distance;

        public void TurnLeft(int degrees) => RotateWaypoint(-degrees);

        public void TurnRight(int degrees) => RotateWaypoint(degrees);

        public void MoveForward(int distance)
        {
            var distanceX = WaypointX * distance;
            var distanceY = WaypointY * distance;

            X += distanceX;
            Y += distanceY;
        }

        public int Get360BasedDirection(int direction)
        {
            while (direction < 0)
            {
                direction += 360;
            }

            return direction % 360;
        }

        public int CalculateManhattanDistance() => Math.Abs(X) + Math.Abs(Y);

        public void RotateWaypoint(int angle)
        {
            var startWaypointX = WaypointX;
            var startWaypointY = WaypointY;

            var direction = Get360BasedDirection(angle);

            if (direction == 0)
            {
                return;
            }

            if (direction == 90)
            {
                RotateClockwise();
                return;
            }

            if (direction == 180)
            {
                RotateClockwise();
                RotateClockwise();
                return;
            }

            if (direction == 270)
            {
                RotateClockwise();
                RotateClockwise();
                RotateClockwise();
                return;
            }
        }

        public void RotateClockwise()
        {
            var startWaypointX = WaypointX;
            var startWaypointY = WaypointY;

            WaypointX = startWaypointY;
            WaypointY = -startWaypointX;
        }
    }
}
