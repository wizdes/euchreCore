using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.Interface
{
    public class CommandLineInterface : Interface
    {
        internal override void SendOutput()
        {
            throw new NotImplementedException();
        }

        internal override string GetInputLine()
        {
            throw new NotImplementedException();
        }
    }
}
