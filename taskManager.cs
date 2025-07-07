using List_To_Do__Tab_.TaskControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace List_To_Do__Tab_
{
    public partial class taskManager : Form
    {

        private string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Persist Security Info=True;User ID=Admin;Password=adamlambert123;Encrypt=True;TrustServerCertificate=True";
        public string SelectedTaskStatus;
        public Guid SelectedTaskGUID;
        public string SelectedTag;
        public enum TaskStatus
        {
            Doing,
            Upcoming,
            Completed
        }

        //public string TitleText
        //{
        //    get => titleTextBox.Text;
        //    set => titleTextBox.Text = value;
        //}

        //public string NoteText
        //{
        //    get => noteTextBox.Text;
        //    set => noteTextBox.Text = value;
        //}

        //public DateTime StartDateValue
        //{
        //    get => dateTimePicker1.Value;
        //    set => dateTimePicker1.Value = value;
        //}
        //public DateTime DueDateValue
        //{
        //    get => dateTimePicker2.Value;
        //    set => dateTimePicker2.Value = value;
        //}

        //public string TagManagerSelectedItem
        //{
        //    get => tagManager.SelectedItem?.ToString();
        //    set => tagManager.SelectedItem = value;
        //}

        //public string StatusBoxSelectedItem
        //{
        //    get => statusBox.SelectedItem?.ToString();
        //    set => statusBox.SelectedItem = value;
        //}



        private MainMenuForm _mainMenuForm;
        public void SetMainMenuForm(MainMenuForm mainMenuForm)
        {
            _mainMenuForm = mainMenuForm;
        }


        //public Panel[] defaultControls;
        //public taskManagerControl taskmanagerControl;
        //****************************************************************************************************************************************



        private void taskManager_Load(object sender, EventArgs e)
        {
            statusBox.DataSource = Enum.GetValues(typeof(TaskStatus));
            TagManager();
            tagManager.SelectedIndexChanged += tagManager_SelectedIndexChanged;

            //taskmanagerControl = new taskManagerControl();
            //taskmanagerControl.SetParentForm(this); // Pass reference from taskManagerControl to taskManager 

            //taskPanelControl(taskmanagerControl);
        }


       
        //private void taskPanelControl(System.Windows.Forms.UserControl control)
        //{
        //    control.Dock = DockStyle.Fill;
        //    taskPanel.Controls.Clear();
        //    taskPanel.Controls.Add(control);
        //    control.Show();
        //}


        

        public taskManager() // empty method
        {
            InitializeComponent();

        }
        public taskManager(Guid taskGUID, string title, string note, DateTime startDate, DateTime dueDate, string status, string tags) // pre-filled method
        {
            InitializeComponent();

            SelectedTaskStatus = status;
            SelectedTaskGUID = taskGUID;
            SelectedTag = tags;

            // Set UI 
            titleTextBox.Text = title;
            noteTextBox.Text = note;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = dueDate;
            statusBox.SelectedItem = SelectedTaskStatus;
            tagManager.SelectedItem = SelectedTag;
        }

        //****************************************************************************************************************************************
        // Tag control

        public List<string> tags = new List<string>(); // Initialize as an empty list

        public void TagManager()
        {
            tags.Clear(); // Clear the list

            // Add default tags first
            tags.AddRange(new List<string> { "None", "Home", "Work", "Grocery" });

            try
            {
                Guid userGUID = Accounts.UserSession.CurrentUserGUID;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Tag FROM TagName WHERE UserGUID = @UserGUID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = userGUID;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tags.Add(reader["Tag"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tags: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tags.Add("Add another tag"); // Add "Add another tag" at the end

            tagManager.DataSource = null;
            tagManager.DataSource = new List<string>(tags);
        }




        private bool isRefreshing = false; // Flag to indicate if the ComboBox is being refreshed

        public void tagManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRefreshing)
            {
                return; // Ignore the event if refreshing
            }

            if (tagManager.SelectedItem != null && tagManager.SelectedItem.ToString() == "Add another tag")
            {
                TagManager tagmanager = new TagManager();
                if (tagmanager.ShowDialog() == DialogResult.OK)
                {
                    string newTag = tagmanager.NewTag;

                    // Prevent duplicates
                    if (!string.IsNullOrWhiteSpace(newTag) && !tags.Contains(newTag))
                    {
                        tags.Insert(tags.Count - 1, newTag); // Add before "Add another tag"
                        RefreshTagManager(); // Use a separate Refresh method
                        tagManager.SelectedItem = newTag; // Select the newly added tag
                    }
                }
            }
        }
        public void tagDelete_Click(object sender, EventArgs e)
        {
            if (tagManager.SelectedItem != null)
            {
                string selectedTag = tagManager.SelectedItem.ToString();

                if (selectedTag != "None" && selectedTag != "Home" && selectedTag != "Work" && selectedTag != "Grocery" && selectedTag != "Add another tag")
                {
                    try
                    {
                        Guid userGUID = Accounts.UserSession.CurrentUserGUID;
                        if (userGUID == Guid.Empty)
                        {
                            MessageBox.Show("User is not logged in.");
                            return;
                        }

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Delete the tag from the database
                            string deleteQuery = "DELETE FROM TagName WHERE UserGUID = @UserGUID AND Tag = @Tag";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                            {
                                deleteCommand.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = userGUID;
                                deleteCommand.Parameters.Add("@Tag", SqlDbType.NVarChar).Value = selectedTag;

                                int rowsAffected = deleteCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    tags.Remove(selectedTag); // Remove from the list
                                    TagManager(); // Refresh the ComboBox
                                    tagManager.SelectedIndex = tags.Count > 0 ? 0 : -1; // Select a default item
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete tag from the database.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot delete default tags or 'Add another tag'.");
                }
            }
            else
            {
                MessageBox.Show("Please select a tag to delete.");
            }
        }

        public void RefreshTagManager() // Separate method for refreshing
        {
            isRefreshing = true; // Set the flag
            TagManager(); // Refresh the ComboBox
            isRefreshing = false; // Reset the flag
        }
        //****************************************************************************************************************************************




        //****************************************************************************************************************************************

        // Basic Button

        private void addButton_Click_1(object sender, EventArgs e)
        {
            AddTask();
        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            DeleteTask();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditTask();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            statusBox.SelectedIndex = 0;
            titleTextBox.Text = string.Empty;
            noteTextBox.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            tagManager.SelectedIndex = 0;
        }

       
        //****************************************************************************************************************************************
       // Method for operation
        public void AddTask()
        {
            try
            {

                Guid userGUID = Accounts.UserSession.CurrentUserGUID;

                if (userGUID == Guid.Empty)
                {
                    MessageBox.Show("User is not logged in."); // Ensure user is logged in
                    return;
                }

                // Validate inputs
                if (string.IsNullOrWhiteSpace(titleTextBox.Text)) //|| string.IsNullOrWhiteSpace(noteTextBox.Text)
                {
                    MessageBox.Show("Title cannot be empty.");
                    return;
                }

                if (statusBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a status before adding a task.");
                    return;
                }

                // Create a new task GUID
                Guid taskGUID = Guid.NewGuid();
                TaskStatus status = (TaskStatus)Enum.Parse(typeof(TaskStatus), statusBox.SelectedItem.ToString());
                string title = titleTextBox.Text;
                string note = noteTextBox.Text;
                DateTime startDate = dateTimePicker1.Value;
                DateTime dueDate = dateTimePicker2.Value;
                string tag = tagManager.SelectedItem.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO TaskControl (UserGUID, TaskGUID, Title, Note, Status, [Start Date], [Due Date], Tag) " +
                                   "VALUES (@UserGUID, @TaskGUID, @Title, @Note, @Status, @StartDate, @DueDate, @Tag)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = userGUID;
                        command.Parameters.Add("@TaskGUID", SqlDbType.UniqueIdentifier).Value = taskGUID;
                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                        command.Parameters.Add("@Note", SqlDbType.NVarChar).Value = note;
                        command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = status.ToString();
                        command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                        command.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;
                        command.Parameters.Add("@Tag", SqlDbType.NVarChar).Value = tag;


                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task added successfully. Good luck on your Task!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add task.");
                        }

                    }
                    
                    ClearInputFields();

                    // Reload tasks in the MainMenuForm
                    _mainMenuForm?.LoadTasks(); // Use null-conditional operator (?.)

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void EditTask()
        {
            if (SelectedTaskGUID == Guid.Empty)
            {
                MessageBox.Show("No task selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newTitle = titleTextBox.Text;
            string newNote = noteTextBox.Text;
            DateTime newStartDate = dateTimePicker1.Value;
            DateTime newDueDate = dateTimePicker2.Value;
            string newStatus = statusBox.SelectedItem?.ToString();
            string newTag = tagManager.SelectedItem?.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE TaskControl SET Title = @Title, Note = @Note, [Start Date] = @StartDate, [Due Date] = @DueDate, Status = @Status, Tag = @Tag WHERE TaskGUID = @TaskGUID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = newTitle;
                    command.Parameters.Add("@Note", SqlDbType.NVarChar).Value = newNote;
                    command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = newStartDate;
                    command.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = newDueDate;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = newStatus;
                    command.Parameters.Add("@Tag", SqlDbType.NVarChar).Value = newTag ?? (object)DBNull.Value; ;
                    command.Parameters.Add("@TaskGUID", SqlDbType.UniqueIdentifier).Value = SelectedTaskGUID;


                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        ClearInputFields();
                        MessageBox.Show("Task updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _mainMenuForm?.LoadTasks(); 
                    }
                    else
                    {
                        MessageBox.Show("Failed to update task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void DeleteTask()
        {
            if (SelectedTaskGUID == Guid.Empty)
            {
                MessageBox.Show("No task selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult != DialogResult.Yes)
                return;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM TaskControl WHERE TaskGUID = @TaskGUID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@TaskGUID", SqlDbType.UniqueIdentifier).Value = SelectedTaskGUID;

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        ClearInputFields();
                        MessageBox.Show("Task deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _mainMenuForm?.LoadTasks();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void RefreshTask()
        {
            statusBox.SelectedIndex = 0;
            titleTextBox.Text = string.Empty;
            noteTextBox.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            tagManager.SelectedIndex = 0;
        }


        //****************************************************************************************************************************************


        private void ClearInputFields()
        {
            statusBox.SelectedIndex = 0;
            titleTextBox.Text = string.Empty;
            noteTextBox.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            tagManager.SelectedIndex = 0;
        }

        public void LoadTaskDetails(Guid taskGUID, string title, string note, DateTime startDate, DateTime dueDate, string SelectedTaskStatus,string tag)
        {
            if (Enum.TryParse(SelectedTaskStatus, out TaskStatus status))
            {
                statusBox.SelectedItem = status;
            }
            else
            {
                MessageBox.Show("Invalid status value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SelectedTaskGUID = taskGUID;
            titleTextBox.Text = title;
            noteTextBox.Text = note;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = dueDate;
            tagManager.SelectedItem = tag;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        






        //****************************************************************************************************************************************



        //****************************************************************************************************************************************

    }
}
