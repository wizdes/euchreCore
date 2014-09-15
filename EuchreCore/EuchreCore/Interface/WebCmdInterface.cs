using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EuchreCore.Interface
{
    public class WebCmdInterface : CmdInterface
    {
        private AutoResetEvent waitHandle = new AutoResetEvent(false);

        private string inputLine;

        public string currentOutput;

        public bool isWaiting = false;

        public void setInputRelease(string input)
        {
            isWaiting = false;
            inputLine = input;
            waitHandle.Set();
        }

        public override void SendOutput(string str)
        {
            currentOutput = str;
        }

        public override string GetInputLine()
        {
            isWaiting = true;
            waitHandle.WaitOne();
            string returningInput = inputLine;
            inputLine = "";
            return returningInput;
        }
    }
}
