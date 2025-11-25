namespace Golejaus_kodas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void choiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void submitScenarioButton_Click(object sender, EventArgs e)
        {
            var selectedScenario = choiceComboBox.SelectedItem;
            switch (selectedScenario)
            {
                case "Scenario 1":
                    Form scenario1Form = new Forms.Scenario1();
                    scenario1Form.Show();
                    this.Hide();
                    break;
                case "Scenario 2":
                    Form scenario2Form = new Forms.Scenario2();
                    scenario2Form.Show();
                    this.Hide();
                    break;
                case "Scenario 3":
                    Form scenario3Form = new Forms.Scenario3();
                    this.Hide();
                    scenario3Form.Show();
                    break;
                default:
                    MessageBox.Show("Please select a valid scenario.");
                    break;
            }


        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
