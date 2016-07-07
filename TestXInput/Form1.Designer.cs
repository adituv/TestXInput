namespace TestXInput
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            this.timerControllerUpdate = new System.Windows.Forms.Timer(this.components);
            this.timerClickFade = new System.Windows.Forms.Timer(this.components);
            this.keyboardStrumPanel = new System.Windows.Forms.Panel();
            this.keyboardGreenPanel = new System.Windows.Forms.Panel();
            this.keyboardRedPanel = new System.Windows.Forms.Panel();
            this.keyboardYellowPanel = new System.Windows.Forms.Panel();
            this.keyboardBluePanel = new System.Windows.Forms.Panel();
            this.keyboardOrangePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.guitarOrangePanel = new System.Windows.Forms.Panel();
            this.guitarBluePanel = new System.Windows.Forms.Panel();
            this.guitarYellowPanel = new System.Windows.Forms.Panel();
            this.guitarRedPanel = new System.Windows.Forms.Panel();
            this.guitarGreenPanel = new System.Windows.Forms.Panel();
            this.guitarStrumPanel = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerControllerUpdate
            // 
            this.timerControllerUpdate.Interval = 5;
            this.timerControllerUpdate.Tick += new System.EventHandler(this.UpdateTimerTick);
            // 
            // timerClickFade
            // 
            this.timerClickFade.Interval = 15;
            this.timerClickFade.Tick += new System.EventHandler(this.FadeTimerTick);
            // 
            // keyboardStrumPanel
            // 
            this.keyboardStrumPanel.BackColor = System.Drawing.Color.Black;
            this.keyboardStrumPanel.Location = new System.Drawing.Point(70, 12);
            this.keyboardStrumPanel.Name = "keyboardStrumPanel";
            this.keyboardStrumPanel.Size = new System.Drawing.Size(32, 32);
            this.keyboardStrumPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 21);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 1;
            label1.Text = "Keyboard";
            // 
            // keyboardGreenPanel
            // 
            this.keyboardGreenPanel.BackColor = System.Drawing.Color.Green;
            this.keyboardGreenPanel.Location = new System.Drawing.Point(108, 12);
            this.keyboardGreenPanel.Name = "keyboardGreenPanel";
            this.keyboardGreenPanel.Size = new System.Drawing.Size(32, 32);
            this.keyboardGreenPanel.TabIndex = 1;
            // 
            // keyboardRedPanel
            // 
            this.keyboardRedPanel.BackColor = System.Drawing.Color.Red;
            this.keyboardRedPanel.Location = new System.Drawing.Point(146, 12);
            this.keyboardRedPanel.Name = "keyboardRedPanel";
            this.keyboardRedPanel.Size = new System.Drawing.Size(32, 32);
            this.keyboardRedPanel.TabIndex = 1;
            // 
            // keyboardYellowPanel
            // 
            this.keyboardYellowPanel.BackColor = System.Drawing.Color.Yellow;
            this.keyboardYellowPanel.Location = new System.Drawing.Point(184, 12);
            this.keyboardYellowPanel.Name = "keyboardYellowPanel";
            this.keyboardYellowPanel.Size = new System.Drawing.Size(32, 32);
            this.keyboardYellowPanel.TabIndex = 1;
            // 
            // keyboardBluePanel
            // 
            this.keyboardBluePanel.BackColor = System.Drawing.Color.Blue;
            this.keyboardBluePanel.Location = new System.Drawing.Point(222, 12);
            this.keyboardBluePanel.Name = "keyboardBluePanel";
            this.keyboardBluePanel.Size = new System.Drawing.Size(32, 32);
            this.keyboardBluePanel.TabIndex = 1;
            // 
            // keyboardOrangePanel
            // 
            this.keyboardOrangePanel.BackColor = System.Drawing.Color.Orange;
            this.keyboardOrangePanel.Location = new System.Drawing.Point(260, 12);
            this.keyboardOrangePanel.Name = "keyboardOrangePanel";
            this.keyboardOrangePanel.Size = new System.Drawing.Size(32, 32);
            this.keyboardOrangePanel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Guitar";
            // 
            // guitarOrangePanel
            // 
            this.guitarOrangePanel.BackColor = System.Drawing.Color.Orange;
            this.guitarOrangePanel.Location = new System.Drawing.Point(260, 50);
            this.guitarOrangePanel.Name = "guitarOrangePanel";
            this.guitarOrangePanel.Size = new System.Drawing.Size(32, 32);
            this.guitarOrangePanel.TabIndex = 3;
            // 
            // guitarBluePanel
            // 
            this.guitarBluePanel.BackColor = System.Drawing.Color.Blue;
            this.guitarBluePanel.Location = new System.Drawing.Point(222, 50);
            this.guitarBluePanel.Name = "guitarBluePanel";
            this.guitarBluePanel.Size = new System.Drawing.Size(32, 32);
            this.guitarBluePanel.TabIndex = 4;
            // 
            // guitarYellowPanel
            // 
            this.guitarYellowPanel.BackColor = System.Drawing.Color.Yellow;
            this.guitarYellowPanel.Location = new System.Drawing.Point(184, 50);
            this.guitarYellowPanel.Name = "guitarYellowPanel";
            this.guitarYellowPanel.Size = new System.Drawing.Size(32, 32);
            this.guitarYellowPanel.TabIndex = 5;
            // 
            // guitarRedPanel
            // 
            this.guitarRedPanel.BackColor = System.Drawing.Color.Red;
            this.guitarRedPanel.Location = new System.Drawing.Point(146, 50);
            this.guitarRedPanel.Name = "guitarRedPanel";
            this.guitarRedPanel.Size = new System.Drawing.Size(32, 32);
            this.guitarRedPanel.TabIndex = 6;
            // 
            // guitarGreenPanel
            // 
            this.guitarGreenPanel.BackColor = System.Drawing.Color.Green;
            this.guitarGreenPanel.Location = new System.Drawing.Point(108, 50);
            this.guitarGreenPanel.Name = "guitarGreenPanel";
            this.guitarGreenPanel.Size = new System.Drawing.Size(32, 32);
            this.guitarGreenPanel.TabIndex = 7;
            // 
            // guitarStrumPanel
            // 
            this.guitarStrumPanel.BackColor = System.Drawing.Color.Black;
            this.guitarStrumPanel.Location = new System.Drawing.Point(70, 50);
            this.guitarStrumPanel.Name = "guitarStrumPanel";
            this.guitarStrumPanel.Size = new System.Drawing.Size(32, 32);
            this.guitarStrumPanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 100);
            this.Controls.Add(this.guitarOrangePanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guitarBluePanel);
            this.Controls.Add(this.keyboardOrangePanel);
            this.Controls.Add(this.guitarYellowPanel);
            this.Controls.Add(this.keyboardBluePanel);
            this.Controls.Add(this.guitarRedPanel);
            this.Controls.Add(this.keyboardYellowPanel);
            this.Controls.Add(this.guitarGreenPanel);
            this.Controls.Add(this.guitarStrumPanel);
            this.Controls.Add(this.keyboardRedPanel);
            this.Controls.Add(this.keyboardGreenPanel);
            this.Controls.Add(label1);
            this.Controls.Add(this.keyboardStrumPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerControllerUpdate;
        private System.Windows.Forms.Timer timerClickFade;
        private System.Windows.Forms.Panel keyboardStrumPanel;
        private System.Windows.Forms.Panel keyboardGreenPanel;
        private System.Windows.Forms.Panel keyboardRedPanel;
        private System.Windows.Forms.Panel keyboardYellowPanel;
        private System.Windows.Forms.Panel keyboardBluePanel;
        private System.Windows.Forms.Panel keyboardOrangePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel guitarOrangePanel;
        private System.Windows.Forms.Panel guitarBluePanel;
        private System.Windows.Forms.Panel guitarYellowPanel;
        private System.Windows.Forms.Panel guitarRedPanel;
        private System.Windows.Forms.Panel guitarGreenPanel;
        private System.Windows.Forms.Panel guitarStrumPanel;
    }
}

