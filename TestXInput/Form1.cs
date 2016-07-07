// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="">
//   
// </copyright>
// <summary>
//   The form 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestXInput {
    using System;
    using System.Drawing;
    using System.Media;
    using System.Windows.Forms;

    using SharpDX.DirectInput;

    using TestXInput.Controller;
    using TestXInput.Properties;

    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class Form1 : Form {
        /// <summary>
        /// The click sound.
        /// </summary>
        private readonly SoundPlayer clickSound;

        /// <summary>
        /// The direct input.
        /// </summary>
        private readonly DirectInput directInput;

        /// <summary>
        /// The guitar controller.
        /// </summary>
        private GuitarController guitarController;

        /// <summary>
        /// The guitar strum alpha.
        /// </summary>
        private int guitarStrumAlpha = 255;

        /// <summary>
        /// The keyboard controller.
        /// </summary>
        private KeyboardController keyboardController;

        /// <summary>
        /// The keyboard strum alpha.
        /// </summary>
        private int keyboardStrumAlpha = 255;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1() {
            this.InitializeComponent();

            this.clickSound = new SoundPlayer(Resources.Yamaha_RX15_Rimshot);

            this.keyboardStrumPanel.BackColor = Color.FromArgb(0, 0, 0, 0);
            this.guitarStrumPanel.BackColor = Color.FromArgb(0, 0, 0, 0);

            this.directInput = new DirectInput();
        }

        /// <summary>
        /// The keyboard_ on strum.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="controllerEventArgs">
        /// The controller event args.
        /// </param>
        private void Keyboard_OnStrum(object sender, ControllerEventArgs controllerEventArgs) {
            this.keyboardStrumAlpha = 255;
            this.timerClickFade.Start();
            this.clickSound.Play();
        }

        /// <summary>
        /// The guitar_ on strum.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="controllerEventArgs">
        /// The controller event args.
        /// </param>
        private void Guitar_OnStrum(object sender, ControllerEventArgs controllerEventArgs) {
            this.guitarStrumAlpha = 255;
            this.timerClickFade.Start();
            this.clickSound.Play();
        }

        /// <summary>
        /// The keyboard_ on fret change.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="controllerEventArgs">
        /// The controller event args.
        /// </param>
        private void Keyboard_OnFretChange(object sender, ControllerEventArgs controllerEventArgs) {
            var buttons = controllerEventArgs.ButtonsPressed;
            this.keyboardGreenPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Green) == 0 ? 0 : 255, 
                Color.Green);
            this.keyboardRedPanel.BackColor = Color.FromArgb((buttons & ControllerButton.Red) == 0 ? 0 : 255, Color.Red);
            this.keyboardYellowPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Yellow) == 0 ? 0 : 255, 
                Color.Yellow);
            this.keyboardBluePanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Blue) == 0 ? 0 : 255, 
                Color.Blue);
            this.keyboardOrangePanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Orange) == 0 ? 0 : 255, 
                Color.Orange);
        }

        /// <summary>
        /// The guitar_ on fret change.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="controllerEventArgs">
        /// The controller event args.
        /// </param>
        private void Guitar_OnFretChange(object sender, ControllerEventArgs controllerEventArgs) {
            var buttons = controllerEventArgs.ButtonsPressed;
            this.guitarGreenPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Green) == 0 ? 0 : 255, 
                Color.Green);
            this.guitarRedPanel.BackColor = Color.FromArgb((buttons & ControllerButton.Red) == 0 ? 0 : 255, Color.Red);
            this.guitarYellowPanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Yellow) == 0 ? 0 : 255, 
                Color.Yellow);
            this.guitarBluePanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Blue) == 0 ? 0 : 255, 
                Color.Blue);
            this.guitarOrangePanel.BackColor = Color.FromArgb(
                (buttons & ControllerButton.Orange) == 0 ? 0 : 255, 
                Color.Orange);
        }

        /// <summary>
        /// The form 1_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Form1_Load(object sender, EventArgs e) {
            this.keyboardController = new KeyboardController(this.directInput);
            this.keyboardController.Bindings.Add(Key.Up, ControllerButton.DUp);
            this.keyboardController.Bindings.Add(Key.Down, ControllerButton.DDown);
            this.keyboardController.Bindings.Add(Key.Left, ControllerButton.DLeft);
            this.keyboardController.Bindings.Add(Key.Right, ControllerButton.DRight);
            this.keyboardController.Bindings.Add(Key.Z, ControllerButton.Green);
            this.keyboardController.Bindings.Add(Key.X, ControllerButton.Red);
            this.keyboardController.Bindings.Add(Key.C, ControllerButton.Yellow);
            this.keyboardController.Bindings.Add(Key.V, ControllerButton.Blue);
            this.keyboardController.Bindings.Add(Key.B, ControllerButton.Orange);
            this.keyboardController.Bindings.Add(Key.Return, ControllerButton.Start);
            this.keyboardController.Bindings.Add(Key.RightShift, ControllerButton.Select);

            this.keyboardController.OnStrum += this.Keyboard_OnStrum;
            this.keyboardController.OnFretChange += this.Keyboard_OnFretChange;

            try {
                this.guitarController = new GuitarController();
                this.guitarController.OnStrum += this.Guitar_OnStrum;
                this.guitarController.OnFretChange += this.Guitar_OnFretChange;
            }
            catch (NullReferenceException ex) {
                MessageBox.Show(ex.Message);
            }

            this.timerControllerUpdate.Start();
        }

        /// <summary>
        /// The update timer tick.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UpdateTimerTick(object sender, EventArgs e) {
            this.keyboardController.Update();
            this.guitarController?.Update();
        }

        /// <summary>
        /// The fade timer tick.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FadeTimerTick(object sender, EventArgs e) {
            this.guitarStrumAlpha -= 10;
            this.keyboardStrumAlpha -= 10;
            if (this.guitarStrumAlpha <= 0 && this.keyboardStrumAlpha <= 0) {
                this.timerClickFade.Stop();
            }

            if (this.guitarStrumAlpha < 0) {
                this.guitarStrumAlpha = 0;
            }

            if (this.keyboardStrumAlpha < 0) {
                this.keyboardStrumAlpha = 0;
            }

            this.keyboardStrumPanel.BackColor = Color.FromArgb(this.keyboardStrumAlpha, Color.Black);
            this.guitarStrumPanel.BackColor = Color.FromArgb(this.guitarStrumAlpha, Color.Black);
        }
    }
}