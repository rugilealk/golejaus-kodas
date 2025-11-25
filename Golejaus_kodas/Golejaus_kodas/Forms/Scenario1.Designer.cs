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
            firstScenarioLabel = new Label();
            label1 = new Label();
            probabilityTextBox = new TextBox();
            submitErrorButton = new Button();
            label2 = new Label();
            vectorTextBox = new TextBox();
            submitVectorButton = new Button();
            probabilityErrorWarning = new Label();
            vectorWarning = new Label();
            encodeButton = new Button();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(192, 0, 0);
            exitButton.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = SystemColors.ButtonHighlight;
            exitButton.Location = new Point(546, 373);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(217, 41);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit program";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // firstScenarioLabel
            // 
            firstScenarioLabel.AutoSize = true;
            firstScenarioLabel.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            firstScenarioLabel.Location = new Point(12, 18);
            firstScenarioLabel.Name = "firstScenarioLabel";
            firstScenarioLabel.Size = new Size(359, 30);
            firstScenarioLabel.TabIndex = 6;
            firstScenarioLabel.Text = "First scenario - vector input";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 68);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 7;
            label1.Text = "Enter the probability of error:";
            // 
            // probabilityTextBox
            // 
            probabilityTextBox.Location = new Point(12, 101);
            probabilityTextBox.Name = "probabilityTextBox";
            probabilityTextBox.Size = new Size(202, 27);
            probabilityTextBox.TabIndex = 8;
            // 
            // submitErrorButton
            // 
            submitErrorButton.Location = new Point(12, 134);
            submitErrorButton.Name = "submitErrorButton";
            submitErrorButton.Size = new Size(94, 29);
            submitErrorButton.TabIndex = 9;
            submitErrorButton.Text = "Submit";
            submitErrorButton.UseVisualStyleBackColor = true;
            submitErrorButton.Click += submitErrorButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 199);
            label2.Name = "label2";
            label2.Size = new Size(308, 20);
            label2.TabIndex = 10;
            label2.Text = "Enter the vector that you want to send below:";
            // 
            // vectorTextBox
            // 
            vectorTextBox.Location = new Point(12, 233);
            vectorTextBox.Name = "vectorTextBox";
            vectorTextBox.Size = new Size(308, 27);
            vectorTextBox.TabIndex = 11;
            // 
            // submitVectorButton
            // 
            submitVectorButton.Location = new Point(12, 266);
            submitVectorButton.Name = "submitVectorButton";
            submitVectorButton.Size = new Size(94, 29);
            submitVectorButton.TabIndex = 12;
            submitVectorButton.Text = "Submit";
            submitVectorButton.UseVisualStyleBackColor = true;
            submitVectorButton.Click += submitVectorButton_Click;
            // 
            // probabilityErrorWarning
            // 
            probabilityErrorWarning.AutoSize = true;
            probabilityErrorWarning.ForeColor = Color.FromArgb(192, 0, 0);
            probabilityErrorWarning.Location = new Point(12, 166);
            probabilityErrorWarning.Name = "probabilityErrorWarning";
            probabilityErrorWarning.Size = new Size(0, 20);
            probabilityErrorWarning.TabIndex = 13;
            // 
            // vectorWarning
            // 
            vectorWarning.AutoSize = true;
            vectorWarning.ForeColor = Color.FromArgb(192, 0, 0);
            vectorWarning.Location = new Point(12, 298);
            vectorWarning.Name = "vectorWarning";
            vectorWarning.Size = new Size(0, 20);
            vectorWarning.TabIndex = 14;
            // 
            // encodeButton
            // 
            encodeButton.Location = new Point(125, 371);
            encodeButton.Name = "encodeButton";
            encodeButton.Size = new Size(180, 49);
            encodeButton.TabIndex = 15;
            encodeButton.Text = "Encode the vector with Golay code";
            encodeButton.UseVisualStyleBackColor = true;
            // 
            // Scenario1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(encodeButton);
            Controls.Add(vectorWarning);
            Controls.Add(probabilityErrorWarning);
            Controls.Add(submitVectorButton);
            Controls.Add(vectorTextBox);
            Controls.Add(label2);
            Controls.Add(submitErrorButton);
            Controls.Add(probabilityTextBox);
            Controls.Add(label1);
            Controls.Add(firstScenarioLabel);
            Controls.Add(exitButton);
            Name = "Scenario1";
            Text = "Scenario1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exitButton;
        private Label firstScenarioLabel;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private TextBox vectorTextBox;
        private Button submitVectorButton;
        private TextBox probabilityTextBox;
        private Button submitErrorButton;
        private Label probabilityErrorWarning;
        private Label vectorWarning;
        private Button encodeButton;
    }
}