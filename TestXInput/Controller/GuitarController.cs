// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuitarController.cs" company="">
//   
// </copyright>
// <summary>
//   The guitar controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using XController = SharpDX.XInput.Controller;

namespace TestXInput.Controller {
    using System;
    using System.Linq;

    using SharpDX;
    using SharpDX.XInput;

    /// <summary>
    /// The guitar controller.
    /// </summary>
    public sealed class GuitarController : Controller {
        /// <summary>
        /// The controller.
        /// </summary>
        private readonly XController controller;

        /// <summary>
        /// The last packet number.
        /// </summary>
        private int lastPacketNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuitarController"/> class.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <exception cref="NullReferenceException">
        /// </exception>
        public GuitarController(UserIndex index = UserIndex.Any) {
            if (index == UserIndex.Any) {
                var controllers = new[]
                                  {
                                      new XController(UserIndex.One), new XController(UserIndex.Two), 
                                      new XController(UserIndex.Three), new XController(UserIndex.Four)
                                  };
                this.controller = controllers.FirstOrDefault(c => c.IsConnected && IsGuitarController(c));
            }
            else {
                this.controller = new XController(index);
            }

            if (this.controller == null) {
                throw new NullReferenceException("No guitar controller found.");
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <exception cref="SharpDXException">
        /// Getting the controller state fails.
        /// </exception>
        public override void Update() {
            State controllerState;
            try {
                controllerState = this.controller.GetState();
            }
            catch (SharpDXException ex) {
                if (ex.ResultCode == ResultCode.NotConnected) {
                    this.Connected = false;
                }
                else {
                    throw;
                }

                return;
            }

            if (this.lastPacketNumber != controllerState.PacketNumber) {
                var buttons = controllerState.Gamepad.Buttons;

                this.ButtonState = 0;
                if ((buttons & GamepadButtonFlags.A) != 0) {
                    this.ButtonState |= ControllerButton.Green;
                }

                if ((buttons & GamepadButtonFlags.B) != 0) {
                    this.ButtonState |= ControllerButton.Red;
                }

                if ((buttons & GamepadButtonFlags.Y) != 0) {
                    this.ButtonState |= ControllerButton.Yellow;
                }

                if ((buttons & GamepadButtonFlags.X) != 0) {
                    this.ButtonState |= ControllerButton.Blue;
                }

                if ((buttons & GamepadButtonFlags.LeftShoulder) != 0) {
                    this.ButtonState |= ControllerButton.Orange;
                }

                if ((buttons & GamepadButtonFlags.DPadDown) != 0) {
                    this.ButtonState |= ControllerButton.DDown;
                }

                if ((buttons & GamepadButtonFlags.DPadUp) != 0) {
                    this.ButtonState |= ControllerButton.DUp;
                }

                if ((buttons & GamepadButtonFlags.DPadLeft) != 0) {
                    this.ButtonState |= ControllerButton.DLeft;
                }

                if ((buttons & GamepadButtonFlags.DPadRight) != 0) {
                    this.ButtonState |= ControllerButton.DRight;
                }

                if ((buttons & GamepadButtonFlags.Back) != 0) {
                    this.ButtonState |= ControllerButton.Select;
                }

                if ((buttons & GamepadButtonFlags.Start) != 0) {
                    this.ButtonState |= ControllerButton.Start;
                }

                this.WhammyState = controllerState.Gamepad.RightThumbX / 32768.0f;
                this.TiltState = controllerState.Gamepad.RightThumbY / 32768.0f;
            }

            this.lastPacketNumber = controllerState.PacketNumber;
            base.Update();
        }

        /// <summary>
        /// The is guitar controller.
        /// </summary>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsGuitarController(XController c) {
            var subtype = c.GetCapabilities(DeviceQueryType.Any).SubType;

            return subtype == DeviceSubType.Guitar || subtype == DeviceSubType.GuitarAlternate
                    || subtype == DeviceSubType.GuitarBass;
        }
    }
}