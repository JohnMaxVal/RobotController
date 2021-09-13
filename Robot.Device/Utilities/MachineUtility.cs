using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Device.Utilities
{
    /// <summary>
    /// Helper classes for <see cref="IMachine"/> instance
    /// </summary>
    internal static class MachineUtility
    {
        public static Direction GetDirection(char dir) => dir switch
        {
            'S' => Direction.South,
            'W' => Direction.West,
            'N' => Direction.North,
            'E' => Direction.East,
            _ => throw new ArgumentException("GetDirection: input direction is not specified")
        };

        internal static (int x, int y) Get2DCoordinateByDirection(Direction direction) => direction switch
        {
            Direction.East => (1, 0),
            Direction.West => (-1, 0),
            Direction.South => (0, -1),
            Direction.North => (0, 1),
            _ => throw new ArgumentException("Get2DCoordinateByDirection: input direction is not specified")
        };

        internal static Direction GetDirectionByOrientation(MoveCommand command, Direction currDirection)
        {
            int res = (int)currDirection;

            if (command == MoveCommand.Left)
            {
                res = (++res) % 4;
            }
            else if (command == MoveCommand.Right)
            {
                if (--res < 0)
                {
                    res = 3;
                }
            }
            else
            {
                throw new ArgumentException("GetDirectionByOrientation: input command is not specified");
            }

            return (Direction)res;
        }

        internal static MoveCommand GetMoveCommand(char cmd) => cmd switch
        {
            'L' => MoveCommand.Left,
            'R' => MoveCommand.Right,
            'M' => MoveCommand.Move,
            _ => throw new ArgumentException("GetMoveCommand: input parameter is not specified")
        };
    }
}
