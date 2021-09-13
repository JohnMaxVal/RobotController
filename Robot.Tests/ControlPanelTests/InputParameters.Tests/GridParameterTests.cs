using NUnit.Framework;
using Robot.ControlPanel.InputParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Tests.ControlPanelTests.InputParameters.Tests
{
    [TestFixture]
    class GridParameterTests
    {
        private GridParameter _parameter;

        [SetUp]
        public void SetUp()
        {
            _parameter = new GridParameter();
        }

        [Test]
        public void GridParameter_Validate()
        {
            
        }
    }
}
