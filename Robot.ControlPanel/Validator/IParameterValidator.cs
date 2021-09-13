using Robot.ControlPanel.InputParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.ControlPanel.Validator
{
    /// <summary>
    /// Behaviour for validating input parameter
    /// </summary>
    public interface IParameterValidator<T> where T : IParameter
    {
        /// <summary>
        /// Check whether input parameter is valid
        /// </summary>
        /// <param name="input">Input parameter for validating</param>
        /// <returns></returns>
        public T Validate(string input);
    }
}
