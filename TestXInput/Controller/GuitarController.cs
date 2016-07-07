using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX.XInput;
using XController = SharpDX.XInput.Controller;

namespace TestXInput.Controller
{
    public sealed class GuitarController : Controller {
        private XController controller;

        private State oldControllerState;

        public override void Update() {
            State controllerState = controller.GetState();

            if (oldControllerState.PacketNumber != controllerState.PacketNumber) {
                var buttons = controllerState.Gamepad.Buttons;

                this.buttonState = 0;
                if ((buttons & GamepadButtonFlags.A) != 0) {
                    this.buttonState |= ControllerButton.Green;
                }
                if ((buttons & GamepadButtonFlags.B) != 0) {
                    this.buttonState |= ControllerButton.Red;
                }
                if ((buttons & GamepadButtonFlags.Y) != 0) {
                    this.buttonState |= ControllerButton.Yellow;
                }
                if ((buttons & GamepadButtonFlags.X) != 0) {
                    this.buttonState |= ControllerButton.Blue;
                }
                if ((buttons & GamepadButtonFlags.LeftShoulder) != 0) {
                    this.buttonState |= ControllerButton.Orange;
                }
                if ((buttons & GamepadButtonFlags.DPadDown) != 0) {
                    this.buttonState |= ControllerButton.DDown;
                }
                if ((buttons & GamepadButtonFlags.DPadUp) != 0) {
                    this.buttonState |= ControllerButton.DUp;
                }
                if ((buttons & GamepadButtonFlags.DPadLeft) != 0) {
                    this.buttonState |= ControllerButton.DLeft;
                }
                if ((buttons & GamepadButtonFlags.DPadRight) != 0) {
                    this.buttonState |= ControllerButton.DRight;
                }
                if ((buttons & GamepadButtonFlags.Back) != 0) {
                    this.buttonState |= ControllerButton.Select;
                }
                if ((buttons & GamepadButtonFlags.Start) != 0) {
                    this.buttonState |= ControllerButton.Start;
                }

                this.whammyState = controllerState.Gamepad.RightThumbX / 32768.0f;
                this.tiltState = controllerState.Gamepad.RightThumbY / 32768.0f;
            }

            oldControllerState = controllerState;
            base.Update();
        }

        public GuitarController(UserIndex index = UserIndex.Any) {
            if (index == UserIndex.Any) {
                var controllers = new XController[]
                                  {
                                      new XController(UserIndex.One), new XController(UserIndex.Two),
                                      new XController(UserIndex.Three), new XController(UserIndex.Four)
                                  };
                controller = controllers.FirstOrDefault(c => c.IsConnected);
            }
            else {
                controller = new XController(index);
            }
            if (controller == null) throw new NullReferenceException("No guitar controller found.");

            oldControllerState = controller.GetState();
        }
    }
}
