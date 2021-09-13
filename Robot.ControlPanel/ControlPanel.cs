using System;
using System.Collections;

namespace Robot.ControlPanel
{
    using InputParameters;
    using System.Collections.Generic;

    /// <summary>
    /// Handle I/O information of device
    /// </summary>
    public class ControlPanel
    {
        /// <summary>
        /// Provide callback handler after parameter added
        /// </summary>
        public event EventHandler<ParameterEventArgs> OnParameterAdded;

        /// <summary>
        /// Add new parameter value
        /// </summary>
        /// <typeparam name="T">BaseParameter</typeparam>
        /// <param name="param">Type of input instance parameter</param>
        /// <param name="input">Input data</param>
        public void AddParameter<T>(T param, string input) where T : IParameter
        {
            param.Validate(input).Set(input);
            SendParameter(param);
        }

        /// <summary>
        /// Send parameter to <see langword="IMachine"/> instance
        /// </summary>
        /// <param name="parameter"><see langword="IParameter" object/></param>
        private void SendParameter(IParameter parameter)
        {
            ParameterEventArgs args = new ParameterEventArgs(parameter);
            OnParameterAdded(this, args);
        }
    }
}
