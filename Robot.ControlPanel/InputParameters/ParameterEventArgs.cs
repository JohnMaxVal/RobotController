using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.ControlPanel.InputParameters
{
    public class ParameterEventArgs : EventArgs
    {
        private IParameter _parameter;
        public IParameter Parameter => _parameter;

        public ParameterEventArgs(IParameter parameter)
        {
            _parameter = parameter;
        }
    }
}
