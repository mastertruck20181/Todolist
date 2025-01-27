using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Added for SqlConnection


namespace List_To_Do__Tab_
{

    public partial class addTask : Form
    {
        //private string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Persist Security Info=True;User ID=Admin;Password=adamlambert123;Encrypt=True;TrustServerCertificate=True";
        public string userGUID { get; set; }
        public addTask()
        {
            InitializeComponent();
            statusBox.DataSource = Enum.GetValues(typeof(TaskStatus));

        }










        private void saveButton_Click(object sender, EventArgs e)
        {
            TaskModifier taskModifier = new TaskModifier(); // Create an instance of TaskModifier
            


            // Get task details from UI elements
            TaskStatus status = (TaskStatus)Enum.Parse(typeof(TaskStatus), statusBox.SelectedItem.ToString()); 
            string title = titleTextBox.Text;
            string note = noteTextBox.Text;
            DateTime startDate = dateTimePicker1.Value;
            DateTime dueDate = dateTimePicker2.Value;


            taskModifier.AddTask(title, note, status, startDate, dueDate);

            //Guid userGUID = Accounts.UserSession.CurrentUserGUID;
            // Then set up the ListViews
            
            taskModifier.LoadTasks(Accounts.UserSession.CurrentUserGUID); // Call LoadTasks with MainMenuForm reference

            MessageBox.Show("Task added successfully. Good luck on your Task!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close(); // Close the addTask form after successful addition

        }

        
        





        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }



}
