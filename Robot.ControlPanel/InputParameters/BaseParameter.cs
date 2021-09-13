using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Robot.ControlPanel.InputParameters
{
    using ValidateParameter = Validator.ValidateParameterAttribute;

    /// <summary>
    /// Provide basic parameter behaviour
    /// </summary>
    public abstract class BaseParameter: IParameter
    {
        /// <summary>
        /// Parameter name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Set input parameter value.
        /// If implementation of a derived class isn't specified then excpetion is thrown
        /// </summary>
        /// <param name="input"></param>
        public virtual void Set(string input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check whether input parameter is valid
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        IParameter Validator.IParameterValidator<IParameter>.Validate(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input parameter is empty");
            }
            if (!Regex.IsMatch(input, GetValidateParameterAttribute().Pattern))
            {
                throw new ArgumentException("Input parameter is not valid");
            }
            return this;
        }

        /// <summary>
        /// Parse input parameter value. If this method is not implemented by direvied class then exception is thrown
        /// </summary>
        /// <param name="input">Input parameter settings</param>
        /// <returns></returns>
        public virtual bool Parse(string input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get attribute for parameter validation
        /// </summary>
        /// <returns>ValidateParameterAttribute class</returns>
        protected virtual ValidateParameter GetValidateParameterAttribute()
        {
            Type thisType = this.GetType();
            Type validateAttrType = typeof(ValidateParameter);
            ValidateParameter validateAttr = Attribute.GetCustomAttribute(thisType, validateAttrType) as ValidateParameter;

            if (validateAttr == null)
            {
                throw new ArgumentNullException("Attribute is not specified");
            }

            return validateAttr;
        }

        // TODO: single responsibility

        /// <summary>
        /// Get splitted input values
        /// </summary>
        /// <param name="input">Input parameter setting</param>
        /// <returns>Array of input values</returns>
        protected string[] GetInputValues(string input)
        {
            return input.Split(' ');
        }
    }
}
