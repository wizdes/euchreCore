using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.Interface
{
    abstract public class Interface
    {
        abstract internal void SendOutput();

        internal abstract string GetInputLine();
    }
}
