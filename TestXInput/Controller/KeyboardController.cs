using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX.DirectInput;

namespace TestXInput.Controller
{
    public sealed class KeyboardController : Controller {
        public Dictionary<Key, ControllerButton> Bindings { get; }
        private Keyboard keyboard;

        public override void Update() {
            keyboard.Poll();
            var data = keyboard.GetBufferedData();

            foreach (var d in data) {
                if (Bindings.ContainsKey(d.Key)) {
                    ControllerButton b = Bindings[d.Key];
                    if (d.IsPressed) {
                        this.buttonState |= b;
                    }
                    else {
                        this.buttonState &= ~b;
                    }
                }
            }
            base.Update();
        }

        public KeyboardController(DirectInput dInput) {
            this.keyboard = new Keyboard(dInput);
            this.Bindings = new Dictionary<Key, ControllerButton>();
            this.keyboard.Properties.BufferSize = 128;
            this.keyboard.Acquire();

            this.tiltState = 0.0f;
            this.whammyState = 0.0f;
            this.buttonState = 0;
        }
    }
}
