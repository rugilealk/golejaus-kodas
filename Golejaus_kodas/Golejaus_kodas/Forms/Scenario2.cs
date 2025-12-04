using Golejaus_kodas.ScenarioCode;  
using Golejaus_kodas.Validation;
using System.Globalization;

namespace Golejaus_kodas.Forms
{
    public partial class Scenario2 : Form
    {
        private float errorProbability;
        private string inputText;
        public Scenario2()
        {
            InitializeComponent();
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
        /// Funkcija, kviečiama paspaudus mygtuką "Submit" prie teksto įvedimo laukelio,
        /// kuri išsaugo įvestą tekstą ir užblokuoja teksto įvedimo laukelį bei mygtuką.
        /// </summary>
        private void submitInputTextButton_Click(object sender, EventArgs e)
        {
            inputText = inputTextBox.Text;
            inputTextBox.Enabled = false;
            submitInputTextButton.Enabled = false;
            submitErrorButton.Enabled = true;
            probabilityTextBox.Enabled = true;
        }

        /// <summary>
        /// Funkcija, kviečiama paspaudus mygtuką "Submit" prie tikimybės įvedimo laukelio,
        /// kuri patikrina įvestą tikimybę, išsaugo ją ir užblokuoja tikimybės įvedimo laukelį bei mygtuką.
        /// </summary>
        private void submitErrorButton_Click(object sender, EventArgs e)
        {
            // Validacija įvestos tikimybės
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
            errorProbability = float.Parse(inputWithDot, CultureInfo.InvariantCulture);

            probabilityTextBox.Enabled = false;

            // Vykdomas scenarijus
            (string withEncoding, string withoutEncoding) = Scenario2Code.Scenario2(inputText, errorProbability);

            withoutEncodingTextBox.Text = withoutEncoding;
            withEncodingTextBox.Text = withEncoding;

        }
    }
}
