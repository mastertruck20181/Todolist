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
using TaskStatusEnum = List_To_Do__Tab_.taskReminder.TaskReminder.TaskStatus;


namespace List_To_Do__Tab_
{
    public partial class taskReminder : Form
    {

        private string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Persist Security Info=True;User ID=Admin;Password=adamlambert123;Encrypt=True;TrustServerCertificate=True";

        public class TaskReminder
        {
            public Guid TaskGUID { get; }
            public string Title { get; }
            public string Tag { get; }
            public DateTime DueDate { get; }
            public TaskStatus Status { get; }

            public TaskReminder(Guid taskGUID, string title, string tag, DateTime dueDate, TaskStatus status)
            {
                TaskGUID = taskGUID;
                Title = title;
                Tag = tag;
                DueDate = dueDate;
                Status = status;
            }
            public enum TaskStatus
            {
                Doing,
                Upcoming,
                Completed
            }
        }


        private List<TaskReminder> tasks = new List<TaskReminder>();
        private int currentIndex = 0;
        private MainMenuForm mainMenu;


        private void taskReminder_Load(object sender, EventArgs e)
        {
            reminderStatus.DataSource = Enum.GetValues(typeof(TaskReminder.TaskStatus));
            reminderTag.DataSource = LoadTags();
            LoadReminders();


        }



        public int GetTaskCount()
        {
            return tasks.Count;
        }

        public void SetTasks(List<TaskReminder> tasks)
        {
            this.tasks = tasks;
            this.currentIndex = 0;
            DisplayCurrentTask();
        }

        //****************************************************************************************************************************************

        public taskReminder(MainMenuForm mainMenuForm)
        {
            InitializeComponent();
            this.mainMenu = mainMenuForm; // Store the reference

            //LoadComboBoxData();
            DisplayCurrentTask();
        }




        //****************************************************************************************************************************************
        public void LoadReminders()
        {
            List<TaskReminder> expiredTasks = new List<TaskReminder>();
            try
            {
                Guid userGUID = Accounts.UserSession.CurrentUserGUID;
                if (userGUID == Guid.Empty)
                {
                    MessageBox.Show("User is not logged in or has an invalid GUID.");
                    return;
                }

                DateTime thirtyDaysFromNow = DateTime.Now.AddDays(30);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TaskGUID, Status, Title, Tag, [Due Date] FROM TaskControl WHERE UserGUID = @UserGUID AND Status != 'Completed' AND [Due Date] <= @DueDate ORDER BY [Due Date] ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = userGUID;
                        command.Parameters.AddWithValue("@DueDate", thirtyDaysFromNow);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Guid taskGUID = reader.GetGuid(0);
                                string statusString = reader.GetString(1).Trim(); // Get Status from DB
                                TaskStatusEnum status;

                                if (Enum.TryParse(statusString, true, out TaskStatusEnum parsedStatus))
                                {
                                    status = parsedStatus;
                                }
                                else
                                {
                                    MessageBox.Show($"Error parsing status: '{statusString}'.");
                                    continue; // Skip the invalid status
                                }

                                string title = reader.GetString(2);
                                string tag = reader.GetString(3);
                                DateTime dueDate = reader.GetDateTime(4);

                                expiredTasks.Add(new TaskReminder(taskGUID, title, tag, dueDate, status));

                            }
                        }
                    }

                    tasks = expiredTasks;

                    if (tasks.Count > 0)
                    {
                        currentIndex = 0;
                        mainMenu.StartReminderBlink();
                        List<string> tags = LoadTags();
                        reminderTag.DataSource = tags;
                        DisplayCurrentTask();

                    }
                    else
                    {
                        mainMenu.StopReminderBlink();
                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while loading reminders: " + ex.Message);
            }
        }
        private void DisplayCurrentTask()
        {
            if (tasks.Count == 0) return;

            if (tasks.Count == 1)
            {
                leftBox.Visible = false;
                rightBox.Visible = false;
            }
            else
            {
                leftBox.Visible = true;
                rightBox.Visible = true;
            }
            
            taskTotal.Text = $"Hey there! You’ve got {tasks.Count} tasks coming up!";

            taskCount.Text = $"{currentIndex + 1} of {tasks.Count}";

            leftBox.Visible = (currentIndex > 0);
            rightBox.Visible = (currentIndex < tasks.Count - 1);


            TaskReminder task = tasks[currentIndex];
            reminderTitle.Text = task.Title;
            reminderDueDate.Value = task.DueDate;

            // Check if combo boxes are initialized before setting SelectedItem
            if (reminderStatus.DataSource != null)
            {
                reminderStatus.SelectedItem = task.Status;
            }

            if (reminderTag.DataSource != null && reminderTag.Items.Contains(task.Tag))
            {
                reminderTag.SelectedItem = task.Tag;
            }
        }


        private List<string> LoadTags()
        {
            List<string> tags = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Tag FROM TaskControl WHERE Tag IS NOT NULL AND Tag <> '' ORDER BY Tag";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tags.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading tags: " + ex.Message);
            }

            return tags;
        }

        //****************************************************************************************************************************************
        //Button modify

        private void leftBox_Click(object sender, EventArgs e)
        {
            if (tasks.Count > 1 && currentIndex > 0) // Prevent going before first task
            {
                currentIndex--;
                DisplayCurrentTask();
            }
        }

        private void rightBox_Click(object sender, EventArgs e)
        {
            if (tasks.Count > 1 && currentIndex < tasks.Count - 1) // Prevent going past last task
            {
                currentIndex++;
                DisplayCurrentTask();
            }
        }

        private void closeBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
