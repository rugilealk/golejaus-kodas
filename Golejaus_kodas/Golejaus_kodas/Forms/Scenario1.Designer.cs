namespace Golejaus_kodas.Forms
{
    partial class Scenario1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            exitButton = new Button();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(192, 0, 0);
            exitButton.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = SystemColors.ButtonHighlight;
            exitButton.Location = new Point(532, 368);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(217, 41);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit program";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // Scenario1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exitButton);
            Name = "Scenario1";
            Text = "Scenario1";
            ResumeLayout(false);
        }

        #endregion

        private Button exitButton;
    }
}