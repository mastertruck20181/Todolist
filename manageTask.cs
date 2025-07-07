//using System;
//using System.Data;
//using System.Data.SqlClient; // Added for SqlConnection
//using System.Windows.Forms;


//namespace List_To_Do__Tab_
//{

//    public partial class manageTask : Form
//    {

//        private string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Persist Security Info=True;User ID=Admin;Password=adamlambert123;Encrypt=True;TrustServerCertificate=True"; // Make connection string a field

//        //public Guid UserGUID { get; set; }
//        //public Guid TaskGUID { get; set; }
//        //public string Title { get; set; }
//        //public string Note { get; set; }
//        //public TaskStatus Status { get; set; }
//        //public DateTime StartDate { get; set; }
//        //public DateTime DueDate { get; set; }

//        //private Guid SelectedTaskGUID;

//        //private string SelectedTaskStatus;
//        //public Task SelectedTask { get; private set; } 

//        private string SelectedTaskStatus;
//        private Guid SelectedTaskGUID;
//        public manageTask() // Empty form
//        {
//            InitializeComponent();
//        }



//        //****************************************************************************************************************************************
//        private MainMenuForm _mainMenuForm;

//        public void SetMainMenuForm(MainMenuForm mainMenuForm)
//        {
//            _mainMenuForm = mainMenuForm;
//        }

//        private void manageTask_Load_1(object sender, EventArgs e)
//        {
//            statusBox.DataSource = Enum.GetValues(typeof(TaskStatus));
//            //statusBox.SelectedIndex = 0;
//        }

//        public enum TaskStatus
//        {
//            Doing,
//            Upcoming,
//            Completed
//        }




//        //****************************************************************************************************************************************


//        private void addButton_Click(object sender, EventArgs e)
//        {
//            AddTask();
//            //MainMenuForm main = new MainMenuForm();
//            //try
//            //{

//            //    TaskStatus status = (TaskStatus)Enum.Parse(typeof(TaskStatus), statusBox.SelectedItem.ToString());


//            //    string title = titleTextBox.Text;
//            //    string note = noteTextBox.Text;
//            //    DateTime startDate = dateTimePicker1.Value;
//            //    DateTime dueDate = dateTimePicker2.Value;

//            //    // Add the task to the database
//            //    AddTask();


//            //    MessageBox.Show("Task added successfully. Good luck on your Task!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            //    ClearInputFields();

//            //    // Reload tasks in the MainMenuForm
//            //    _mainMenuForm?.LoadTasks(Accounts.UserSession.CurrentUserGUID); // Use null-conditional operator (?.)


//            //    this.Close();
//            //}
//            //catch (Exception ex)
//            //{

//            //    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            //}
//        }





//        //****************************************************************************************************************************************


//        private void deleteButton_Click(object sender, EventArgs e)
//        {
//            DeleteTask();

//        }
//        //****************************************************************************************************************************************
//        private void saveButton_Click(object sender, EventArgs e)
//        {
//            EditTask();
//        }
//        //****************************************************************************************************************************************
//        public void AddTask()
//        {
//            try
//            {

//                Guid userGUID = Accounts.UserSession.CurrentUserGUID;

//                if (userGUID == Guid.Empty)
//                {
//                    MessageBox.Show("User is not logged in."); // Ensure user is logged in
//                    return;
//                }

//                // Validate inputs
//                if (string.IsNullOrWhiteSpace(titleTextBox.Text)) //|| string.IsNullOrWhiteSpace(noteTextBox.Text)
//                {
//                    MessageBox.Show("Title cannot be empty.");
//                    return;
//                }

//                if (statusBox.SelectedItem == null)
//                {
//                    MessageBox.Show("Please select a status before adding a task.");
//                    return;
//                }

//                // Create a new task GUID
//                Guid taskGUID = Guid.NewGuid();
//                TaskStatus status = (TaskStatus)Enum.Parse(typeof(TaskStatus), statusBox.SelectedItem.ToString());
//                string title = titleTextBox.Text;
//                string note = noteTextBox.Text;
//                DateTime startDate = dateTimePicker1.Value;
//                DateTime dueDate = dateTimePicker2.Value;


//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();

//                    string query = "INSERT INTO TaskControl (UserGUID, TaskGUID, Title, Note, Status, [Start Date], [Due Date]) " +
//                                   "VALUES (@UserGUID, @TaskGUID, @Title, @Note, @Status, @StartDate, @DueDate)";

//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = userGUID;
//                        command.Parameters.Add("@TaskGUID", SqlDbType.UniqueIdentifier).Value = taskGUID;
//                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
//                        command.Parameters.Add("@Note", SqlDbType.NVarChar).Value = note;
//                        command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = status.ToString();
//                        command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
//                        command.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;

//                        int rowsAffected = command.ExecuteNonQuery();
//                        if (rowsAffected > 0)
//                        {
//                            MessageBox.Show("Task added successfully!");
//                        }
//                        else
//                        {
//                            MessageBox.Show("Failed to add task.");
//                        }

//                    }
//                    MessageBox.Show("Task added successfully. Good luck on your Task!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    ClearInputFields();

//                    // Reload tasks in the MainMenuForm
//                    _mainMenuForm?.LoadTasks(userGUID); 

//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }


//        private void EditTask()
//        {
//            if (SelectedTaskGUID == Guid.Empty)
//            {
//                MessageBox.Show("No task selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            Guid userGUID = Accounts.UserSession.CurrentUserGUID;

//            string newTitle = titleTextBox.Text;
//            string newNote = noteTextBox.Text;
//            DateTime newStartDate = dateTimePicker1.Value;
//            DateTime newDueDate = dateTimePicker2.Value;
//            string newStatus = statusBox.SelectedItem?.ToString();

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                string query = "UPDATE TaskControl SET Title = @Title, Note = @Note, [Start Date] = @StartDate, [Due Date] = @DueDate, Status = @Status WHERE TaskGUID = @TaskGUID";

//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = newTitle;
//                    command.Parameters.Add("@Note", SqlDbType.NVarChar).Value = newNote;
//                    command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = newStartDate;
//                    command.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = newDueDate;
//                    command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = newStatus;
//                    command.Parameters.Add("@TaskGUID", SqlDbType.UniqueIdentifier).Value = SelectedTaskGUID;

//                    int rowsAffected = command.ExecuteNonQuery();
//                    if (rowsAffected > 0)
//                    {
//                        MessageBox.Show("Task updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        ClearInputFields();

//                        // Reload tasks in the MainMenuForm
//                        _mainMenuForm?.LoadTasks(userGUID);
//                    }
//                    else
//                    {
//                        MessageBox.Show("Failed to update task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//            }
//        }

//        private void DeleteTask()
//        {
//            if (SelectedTaskGUID == Guid.Empty)
//            {
//                MessageBox.Show("No task selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
//            if (confirmResult != DialogResult.Yes)
//                return;

//            Guid userGUID = Accounts.UserSession.CurrentUserGUID;

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                string query = "DELETE FROM TaskControl WHERE TaskGUID = @TaskGUID";

//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.Add("@TaskGUID", SqlDbType.UniqueIdentifier).Value = SelectedTaskGUID;

//                    int rowsAffected = command.ExecuteNonQuery();
//                    if (rowsAffected > 0)
//                    {
//                        MessageBox.Show("Task deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        ClearInputFields();
//                        // Reload tasks in the MainMenuForm
//                        _mainMenuForm?.LoadTasks(userGUID);
//                    }
//                    else
//                    {
//                        MessageBox.Show("Failed to delete task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//            }
//        }

//        //****************************************************************************************************************************************

//        private void ClearInputFields()
//        {
//            titleTextBox.Text = string.Empty;
//            noteTextBox.Text = string.Empty;
//            dateTimePicker1.Value = DateTime.Now;
//            dateTimePicker2.Value = DateTime.Now;
//        }

//        //****************************************************************************************************************************************
//        public void LoadTaskDetails(Guid taskGUID, string title, string note, DateTime startDate, DateTime dueDate, string status)
//        {
//            statusBox.SelectedItem = Enum.Parse(typeof(TaskStatus), status);

//            SelectedTaskGUID = taskGUID;
//            titleTextBox.Text = title;
//            noteTextBox.Text = note;
//            dateTimePicker1.Value = startDate;
//            dateTimePicker2.Value = dueDate;
//        }



//        //****************************************************************************************************************************************
//        private void pictureBox1_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }

//        private void refreshButton_Click(object sender, EventArgs e)
//        {
//            statusBox.SelectedIndex = 0;
//            titleTextBox.Text = string.Empty;
//            noteTextBox.Text = string.Empty;
//            dateTimePicker1.Value = DateTime.Now;
//            dateTimePicker2.Value = DateTime.Now;
//        }
//    }



//}
