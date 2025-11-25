using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Golejaus_kodas.Validation;
using Golejaus_kodas.Channel;

namespace Golejaus_kodas.Forms
{
    public partial class Scenario1 : Form
    {
        private ChannelWithError channel;
        private float errorProbability;
        private byte[] inputVector = new byte[12];

        public Scenario1()
        {
            InitializeComponent();
            channel = new ChannelWithError();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitErrorButton_Click(object sender, EventArgs e) //pataisyti, kad priimtu skaicius su kableliu
        {
            InputValidation validator = new InputValidation();
            (bool, String) validationResult = validator.isProbabilityValid(probabilityTextBox.Text);
            if (!validationResult.Item1)
            {
                probabilityErrorWarning.Text = validationResult.Item2;
                submitErrorButton.Enabled = true;
                return;
            }

            probabilityErrorWarning.Text = "";
            submitErrorButton.Enabled = false;
            probabilityTextBox.Enabled = false;

            errorProbability = float.Parse(probabilityTextBox.Text);
            channel.setErrorProbability(errorProbability);
        }

        private void submitVectorButton_Click(object sender, EventArgs e)
        {
            InputValidation validator = new InputValidation();
            (bool, String) validationResult = validator.isVectorValid(vectorTextBox.Text);
            if (!validationResult.Item1)
            {
                vectorWarning.Text = validationResult.Item2;
                submitVectorButton.Enabled = true;
                return;
            }

            vectorWarning.Text = "";
            submitVectorButton.Enabled = false;
            vectorTextBox.Enabled = false;

            for (int i=0; i<12; ++i)
                inputVector[i] = byte.Parse(vectorTextBox.Text[i].ToString());
        }
    }
}
