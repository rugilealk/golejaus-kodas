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
            label10 = new Label();
            encodedVectorLabel = new Label();
            label3 = new Label();
            sendVectorButton = new Button();
            receivedVectorLabel = new Label();
            label4 = new Label();
            label5 = new Label();
            numberOfErrorsLabel = new Label();
            errorPositionsLabel = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            editVectorTextBox = new TextBox();
            submitEditedVectorButton = new Button();
            editVectorWarning = new Label();
            label11 = new Label();
            decodedVectorTextBox = new TextBox();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(192, 0, 0);
            exitButton.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = SystemColors.ButtonHighlight;
            exitButton.Location = new Point(644, 385);
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
            firstScenarioLabel.Location = new Point(219, 9);
            firstScenarioLabel.Name = "firstScenarioLabel";
            firstScenarioLabel.Size = new Size(359, 30);
            firstScenarioLabel.TabIndex = 6;
            firstScenarioLabel.Text = "First scenario - vector input";
            firstScenarioLabel.Click += firstScenarioLabel_Click;
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
            probabilityTextBox.PlaceholderText = "Enter number between 0 and 1";
            probabilityTextBox.Size = new Size(222, 27);
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
            vectorTextBox.Enabled = false;
            vectorTextBox.Location = new Point(12, 233);
            vectorTextBox.Name = "vectorTextBox";
            vectorTextBox.PlaceholderText = "Max length 12";
            vectorTextBox.Size = new Size(222, 27);
            vectorTextBox.TabIndex = 11;
            // 
            // submitVectorButton
            // 
            submitVectorButton.Enabled = false;
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
            encodeButton.BackColor = Color.YellowGreen;
            encodeButton.Enabled = false;
            encodeButton.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            encodeButton.ForeColor = SystemColors.ButtonHighlight;
            encodeButton.Location = new Point(12, 343);
            encodeButton.Name = "encodeButton";
            encodeButton.Size = new Size(279, 36);
            encodeButton.TabIndex = 15;
            encodeButton.Text = "Encode the vector with Golay code";
            encodeButton.UseVisualStyleBackColor = false;
            encodeButton.Click += encodeButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 385);
            label10.Name = "label10";
            label10.Size = new Size(119, 20);
            label10.TabIndex = 16;
            label10.Text = "Encoded vector: ";
            label10.Click += encodedVectorLabel_Click;
            // 
            // encodedVectorLabel
            // 
            encodedVectorLabel.AutoSize = true;
            encodedVectorLabel.Location = new Point(151, 385);
            encodedVectorLabel.Name = "encodedVectorLabel";
            encodedVectorLabel.Size = new Size(0, 20);
            encodedVectorLabel.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(390, 107);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 18;
            label3.Text = "Received vector:";
            label3.Click += label3_Click;
            // 
            // sendVectorButton
            // 
            sendVectorButton.BackColor = Color.YellowGreen;
            sendVectorButton.Enabled = false;
            sendVectorButton.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sendVectorButton.ForeColor = SystemColors.ButtonHighlight;
            sendVectorButton.Location = new Point(390, 71);
            sendVectorButton.Name = "sendVectorButton";
            sendVectorButton.Size = new Size(255, 33);
            sendVectorButton.TabIndex = 19;
            sendVectorButton.Text = "Send vector through channel";
            sendVectorButton.UseVisualStyleBackColor = false;
            sendVectorButton.Click += sendVectorButton_Click;
            // 
            // receivedVectorLabel
            // 
            receivedVectorLabel.AutoSize = true;
            receivedVectorLabel.Location = new Point(516, 107);
            receivedVectorLabel.Name = "receivedVectorLabel";
            receivedVectorLabel.Size = new Size(0, 20);
            receivedVectorLabel.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(390, 127);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 21;
            label4.Text = "Number of errors:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(390, 147);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 22;
            label5.Text = "Error positions:";
            // 
            // numberOfErrorsLabel
            // 
            numberOfErrorsLabel.AutoSize = true;
            numberOfErrorsLabel.Location = new Point(525, 127);
            numberOfErrorsLabel.Name = "numberOfErrorsLabel";
            numberOfErrorsLabel.Size = new Size(0, 20);
            numberOfErrorsLabel.TabIndex = 23;
            // 
            // errorPositionsLabel
            // 
            errorPositionsLabel.AutoSize = true;
            errorPositionsLabel.Location = new Point(507, 147);
            errorPositionsLabel.Name = "errorPositionsLabel";
            errorPositionsLabel.Size = new Size(0, 20);
            errorPositionsLabel.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 318);
            label6.Name = "label6";
            label6.Size = new Size(222, 21);
            label6.TabIndex = 25;
            label6.Text = "2. Golay code - encoding";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(390, 48);
            label7.Name = "label7";
            label7.Size = new Size(369, 21);
            label7.TabIndex = 26;
            label7.Text = "3. Send vector through unreliable channel";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(390, 233);
            label8.Name = "label8";
            label8.Size = new Size(268, 21);
            label8.TabIndex = 27;
            label8.Text = "4. Edit vector before decoding";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            label9.Location = new Point(12, 48);
            label9.Name = "label9";
            label9.Size = new Size(79, 21);
            label9.TabIndex = 28;
            label9.Text = "1. Input";
            // 
            // editVectorTextBox
            // 
            editVectorTextBox.Enabled = false;
            editVectorTextBox.Location = new Point(390, 257);
            editVectorTextBox.Name = "editVectorTextBox";
            editVectorTextBox.PlaceholderText = "Max length 23";
            editVectorTextBox.Size = new Size(217, 27);
            editVectorTextBox.TabIndex = 29;
            // 
            // submitEditedVectorButton
            // 
            submitEditedVectorButton.BackColor = Color.YellowGreen;
            submitEditedVectorButton.Enabled = false;
            submitEditedVectorButton.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitEditedVectorButton.ForeColor = SystemColors.ButtonHighlight;
            submitEditedVectorButton.Location = new Point(390, 290);
            submitEditedVectorButton.Name = "submitEditedVectorButton";
            submitEditedVectorButton.Size = new Size(188, 29);
            submitEditedVectorButton.TabIndex = 30;
            submitEditedVectorButton.Text = "Submit and decode";
            submitEditedVectorButton.UseVisualStyleBackColor = false;
            submitEditedVectorButton.Click += submitEditedVectorButton_Click;
            // 
            // editVectorWarning
            // 
            editVectorWarning.AutoSize = true;
            editVectorWarning.ForeColor = Color.Maroon;
            editVectorWarning.Location = new Point(390, 322);
            editVectorWarning.Name = "editVectorWarning";
            editVectorWarning.Size = new Size(0, 20);
            editVectorWarning.TabIndex = 31;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(390, 353);
            label11.Name = "label11";
            label11.Size = new Size(165, 21);
            label11.TabIndex = 32;
            label11.Text = "5. Decoded vector";
            label11.Click += label11_Click;
            // 
            // decodedVectorTextBox
            // 
            decodedVectorTextBox.Enabled = false;
            decodedVectorTextBox.Location = new Point(390, 377);
            decodedVectorTextBox.Name = "decodedVectorTextBox";
            decodedVectorTextBox.Size = new Size(217, 27);
            decodedVectorTextBox.TabIndex = 33;
            decodedVectorTextBox.TextChanged += decodedVectorTextBox_TextChanged;
            // 
            // Scenario1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 450);
            Controls.Add(decodedVectorTextBox);
            Controls.Add(label11);
            Controls.Add(editVectorWarning);
            Controls.Add(submitEditedVectorButton);
            Controls.Add(editVectorTextBox);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(errorPositionsLabel);
            Controls.Add(numberOfErrorsLabel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(receivedVectorLabel);
            Controls.Add(sendVectorButton);
            Controls.Add(label3);
            Controls.Add(encodedVectorLabel);
            Controls.Add(label10);
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
            Load += Scenario1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exitButton;
        private Label firstScenarioLabel;
        private Label label1;
        private TextBox editVectorTextBox;
        private Button sendVectorButton;
        private Label label2;
        private TextBox vectorTextBox;
        private Button submitVectorButton;
        private TextBox probabilityTextBox;
        private Button submitErrorButton;
        private Label probabilityErrorWarning;
        private Label vectorWarning;
        private Button encodeButton;
        private Label label10;
        private Label encodedVectorLabel;
        private Label label3;
        private Label receivedVectorLabel;
        private Label label4;
        private Label label5;
        private Label numberOfErrorsLabel;
        private Label errorPositionsLabel;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button submitEditedVectorButton;
        private Label editVectorWarning;
        private Label label11;
        private TextBox decodedVectorTextBox;
    }
}