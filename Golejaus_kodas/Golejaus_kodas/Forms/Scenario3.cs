using Golejaus_kodas.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using Golejaus_kodas.ScenarioCode;

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

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream bmpStream = null;

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void secondScenarioLabel_Click(object sender, EventArgs e)
        {

        }

        private void probabilityTextBox_TextChanged(object sender, EventArgs e)
        {

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
            openFileButton.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
