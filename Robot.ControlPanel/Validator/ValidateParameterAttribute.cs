using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.ControlPanel.Validator
{
    /// <summary>
    /// Provide parameter validation by specified pattern
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidateParameterAttribute: System.Attribute
    {
        /// <summary>
        /// Regular expression for validating input
        /// </summary>
        public string Pattern { get; }

        public ValidateParameterAttribute(string pattern)
        {
            Pattern = pattern;
        }
    }
}
