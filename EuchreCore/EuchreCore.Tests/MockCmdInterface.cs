using System;
using System.Collections.Generic;
using EuchreCore.Interface;

namespace EuchreCore.Tests
{
    public class MockCmdInterface : CmdInterface
    {
        public List<string> inputs = new List<string>(); 

        public override void SendOutput(string str)
        {
        }

        public override string GetInputLine()
        {
            string str = inputs[0];
            inputs.RemoveAt(0);
            return str;
        }
    }
}
