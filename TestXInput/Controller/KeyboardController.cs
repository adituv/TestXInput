// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyboardController.cs" company="">
//   
// </copyright>
// <summary>
//   The keyboard controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestXInput.Controller {
    using System.Collections.Generic;

    using SharpDX.DirectInput;

    /// <summary>
    /// The keyboard controller.
    /// </summary>
    public sealed class KeyboardController : Controller {
        /// <summary>
        /// The keyboard.
        /// </summary>
        private readonly Keyboard keyboard;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardController"/> class.
        /// </summary>
        /// <param name="dInput">
        /// The d input.
        /// </param>
        public KeyboardController(DirectInput dInput) {
            this.keyboard = new Keyboard(dInput);
            this.Bindings = new Dictionary<Key, ControllerButton>();
            this.keyboard.Properties.BufferSize = 128;
            this.keyboard.Acquire();

            this.TiltState = 0.0f;
            this.WhammyState = 0.0f;
            this.ButtonState = 0;
        }

        /// <summary>
        /// Gets the bindings.
        /// </summary>
        public Dictionary<Key, ControllerButton> Bindings { get; }

        /// <summary>
        /// The update.
        /// </summary>
        public override void Update() {
            this.keyboard.Poll();
            var data = this.keyboard.GetBufferedData();

            foreach (var d in data) {
                if (this.Bindings.ContainsKey(d.Key)) {
                    var b = this.Bindings[d.Key];
                    if (d.IsPressed) {
                        this.ButtonState |= b;
                    }
                    else {
                        this.ButtonState &= ~b;
                    }
                }
            }

            base.Update();
        }
    }
}