using System.Data;
using Golejaus_kodas.Validation;
using Golejaus_kodas.Channel;
using Golejaus_kodas.GolayCode;
using Golejaus_kodas.Helpers;

namespace Golejaus_kodas.Forms
{
    public partial class Scenario1 : Form
    {
        private ChannelWithError channel;
        private float errorProbability;
        private byte[] inputVector = new byte[12];
        private byte[] encodedVector = new byte[23];
        private byte[] receivedVector = new byte[23];

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

            vectorTextBox.Enabled = true;
            submitVectorButton.Enabled = true;
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

            for (int i = 0; i < 12; ++i)
                inputVector[i] = byte.Parse(vectorTextBox.Text[i].ToString());

            encodeButton.Enabled = true;
        }


        private void encodeButton_Click(object sender, EventArgs e)
        {
            encodeButton.Enabled = false;
            GolayEncoding encoder = new GolayEncoding();
            encodedVector = encoder.encodeVector(inputVector);

            encodedVectorLabel.Text = VectorTools.convertVectorToString(encodedVector);
            sendVectorButton.Enabled = true;

        }

        private void sendVectorButton_Click(object sender, EventArgs e)
        {
            sendVectorButton.Enabled = false;
            receivedVector = channel.SendThroughChannel(encodedVector);

            receivedVectorLabel.Text = VectorTools.convertVectorToString(receivedVector);
            (int errorCount, string errorPositions) = VectorTools.getErrorInfoString(encodedVector, receivedVector);

            numberOfErrorsLabel.Text = errorCount.ToString();
            if (errorCount > 0)
                errorPositionsLabel.Text = errorPositions;
            
            else
                errorPositionsLabel.Text = "No mistakes were made";
            

            submitEditedVectorButton.Enabled = true;
            editVectorTextBox.Enabled = true;
            editVectorTextBox.Text = VectorTools.convertVectorToString(receivedVector);
        }


        private void submitEditedVectorButton_Click(object sender, EventArgs e)
        {
            InputValidation validator = new InputValidation();
            (bool, String) validationResult = validator.isEncodedVectorValid(editVectorTextBox.Text);

            if (!validationResult.Item1)
            {
                editVectorWarning.Text = validationResult.Item2;
                submitEditedVectorButton.Enabled = true;
                return;
            }

            editVectorWarning.Text = "";
            submitEditedVectorButton.Enabled = false;
            receivedVector = editVectorTextBox.Text.Select(c => (byte)(c - '0')).ToArray();
            editVectorTextBox.Enabled = false;

            GolayDecoding decoder = new GolayDecoding();
            byte[] decodedVector = decoder.decode(receivedVector);
            decodedVectorTextBox.Text = VectorTools.convertVectorToString(decodedVector);


        }

    }
}

//TODO: istrinti nenaudojamus usings
//FIXME: nepriima kablelio, veikia tik su tasku skaiciai