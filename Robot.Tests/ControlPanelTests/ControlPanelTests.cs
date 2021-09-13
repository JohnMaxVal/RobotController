using NUnit.Framework;
using Robot.ControlPanel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Tests.ControlPanelTests
{
    //
    using Panel = ControlPanel.ControlPanel;

    [TestFixture]
    class ControlPanelTests
    {
        private Panel _panel;

        [SetUp]
        public void Setup()
        {
            _panel = new Panel();
        }
    }
}
