using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXInput.Controller
{
    public abstract class Controller {
        public const float TiltThreshold = 0.7f;

        public const float WhammyThreshold = 0.1f;

        public event ControllerEventHandler OnFretChange;

        public event ControllerEventHandler OnStrum;

        public event ControllerEventHandler OnTilt;

        public event ControllerEventHandler OnButtonDown;

        public event ControllerEventHandler OnButtonUp;

        public event ControllerEventHandler OnWhammyChange;

        public virtual void Update() {
            bool fretChanged = (((int)buttonState ^ (int)oldButtonState) & 0x1F) != 0;
            bool buttonPressed = ((int)buttonState & ~((int)oldButtonState)) != 0;
            bool buttonReleased = ((int)oldButtonState & ~((int)buttonState)) != 0;
            bool strummed = ((int)buttonState & ~(int)oldButtonState & (int)(ControllerButton.DDown | ControllerButton.DUp)) != 0;
            bool tilted = oldTiltState < TiltThreshold && tiltState > TiltThreshold;
            bool whammyChanged = Math.Abs(whammyState - oldWhammyState) > WhammyThreshold;
            ControllerEventArgs args = new ControllerEventArgs();

            args.ButtonsPressed = buttonState;
            args.WhammyState = whammyState;

            if (fretChanged && this.OnFretChange != null) {
                this.OnFretChange(this, args);
            }
            if (buttonPressed && this.OnButtonDown != null) {
                this.OnButtonDown(this, args);
            }
            if (buttonReleased && this.OnButtonUp != null) {
                this.OnButtonUp(this, args);
            }
            if (strummed && this.OnStrum != null) {
                this.OnStrum(this, args);
            }
            if (tilted && this.OnTilt != null) {
                this.OnTilt(this, args);
            }
            if (whammyChanged && this.OnWhammyChange != null) {
                this.OnWhammyChange(this, args);
            }

            oldButtonState = buttonState;
            oldTiltState = tiltState;
            oldWhammyState = whammyState;
        }

        private ControllerButton oldButtonState;
        protected ControllerButton buttonState;

        private float oldTiltState;
        protected float tiltState;

        private float oldWhammyState;
        protected float whammyState;

        public static bool IsFretButton(ControllerButton b) {
            return ((int) b & 0x1F) != 0;
        }
    }

    [Flags]
    public enum ControllerButton {
        Green  = 0x0001,
        Red    = 0x0002,
        Yellow = 0x0004,
        Blue   = 0x0008,
        Orange = 0x0010,
        Start  = 0x0020,
        Select = 0x0040,
        DUp    = 0x0080,
        DDown  = 0x0100,
        DLeft  = 0x0200,
        DRight = 0x0400
    }

    public delegate void ControllerEventHandler(object sender, ControllerEventArgs e);
}
