namespace Golejaus_kodas.Forms
{
    partial class Scenario3
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
            secondScenarioLabel = new Label();
            openFileButton = new Button();
            label2 = new Label();
            originalPictureBox = new PictureBox();
            label3 = new Label();
            probabilityErrorWarning = new Label();
            submitErrorButton = new Button();
            probabilityTextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            withoutEncodingPictureBox = new PictureBox();
            withEncodingPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)withoutEncodingPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)withEncodingPictureBox).BeginInit();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(192, 0, 0);
            exitButton.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = SystemColors.ButtonHighlight;
            exitButton.Location = new Point(12, 651);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(217, 41);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit program";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // secondScenarioLabel
            // 
            secondScenarioLabel.AutoSize = true;
            secondScenarioLabel.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            secondScenarioLabel.Location = new Point(12, 34);
            secondScenarioLabel.Name = "secondScenarioLabel";
            secondScenarioLabel.Size = new Size(431, 30);
            secondScenarioLabel.TabIndex = 8;
            secondScenarioLabel.Text = "Third scenario - bmp image input";
            secondScenarioLabel.Click += secondScenarioLabel_Click;
            // 
            // openFileButton
            // 
            openFileButton.Enabled = false;
            openFileButton.Location = new Point(12, 243);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(312, 42);
            openFileButton.TabIndex = 10;
            openFileButton.Text = "Press to look for file";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 11;
            label2.Text = "1. Input ";
            label2.Click += label2_Click;
            // 
            // originalPictureBox
            // 
            originalPictureBox.Location = new Point(12, 330);
            originalPictureBox.Name = "originalPictureBox";
            originalPictureBox.Size = new Size(474, 296);
            originalPictureBox.TabIndex = 12;
            originalPictureBox.TabStop = false;
            originalPictureBox.WaitOnLoad = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 297);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 13;
            label3.Text = "Original picture:";
            label3.Click += label3_Click;
            // 
            // probabilityErrorWarning
            // 
            probabilityErrorWarning.AutoSize = true;
            probabilityErrorWarning.Location = new Point(12, 199);
            probabilityErrorWarning.Name = "probabilityErrorWarning";
            probabilityErrorWarning.Size = new Size(0, 20);
            probabilityErrorWarning.TabIndex = 24;
            // 
            // submitErrorButton
            // 
            submitErrorButton.Location = new Point(12, 167);
            submitErrorButton.Name = "submitErrorButton";
            submitErrorButton.Size = new Size(94, 29);
            submitErrorButton.TabIndex = 23;
            submitErrorButton.Text = "Submit";
            submitErrorButton.UseVisualStyleBackColor = true;
            submitErrorButton.Click += submitErrorButton_Click;
            // 
            // probabilityTextBox
            // 
            probabilityTextBox.Location = new Point(12, 134);
            probabilityTextBox.Name = "probabilityTextBox";
            probabilityTextBox.PlaceholderText = "Enter number between 0 and 1";
            probabilityTextBox.Size = new Size(222, 27);
            probabilityTextBox.TabIndex = 22;
            probabilityTextBox.TextChanged += probabilityTextBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 101);
            label5.Name = "label5";
            label5.Size = new Size(202, 20);
            label5.TabIndex = 21;
            label5.Text = "Enter the probability of error:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 220);
            label4.Name = "label4";
            label4.Size = new Size(244, 20);
            label4.TabIndex = 25;
            label4.Text = "Please select the image (.bmp only)";
            label4.Click += label4_Click;
            // 
            // withoutEncodingPictureBox
            // 
            withoutEncodingPictureBox.Location = new Point(728, 47);
            withoutEncodingPictureBox.Name = "withoutEncodingPictureBox";
            withoutEncodingPictureBox.Size = new Size(474, 296);
            withoutEncodingPictureBox.TabIndex = 26;
            withoutEncodingPictureBox.TabStop = false;
            withoutEncodingPictureBox.WaitOnLoad = true;
            // 
            // withEncodingPictureBox
            // 
            withEncodingPictureBox.Location = new Point(728, 379);
            withEncodingPictureBox.Name = "withEncodingPictureBox";
            withEncodingPictureBox.Size = new Size(474, 296);
            withEncodingPictureBox.TabIndex = 27;
            withEncodingPictureBox.TabStop = false;
            withEncodingPictureBox.WaitOnLoad = true;
            // 
            // Scenario3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 700);
            Controls.Add(withEncodingPictureBox);
            Controls.Add(withoutEncodingPictureBox);
            Controls.Add(label4);
            Controls.Add(probabilityErrorWarning);
            Controls.Add(submitErrorButton);
            Controls.Add(probabilityTextBox);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(originalPictureBox);
            Controls.Add(label2);
            Controls.Add(openFileButton);
            Controls.Add(secondScenarioLabel);
            Controls.Add(exitButton);
            Name = "Scenario3";
            Text = "Scenario3";
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)withoutEncodingPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)withEncodingPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exitButton;
        private Label secondScenarioLabel;
        private Button openFileButton;
        private Label label2;
        private PictureBox originalPictureBox;
        private Label label3;
        private Label probabilityErrorWarning;
        private Button submitErrorButton;
        private TextBox probabilityTextBox;
        private Label label5;
        private Label label4;
        private PictureBox withoutEncodingPictureBox;
        private PictureBox withEncodingPictureBox;
    }
}