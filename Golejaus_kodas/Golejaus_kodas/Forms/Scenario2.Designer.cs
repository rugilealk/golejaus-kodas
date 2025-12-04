namespace Golejaus_kodas.Forms
{
    partial class Scenario2
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
            label1 = new Label();
            inputTextBox = new TextBox();
            submitInputTextButton = new Button();
            label2 = new Label();
            withoutEncodingTextBox = new TextBox();
            withEncodingTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            submitErrorButton = new Button();
            probabilityTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            probabilityErrorWarning = new Label();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(192, 0, 0);
            exitButton.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = SystemColors.ButtonHighlight;
            exitButton.Location = new Point(68, 565);
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
            secondScenarioLabel.Location = new Point(29, 9);
            secondScenarioLabel.Name = "secondScenarioLabel";
            secondScenarioLabel.Size = new Size(365, 30);
            secondScenarioLabel.TabIndex = 7;
            secondScenarioLabel.Text = "Second scenario - text input";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 70);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 8;
            label1.Text = "1. Input";
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(30, 138);
            inputTextBox.Multiline = true;
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(542, 222);
            inputTextBox.TabIndex = 9;
            // 
            // submitInputTextButton
            // 
            submitInputTextButton.Location = new Point(30, 366);
            submitInputTextButton.Name = "submitInputTextButton";
            submitInputTextButton.Size = new Size(291, 29);
            submitInputTextButton.TabIndex = 10;
            submitInputTextButton.Text = "Submit and send through channel";
            submitInputTextButton.UseVisualStyleBackColor = true;
            submitInputTextButton.Click += submitInputTextButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(617, 28);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 11;
            label2.Text = "2. Results";
            // 
            // withoutEncodingTextBox
            // 
            withoutEncodingTextBox.Location = new Point(617, 103);
            withoutEncodingTextBox.Multiline = true;
            withoutEncodingTextBox.Name = "withoutEncodingTextBox";
            withoutEncodingTextBox.Size = new Size(542, 222);
            withoutEncodingTextBox.TabIndex = 12;
            // 
            // withEncodingTextBox
            // 
            withEncodingTextBox.Location = new Point(617, 366);
            withEncodingTextBox.Multiline = true;
            withEncodingTextBox.Name = "withEncodingTextBox";
            withEncodingTextBox.Size = new Size(542, 222);
            withEncodingTextBox.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(617, 71);
            label3.Name = "label3";
            label3.Size = new Size(173, 18);
            label3.TabIndex = 14;
            label3.Text = "Text without encoding";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(617, 340);
            label4.Name = "label4";
            label4.Size = new Size(249, 18);
            label4.TabIndex = 15;
            label4.Text = "Text with encoding (Golay code)";
            // 
            // submitErrorButton
            // 
            submitErrorButton.Enabled = false;
            submitErrorButton.Location = new Point(30, 485);
            submitErrorButton.Name = "submitErrorButton";
            submitErrorButton.Size = new Size(94, 29);
            submitErrorButton.TabIndex = 18;
            submitErrorButton.Text = "Submit";
            submitErrorButton.UseVisualStyleBackColor = true;
            submitErrorButton.Click += submitErrorButton_Click;
            // 
            // probabilityTextBox
            // 
            probabilityTextBox.Enabled = false;
            probabilityTextBox.Location = new Point(30, 452);
            probabilityTextBox.Name = "probabilityTextBox";
            probabilityTextBox.PlaceholderText = "Enter number between 0 and 1";
            probabilityTextBox.Size = new Size(222, 27);
            probabilityTextBox.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 419);
            label5.Name = "label5";
            label5.Size = new Size(202, 20);
            label5.TabIndex = 16;
            label5.Text = "Enter the probability of error:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLight;
            label6.Location = new Point(30, 106);
            label6.Name = "label6";
            label6.Size = new Size(145, 20);
            label6.TabIndex = 19;
            label6.Text = "Enter text to be sent:";
            // 
            // probabilityErrorWarning
            // 
            probabilityErrorWarning.AutoSize = true;
            probabilityErrorWarning.Location = new Point(30, 517);
            probabilityErrorWarning.Name = "probabilityErrorWarning";
            probabilityErrorWarning.Size = new Size(0, 20);
            probabilityErrorWarning.TabIndex = 20;
            // 
            // Scenario2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1361, 658);
            Controls.Add(probabilityErrorWarning);
            Controls.Add(label6);
            Controls.Add(submitErrorButton);
            Controls.Add(probabilityTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(withEncodingTextBox);
            Controls.Add(withoutEncodingTextBox);
            Controls.Add(label2);
            Controls.Add(submitInputTextButton);
            Controls.Add(inputTextBox);
            Controls.Add(label1);
            Controls.Add(secondScenarioLabel);
            Controls.Add(exitButton);
            Name = "Scenario2";
            Text = "Scenario2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exitButton;
        private Label secondScenarioLabel;
        private Label label1;
        private TextBox inputTextBox;
        private Button submitInputTextButton;
        private Label label2;
        private TextBox withoutEncodingTextBox;
        private TextBox withEncodingTextBox;
        private Label label3;
        private Label label4;
        private Button submitErrorButton;
        private TextBox probabilityTextBox;
        private Label label5;
        private Label label6;
        private Label probabilityErrorWarning;
    }
}