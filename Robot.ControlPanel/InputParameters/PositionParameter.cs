using System;
using System.Collections.Generic;
using System.Text;
using Robot.ControlPanel.Validator;

namespace Robot.ControlPanel.InputParameters
{
    /// <summary>
    /// Provide parameter of starting position
    /// </summary>
    [ValidateParameter(@"^\d+\s\d+\s[NEWS]$")]
    public class PositionParameter : BaseParameter
    {
        /// <summary>
        /// Name of position parameter
        /// </summary>
        public override string Name => nameof(PositionParameter);

        /// <summary>
        /// X coordinate of current position
        /// </summary>
        private int _x;
        public int X => _x;

        /// <summary>
        /// Y coordinate of current position
        /// </summary>
        private int _y;
        public int Y => _y;

        /// <summary>
        /// Direction of current position
        /// </summary>
        private char _direction;
        public char Direction => _direction;

        public override void Set(string input)
        {
            _x = int.Parse(GetInputValues(input)[0]);
            _y = int.Parse(GetInputValues(input)[1]);
            _direction = char.Parse(GetInputValues(input)[2]);
        }
    }
}
