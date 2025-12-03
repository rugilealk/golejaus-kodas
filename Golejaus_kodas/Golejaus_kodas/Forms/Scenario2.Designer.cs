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
            textBox1 = new TextBox();
            submitInputTextButton = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
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
            secondScenarioLabel.Click += secondScenarioLabel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 70);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 8;
            label1.Text = "1. Input";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 103);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(542, 222);
            textBox1.TabIndex = 9;
            // 
            // submitInputTextButton
            // 
            submitInputTextButton.Location = new Point(29, 331);
            submitInputTextButton.Name = "submitInputTextButton";
            submitInputTextButton.Size = new Size(291, 29);
            submitInputTextButton.TabIndex = 10;
            submitInputTextButton.Text = "Submit and send through channel";
            submitInputTextButton.UseVisualStyleBackColor = true;
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
            // textBox2
            // 
            textBox2.Location = new Point(617, 103);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(542, 222);
            textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(617, 366);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(542, 222);
            textBox3.TabIndex = 13;
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
            label4.Location = new Point(617, 340);
            label4.Name = "label4";
            label4.Size = new Size(223, 20);
            label4.TabIndex = 15;
            label4.Text = "Text with encoding (Golay code)";
            // 
            // Scenario2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1361, 658);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(submitInputTextButton);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private Button submitInputTextButton;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
    }
}