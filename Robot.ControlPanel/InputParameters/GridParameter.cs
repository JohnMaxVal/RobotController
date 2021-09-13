using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Robot.ControlPanel.Validator;

namespace Robot.ControlPanel.InputParameters
{
    /// <summary>
    /// Grid settings parameter
    /// </summary>
    [ValidateParameter(@"^\d+\s\d+$")]
    public class GridParameter : BaseParameter
    {
        /// <summary>
        /// Name of grid parameter
        /// </summary>
        public override string Name => nameof(GridParameter);

        /// <summary>
        /// Maximum row baoundary
        /// </summary>
        private int _rows;
        public int Rows => _rows;

        /// <summary>
        /// Maximum column boundary
        /// </summary>
        private int _columns;
        public int Columns => _columns;

        /// <summary>
        /// Set parsed input parameters
        /// </summary>
        /// <param name="input"></param>
        public override void Set(string input)
        {
            _rows = int.Parse(GetInputValues(input)[0]);
            _columns = int.Parse(GetInputValues(input)[1]);
        }
    }
}
