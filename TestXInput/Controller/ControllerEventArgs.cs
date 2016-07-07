// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerEventArgs.cs" company="">
//   
// </copyright>
// <summary>
//   The controller event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestXInput.Controller {
    using System;

    /// <summary>
    /// The controller event args.
    /// </summary>
    public class ControllerEventArgs : EventArgs {
        /// <summary>
        /// Gets or sets the buttons pressed.
        /// </summary>
        public ControllerButton ButtonsPressed { get; set; }

        /// <summary>
        /// Gets or sets the buttons released.
        /// </summary>
        public ControllerButton ButtonsReleased { get; set; }

        /// <summary>
        /// Gets or sets the tilt delta.
        /// </summary>
        public float TiltDelta { get; set; }

        /// <summary>
        /// Gets or sets the whammy delta.
        /// </summary>
        public float WhammyDelta { get; set; }
    }
}