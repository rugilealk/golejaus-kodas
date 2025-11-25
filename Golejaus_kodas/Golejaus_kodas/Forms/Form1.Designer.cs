namespace Golejaus_kodas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            choiceComboBox = new ComboBox();
            submitScenarioButton = new Button();
            choiceLabel = new Label();
            label1 = new Label();
            exitButton = new Button();
            SuspendLayout();
            // 
            // choiceComboBox
            // 
            choiceComboBox.FormattingEnabled = true;
            choiceComboBox.Items.AddRange(new object[] { "Scenario 1", "Scenario 2", "Scenario 3" });
            choiceComboBox.Location = new Point(295, 231);
            choiceComboBox.Name = "choiceComboBox";
            choiceComboBox.Size = new Size(166, 28);
            choiceComboBox.TabIndex = 0;
            choiceComboBox.Text = "Choose one...";
            choiceComboBox.SelectedIndexChanged += choiceComboBox_SelectedIndexChanged;
            // 
            // submitScenarioButton
            // 
            submitScenarioButton.Location = new Point(309, 265);
            submitScenarioButton.Name = "submitScenarioButton";
            submitScenarioButton.Size = new Size(141, 29);
            submitScenarioButton.TabIndex = 1;
            submitScenarioButton.Text = "Submit choice";
            submitScenarioButton.UseVisualStyleBackColor = true;
            submitScenarioButton.Click += submitScenarioButton_Click;
            // 
            // choiceLabel
            // 
            choiceLabel.AutoSize = true;
            choiceLabel.Font = new Font("Segoe UI", 13F);
            choiceLabel.Location = new Point(237, 180);
            choiceLabel.Name = "choiceLabel";
            choiceLabel.Size = new Size(317, 30);
            choiceLabel.TabIndex = 2;
            choiceLabel.Text = "Please choose a scenario below";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(323, 122);
            label1.Name = "label1";
            label1.Size = new Size(113, 32);
            label1.TabIndex = 3;
            label1.Text = "Welcome";
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(192, 0, 0);
            exitButton.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = SystemColors.ButtonHighlight;
            exitButton.Location = new Point(280, 333);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(217, 41);
            exitButton.TabIndex = 4;
            exitButton.Text = "Exit program";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Controls.Add(choiceLabel);
            Controls.Add(submitScenarioButton);
            Controls.Add(choiceComboBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox choiceComboBox;
        private Button submitScenarioButton;
        private Label choiceLabel;
        private Label label1;
        private Button exitButton;
    }
}
