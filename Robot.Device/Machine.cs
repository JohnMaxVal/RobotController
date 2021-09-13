using Robot.ControlPanel.InputParameters;
using Robot.ControlPanel;
using System;
using System.Collections.Generic;
using Robot.Device.Position;
using Robot.Device.Utilities;

namespace Robot.Device
{
    using Panel = ControlPanel.ControlPanel;

    /// <summary>
    /// Instance of robot
    /// </summary>
    public class Machine : IMachine
    {
        /// <summary>
        /// Specify the version of <see cref="IMachine"/> instance
        /// </summary>
        private static readonly int _version;
        public static int Version => _version;

        private Panel _panel;

        /// <summary>
        /// List of input parameters
        /// </summary>
        private List<IParameter> _parameters;
        public List<IParameter> InputParameters => _parameters;

        private List<MoveCommand> _commands;
        internal List<MoveCommand> Commands => _commands;

        private Position2D _currentPosition;
        public Position2D CurrentPosition => _currentPosition;

        /// <summary>
        /// Initialize <see cref="IMachine"/> static members
        /// </summary>
        static Machine()
        {
            _version++;
        }

        /// <summary>
        /// Constructs a new <see langword="Machine""/>
        /// </summary>
        public Machine(Panel panel)
        {
            if (panel == null)
            {
                throw new ArgumentNullException("Control panel is not specified");
            }
            _panel = panel;
            _parameters = new List<IParameter>();
            _commands = new List<MoveCommand>();
            RegisterEvents();
        }

        /// <summary>
        /// Provide algorithm for move
        /// </summary>
        public void Move()

        {
            foreach (var command in _commands)
            {
                switch (command)
                {
                    case MoveCommand.Move:
                        // TODO
                        //MachineUtility.ValidateBoundary(_currentPosition.X, _currentPosition.Y);
                        (int x, int y) coords = MachineUtility.Get2DCoordinateByDirection(_currentPosition.Direction);
                        _currentPosition.Add(new Position2D()
                        {
                            X = _currentPosition.X + coords.x,
                            Y = _currentPosition.Y + coords.y,
                            Direction = _currentPosition.Direction
                        });
                        _currentPosition = _currentPosition.Last;
                        break;
                    case MoveCommand.Right:
                    case MoveCommand.Left:
                        _currentPosition.Direction = MachineUtility.GetDirectionByOrientation(command, _currentPosition.Direction);
                        break;
                    default:
                        throw new ArgumentException("Command is not specified");
                }
            }
        }

        protected virtual void OnParameterAdded(object sender, ParameterEventArgs args)
        {
            IParameter parameter = args.Parameter;
            if (parameter.Name == nameof(PositionParameter))
            {
                InitCurrentPosition(parameter as PositionParameter);
            }
            if(parameter.Name == nameof(MoveCommandsParameter))
            {
                InitMoveCommandsParameter(parameter as MoveCommandsParameter);
            }
            _parameters.Add(parameter);
        }

        protected virtual void RegisterEvents()
        {
            _panel.OnParameterAdded += OnParameterAdded;
        }

        protected virtual void InitCurrentPosition(PositionParameter parameter)
        {
            _currentPosition = new Position2D()
            {
                X = parameter.X,
                Y = parameter.Y,
                Direction = MachineUtility.GetDirection(parameter.Direction)
            };
        }

        protected virtual void InitMoveCommandsParameter(MoveCommandsParameter parameter)
        {
            foreach (var cmd in parameter.Commands)
                _commands.Add(MachineUtility.GetMoveCommand(cmd));
        }
    }

    /// <summary>
    /// <see cref="IMachine"/> directions
    /// </summary>
    public enum Direction
    {
        North,
        West,
        South,
        East
    }

    /// <summary>
    /// <see cref="IMachine"/> commads
    /// </summary>
    public enum MoveCommand
    {
        Left,
        Right,
        Move
    };
}
