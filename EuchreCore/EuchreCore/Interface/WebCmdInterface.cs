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
        private AutoResetEvent waitHandle = new AutoResetEvent(true);

        private string inputLine;

        public void setInputRelease(string input)
        {
            inputLine = input;
            waitHandle.Set();
        }

        public override void SendOutput(string str)
        {
            //throw new NotImplementedException();
        }

        public override string GetInputLine()
        {
            waitHandle.WaitOne();
            string returningInput = inputLine;
            inputLine = "";
            return returningInput;
            //throw new NotImplementedException();
        }
    }
}
