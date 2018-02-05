using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveJourney
{
    public partial class Form1 : Form
    {
        private IMainRepository MainRepo = new MainRepository();

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
                if (this.PasswordTextBox.Text == user.Password && user.AdminType == 1)
                {
                    new ManagementForm().Show();
                    this.Close();
                }
            }
        }

        private bool CheckIfValidInput(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
    }
}
