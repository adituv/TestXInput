// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Controller.cs" company="Aditu">
//   Copyright (c) 2016 Iris Ward
// </copyright>
// <summary>
//   The controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestXInput.Controller {
    using System;

    /// <summary>
    /// The controller.
    /// </summary>
    public abstract class Controller {
        /// <summary>
        /// The tilt threshold.
        /// </summary>
        public const float TiltThreshold = 0.7f;

        /// <summary>
        /// The whammy threshold.
        /// </summary>
        public const float WhammyThreshold = 0.1f;

        /// <summary>
        /// The old button state.
        /// </summary>
        private ControllerButton oldButtonState;

        /// <summary>
        /// The old tilt state.
        /// </summary>
        private float oldTiltState;

        /// <summary>
        /// The old whammy state.
        /// </summary>
        private float oldWhammyState;

        /// <summary>
        /// Gets or sets a value indicating whether connected.
        /// </summary>
        public bool Connected { get; protected set; }

        /// <summary>
        /// Gets or sets the button state.
        /// </summary>
        protected ControllerButton ButtonState { get; set; }

        /// <summary>
        /// Gets or sets the tilt state.
        /// </summary>
        protected float TiltState { get; set; }

        /// <summary>
        /// Gets or sets the whammy state.
        /// </summary>
        protected float WhammyState { get; set; }

        /// <summary>
        /// The strum override.
        /// </summary>
        protected virtual bool StrumOverride => true;

        /// <summary>
        /// The on fret change.
        /// </summary>
        public event ControllerEventHandler OnFretChange;

        /// <summary>
        /// The on strum.
        /// </summary>
        public event ControllerEventHandler OnStrum;

        /// <summary>
        /// The on tilt.
        /// </summary>
        public event ControllerEventHandler OnTilt;

        /// <summary>
        /// The on button down.
        /// </summary>
        public event ControllerEventHandler OnButtonDown;

        /// <summary>
        /// The on button up.
        /// </summary>
        public event ControllerEventHandler OnButtonUp;

        /// <summary>
        /// The on whammy change.
        /// </summary>
        public event ControllerEventHandler OnWhammyChange;

        /// <summary>
        /// The update.
        /// </summary>
        public virtual void Update() {
            var fretsChanged = (int)(this.ButtonState ^ this.oldButtonState) & 0x1F;
            var buttonsPressed = (int)(this.ButtonState & ~this.oldButtonState);
            var buttonsReleased = (int)(this.oldButtonState & ~this.ButtonState);
            var tiltDelta = this.TiltState - this.oldTiltState;
            var whammyDelta = this.WhammyState - this.oldWhammyState;
            var strummed = this.StrumOverride || (this.ButtonState & ControllerButton.DUp) != 0
                           || (this.ButtonState & ControllerButton.DDown) != 0;

            var args = new ControllerEventArgs
                       {
                           ButtonsPressed = (ControllerButton)buttonsPressed, 
                           ButtonsReleased = (ControllerButton)buttonsReleased, 
                           TiltDelta = tiltDelta, 
                           WhammyDelta = whammyDelta
                       };

            if (fretsChanged != 0 && this.OnFretChange != null) {
                this.OnFretChange(this, args);
            }

            if (buttonsPressed != 0 && this.OnButtonDown != null) {
                this.OnButtonDown(this, args);
            }

            if (buttonsReleased != 0 && this.OnButtonUp != null) {
                this.OnButtonUp(this, args);
            }

            if (strummed && this.OnStrum != null) {
                this.OnStrum(this, args);
            }

            if (Math.Abs(tiltDelta) > TiltThreshold && this.OnTilt != null) {
                this.OnTilt(this, args);
            }

            if (Math.Abs(whammyDelta) > WhammyThreshold && this.OnWhammyChange != null) {
                this.OnWhammyChange(this, args);
            }

            this.oldButtonState = this.ButtonState;
            this.oldTiltState = this.TiltState;
            this.oldWhammyState = this.WhammyState;
        }

        /// <summary>
        /// The is fret button.
        /// </summary>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsFretButton(ControllerButton b) {
            return ((int)b & 0x1F) != 0;
        }
    }

    /// <summary>
    /// The controller button.
    /// </summary>
    [Flags]
    public enum ControllerButton {
        /// <summary>
        /// The green.
        /// </summary>
        Green = 0x0001, 

        /// <summary>
        /// The red.
        /// </summary>
        Red = 0x0002, 

        /// <summary>
        /// The yellow.
        /// </summary>
        Yellow = 0x0004, 

        /// <summary>
        /// The blue.
        /// </summary>
        Blue = 0x0008, 

        /// <summary>
        /// The orange.
        /// </summary>
        Orange = 0x0010, 

        /// <summary>
        /// The start.
        /// </summary>
        Start = 0x0020, 

        /// <summary>
        /// The select.
        /// </summary>
        Select = 0x0040, 

        /// <summary>
        /// The d up.
        /// </summary>
        DUp = 0x0080, 

        /// <summary>
        /// The d down.
        /// </summary>
        DDown = 0x0100, 

        /// <summary>
        /// The d left.
        /// </summary>
        DLeft = 0x0200, 

        /// <summary>
        /// The d right.
        /// </summary>
        DRight = 0x0400
    }

    /// <summary>
    /// The controller event handler.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    public delegate void ControllerEventHandler(object sender, ControllerEventArgs e);
}