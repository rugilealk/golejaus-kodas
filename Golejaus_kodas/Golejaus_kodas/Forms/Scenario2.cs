using Golejaus_kodas.Validation;
using Golejaus_kodas.ScenarioCode;  

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

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitInputTextButton_Click(object sender, EventArgs e)
        {
            inputText = inputTextBox.Text;
            inputTextBox.Enabled = false;
            submitInputTextButton.Enabled = false;
            submitErrorButton.Enabled = true;
            probabilityTextBox.Enabled = true;
        }
        private void submitErrorButton_Click(object sender, EventArgs e)
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
            errorProbability = float.Parse(probabilityTextBox.Text);

            probabilityTextBox.Enabled = false;

            (string withEncoding, string withoutEncoding) = Scenario2Code.Scenario2(inputText, errorProbability);

            withoutEncodingTextBox.Text = withoutEncoding;
            withEncodingTextBox.Text = withEncoding;

        }
    }
}
