using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.Interface
{
    public enum IOType
    {
        AI,
        CmdLine,
        Web
    }

    abstract public class CmdInterface
    {
        abstract internal void SendOutput(string str);

        internal abstract string GetInputLine();

        public virtual bool isAI()
        {
            return false;
        }
    }
}
