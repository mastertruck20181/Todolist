using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List_To_Do__Tab_
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        // Check if account is correctly fill in
        public bool checkAccounts(string account)
        {
            return Regex.IsMatch(account, "^[a-zA-Z0-9]{6,24}$");
        }



        private void confirmButton_Click(object sender, EventArgs e)
        {
           
            string username = userBox.Text;
            string password = passBox.Text;
            string password2 = passBox2.Text;
            string firstName = fnameBox.Text;
            string lastName = lnameBox.Text;
            string email = emailBox.Text;

            // Register condition
            if (!checkAccounts(username)) 
            { MessageBox.Show("Error: Username must contain 6-20 characters (only letters, numbers, spaces, or the underscore character.)"); return; }

            if (!checkAccounts(password)) 
            { MessageBox.Show("Error: Password must contain  6-20 characters (only letters, numbers, spaces, or the underscore character.)"); return; }
            if (!checkAccounts(password2)) 
            { MessageBox.Show("Error: Wrong Password, please re-enter your Password."); return; }


            if (!Regex.IsMatch(email, "^[\\w-]+\\@([\\w\\.]+\\w+)$"))
            {
                MessageBox.Show("Error: Please enter a valid email address.");
                return;
            }

            if (!Accounts.IsUsernameAvailable(username))
            {
                MessageBox.Show("Your Username has been registered, please use another Username");
                return;
            }

            Accounts accounts = new Accounts();
            accounts.addAccount(username, password, firstName, lastName, email);


            MessageBox.Show("Account registered successfully !", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoginMenu loginMenu = new LoginMenu();
            loginMenu.ShowDialog();
            this.Close();

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
