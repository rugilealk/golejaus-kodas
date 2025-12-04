using Golejaus_kodas.Channel;
using Golejaus_kodas.GolayCode;
using Golejaus_kodas.Helpers;
using Golejaus_kodas.Validation;
using System.Data;
using System.Globalization;

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

        /// <summary>
        /// Funkcija, kviečiama paspaudus mygtuką "Išeiti",
        /// kuri uždaro programą.
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Funkcija, kuri yra kviečiama paspaudus mygtuką "Submit" prie klaidos tikimybės įvedimo laukelio.
        /// </summary>
        private void submitErrorButton_Click(object sender, EventArgs e) 
        {
            // Validacija - tikimybė turi būti skaičius nuo 0 iki 1
            InputValidation validator = new InputValidation();
            string inputWithDot = probabilityTextBox.Text.Replace(',', '.'); 
            (bool, String) validationResult = validator.isProbabilityValid(inputWithDot);
            if (!validationResult.Item1)
            {
                probabilityErrorWarning.Text = validationResult.Item2;
                submitErrorButton.Enabled = true;
                return;
            }

            probabilityErrorWarning.Text = "";
            submitErrorButton.Enabled = false;
            probabilityTextBox.Enabled = false;

            errorProbability = float.Parse(inputWithDot, CultureInfo.InvariantCulture);
            channel.setErrorProbability(errorProbability);

            vectorTextBox.Enabled = true;
            submitVectorButton.Enabled = true;
        }

        /// <summary>
        /// Funkcija, kuri yra kviečiama paspaudus mygtuką "Submit" prie vektoriaus įvedimo laukelio.
        /// kuri įrašo įvestą vektorių.
        /// </summary>
        private void submitVectorButton_Click(object sender, EventArgs e)
        {
            // Vektoriaus validacija - vektorius turi būti 12 ilgio ir sudarytas tik iš 0 ir 1 reikšmių
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

            // Nuskaito įvestą vektorių
            for (int i = 0; i < 12; ++i)
                inputVector[i] = byte.Parse(vectorTextBox.Text[i].ToString());

            encodeButton.Enabled = true;
        }


        /// <summary>
        /// Funkcija, kuri yra kviečiama paspaudus mygtuką "Encode", kuri užkoduoja įvestą vektorių naudojant Golėjaus kodą.
        /// </summary>
        private void encodeButton_Click(object sender, EventArgs e)
        {
            encodeButton.Enabled = false;
            GolayEncoding encoder = new GolayEncoding();
            encodedVector = encoder.encodeVector(inputVector);

            encodedVectorLabel.Text = VectorTools.convertVectorToString(encodedVector);
            sendVectorButton.Enabled = true;

        }

        /// <summary>
        /// Funkcija, kuri yra kviečiama paspaudus mygtuką "Send through channel", kuri siunčia užkoduotą vektorių per kanalą su klaidomis.
        /// </summary>
        private void sendVectorButton_Click(object sender, EventArgs e)
        {
            sendVectorButton.Enabled = false;
            receivedVector = channel.SendThroughChannel(encodedVector);

            receivedVectorLabel.Text = VectorTools.convertVectorToString(receivedVector);
            (int errorCount, string errorPositions) = VectorTools.getErrorInfoString(encodedVector, receivedVector);

            // Atvaizduoja klaidų informaciją
            numberOfErrorsLabel.Text = errorCount.ToString();
            if (errorCount > 0)
                errorPositionsLabel.Text = errorPositions;
            
            else
                errorPositionsLabel.Text = "No mistakes were made";
            

            submitEditedVectorButton.Enabled = true;
            editVectorTextBox.Enabled = true;
            editVectorTextBox.Text = VectorTools.convertVectorToString(receivedVector);
        }


        /// <summary>
        /// Funkcija, kuri yra kviečiama paspaudus mygtuką "Submit" prie redaguoto vektoriaus įvedimo laukelio.
        /// </summary>
        private void submitEditedVectorButton_Click(object sender, EventArgs e)
        {
            // Vektoriaus validacija - vektorius turi būti 23 ilgio ir sudarytas tik iš 0 ir 1 reikšmių
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
            // Nuskaito redaguotą vektorių
            for (int i = 0; i < 12; ++i)
                receivedVector[i] = byte.Parse(editVectorTextBox.Text[i].ToString());

            editVectorTextBox.Enabled = false;

            // Dekoduoja gautą (ir galbūt redaguotą) vektorių
            GolayDecoding decoder = new GolayDecoding();
            byte[] decodedVector = decoder.decode(receivedVector);
            decodedVectorTextBox.Text = VectorTools.convertVectorToString(decodedVector);
        }

    }
}
