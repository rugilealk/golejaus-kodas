using Golejaus_kodas.ScenarioCode;
using Golejaus_kodas.Validation;
using System.Globalization;

namespace Golejaus_kodas.Forms
{

    public partial class Scenario3 : Form
    {
        private byte[] fileBytes;
        private byte[] withoutCodeBytes;
        private byte[] withCodeBytes;
        private float errorProbability;
        public Scenario3()
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
        /// Funckcija, kviečiama paspaudus mygtuką "Atidaryti paveikslėlį",
        /// kuri įkelia paveikslėlį, pritaiko Golėjaus kodą ir atvaizduoja rezultatus.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Stream bmpStream = null;
            openFileButton.Enabled = false;
            // Paveikslėlio įkėlimas/nuskaitymas kaip bitų masyvas
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Bitmap files (*.bmp)|*.bmp|All files (*.*)|*.*";
                dialog.Title = "Select a BMP file";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bmpStream = dialog.OpenFile();

                        if (bmpStream != null)
                        {
                            fileBytes = new byte[bmpStream.Length];
                            bmpStream.Read(fileBytes, 0, fileBytes.Length);

                            using (MemoryStream ms = new MemoryStream(fileBytes))
                            {
                                Bitmap bmp = new Bitmap(ms);
                                originalPictureBox.Image = bmp;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: could not read file. " + ex.Message);
                    }
                }
            }
            //Paveikslėlių atvaizdavimas su ir be kodo
            (withCodeBytes, withoutCodeBytes) = Scenario3Code.Scenario3(fileBytes, errorProbability);
            using (MemoryStream msWithCode = new MemoryStream(withCodeBytes))
            {
                Bitmap bmpWithCode = new Bitmap(msWithCode);
                withEncodingPictureBox.Image = bmpWithCode;
            }
            using (MemoryStream msWithoutCode = new MemoryStream(withoutCodeBytes))
            {
                Bitmap bmpWithoutCode = new Bitmap(msWithoutCode);
                withoutEncodingPictureBox.Image = bmpWithoutCode;
            }

        }

        /// <summary>
        /// Funkcija, kviečiama paspaudus mygtuką "Patvirtinti klaidą",
        /// kuri patikrina įvestą klaidos tikimybę ir ją nustato.
        /// </summary>
        private void submitErrorButton_Click(object sender, EventArgs e)
        {
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
            openFileButton.Enabled = true;
            probabilityTextBox.Enabled = false;
        }

    }
}
