using DataAccess.Repository;
using System;
using System.Windows.Forms;

namespace LiveJourney
{
    public partial class Form1 : Form
    {
        private IMainRepository MainRepo = new MainRepository();
        private bool ShouldClose = true;

        public Form1()
        {
            new MainRepository();
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!this.CheckIfValidInput(this.UsernameTextbox.Text) && !this.CheckIfValidInput(this.PasswordTextBox.Text))
            {
                var user = MainRepo.GetUser(this.UsernameTextbox.Text);
                if (user != null && this.PasswordTextBox.Text == user.Password && user.AdminType == 1)
                {
                    ShouldClose = false;
                    new ManagementForm(MainRepo).Show();
                    this.Close();
                }
            }
        }

        private bool CheckIfValidInput(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ShouldClose)
            {
                Application.Exit();
            }
        }
    }
}
