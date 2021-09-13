using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Device
{
    using Robot.ControlPanel.InputParameters;

    /// <summary>
    /// Provides basic machine behaviour
    /// </summary>
    public interface IMachine
    {
        /// <summary>
        /// Define machine's movement behaviour
        /// </summary>
        public void Move();
    }
}
