using System;
using System.Collections.Generic;
using System.Text;
using Robot.ControlPanel.Validator;

namespace Robot.ControlPanel.InputParameters
{
    /// <summary>
    /// Provide basic parameter behaviour
    /// </summary>
    public interface IParameter: IParameterValidator<IParameter>
    {
        /// <summary>
        /// Parameter name of <see cref="IParameter"/> instance
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Handle input parameter
        /// </summary>
        /// <param name="input">Input setting paramter</param>
        public void Set(string input);
    }
}
