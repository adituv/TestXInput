using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpDX.DirectInput;
using TestXInput.Controller;

namespace TestXInput
{
    using System.Media;

    public partial class Form1 : Form {
        private KeyboardController keyboardController;
        private GuitarController guitarController;

        private DirectInput directInput;

        private int guitarStrumAlpha = 255;

        private int keyboardStrumAlpha = 255;

        private SoundPlayer clickSound;

        public Form1() {
            InitializeComponent();

            clickSound = new SoundPlayer(Properties.Resources.Yamaha_RX15_Rimshot);

            keyboardStrumPanel.BackColor = Color.FromArgb(0, 0, 0, 0);
            guitarStrumPanel.BackColor = Color.FromArgb(0, 0, 0 , 0);

            directInput = new DirectInput();
        }

        private void Keyboard_OnStrum(object sender, ControllerEventArgs controllerEventArgs) {
            this.keyboardStrumAlpha = 255;
            timerClickFade.Start();
            clickSound.Play();
        }

        private void Guitar_OnStrum(object sender, ControllerEventArgs controllerEventArgs) {
            this.guitarStrumAlpha = 255;
            timerClickFade.Start();
            clickSound.Play();
        }

        private void Keyboard_OnFretChange(object sender, ControllerEventArgs controllerEventArgs) {
            ControllerButton buttons = controllerEventArgs.ButtonsPressed;
            keyboardGreenPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Green) == 0 ? 0 : 255,
                Color.Green);
            keyboardRedPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Red) == 0 ? 0 : 255,
                Color.Red);
            keyboardYellowPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Yellow) == 0 ? 0 : 255,
                Color.Yellow);
            keyboardBluePanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Blue) == 0 ? 0 : 255,
                Color.Blue);
            keyboardOrangePanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Orange) == 0 ? 0 : 255,
                Color.Orange);
        }

        private void Guitar_OnFretChange(object sender, ControllerEventArgs controllerEventArgs) {
            ControllerButton buttons = controllerEventArgs.ButtonsPressed;
            guitarGreenPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Green) == 0 ? 0 : 255,
                Color.Green);
            guitarRedPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Red) == 0 ? 0 : 255,
                Color.Red);
            guitarYellowPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Yellow) == 0 ? 0 : 255,
                Color.Yellow);
            guitarBluePanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Blue) == 0 ? 0 : 255,
                Color.Blue);
            guitarOrangePanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Orange) == 0 ? 0 : 255,
                Color.Orange);
        }

        private void Form1_Load(object sender, EventArgs e) {
            keyboardController = new KeyboardController(directInput);
            keyboardController.Bindings.Add(Key.Up, ControllerButton.DUp);
            keyboardController.Bindings.Add(Key.Down, ControllerButton.DDown);
            keyboardController.Bindings.Add(Key.Left, ControllerButton.DLeft);
            keyboardController.Bindings.Add(Key.Right, ControllerButton.DRight);
            keyboardController.Bindings.Add(Key.Z, ControllerButton.Green);
            keyboardController.Bindings.Add(Key.X, ControllerButton.Red);
            keyboardController.Bindings.Add(Key.C, ControllerButton.Yellow);
            keyboardController.Bindings.Add(Key.V, ControllerButton.Blue);
            keyboardController.Bindings.Add(Key.B, ControllerButton.Orange);
            keyboardController.Bindings.Add(Key.Return, ControllerButton.Start);
            keyboardController.Bindings.Add(Key.RightShift, ControllerButton.Select);

            keyboardController.OnStrum += Keyboard_OnStrum;
            keyboardController.OnFretChange += Keyboard_OnFretChange;

            try {
                guitarController = new GuitarController();
                guitarController.OnStrum += Guitar_OnStrum;
                guitarController.OnFretChange += Guitar_OnFretChange;
            }
            catch (NullReferenceException ex) {
                MessageBox.Show(ex.Message);
            }

            timerControllerUpdate.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            keyboardController.Update();
            guitarController?.Update();
        }

        private void timerClickFade_Tick(object sender, EventArgs e) {
            this.guitarStrumAlpha -= 10;
            this.keyboardStrumAlpha -= 10;
            if (this.guitarStrumAlpha <= 0 && this.keyboardStrumAlpha <= 0) {
                timerClickFade.Stop();
            }

            if (this.guitarStrumAlpha < 0) {
                this.guitarStrumAlpha = 0;
            }

            if (this.keyboardStrumAlpha < 0) {
                this.keyboardStrumAlpha = 0;
            }
            keyboardStrumPanel.BackColor = Color.FromArgb(this.keyboardStrumAlpha, Color.Black);
            guitarStrumPanel.BackColor = Color.FromArgb(this.guitarStrumAlpha, Color.Black);
        }
    }
}
