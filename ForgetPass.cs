using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace List_To_Do__Tab_
{
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = userBox.Text;









        }

       

        private void resetButton_Click(object sender, EventArgs e)
        {





            ResetPassword resetPassword = new ResetPassword();
            resetPassword.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
