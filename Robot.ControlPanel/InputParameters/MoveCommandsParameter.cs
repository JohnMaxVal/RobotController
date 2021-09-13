using System;
using System.Collections.Generic;
using System.Text;
using Robot.ControlPanel.Validator;

namespace Robot.ControlPanel.InputParameters
{
    /// <summary>
    /// Provides movement plan parameter
    /// </summary>
    [ValidateParameter(@"^[LRM]+$")]
    public class MoveCommandsParameter : BaseParameter
    {
        /// <summary>
        /// Name of <see langword="MovementPlanParameter""/> instance
        /// </summary>
        public override string Name => nameof(MoveCommandsParameter);

        /// <summary>
        /// Parameter value
        /// </summary>
        private string _commands;
        public string Commands => _commands;

        /// <summary>
        /// Provides input parameter setting for <see cref="MoveCommandsParameter"/> instance
        /// </summary>
        /// <param name="input"></param>
        public override void Set(string input)
        {
            _commands = input;
        }
    }
}
