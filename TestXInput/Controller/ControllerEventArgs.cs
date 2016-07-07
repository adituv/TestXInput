using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXInput.Controller
{
    public class ControllerEventArgs : EventArgs
    {
        public ControllerButton ButtonsPressed { get; set; }
        public float WhammyState { get; set; }
    }
}
