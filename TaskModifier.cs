//using List_To_Do__Tab_;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient; // Added for SqlConnection
//using System.Threading.Tasks;
//using System.Windows.Forms;

//public enum TaskStatus
//{
//    ToDo,
//    Upcoming,
//    Completed
//}







//public class Task
//{

//    public Guid UserGUID { get; set; }
//    public Guid TaskGUID { get; set; }
//    public string Title { get; set; }
//    public string Note { get; set; }
//    public TaskStatus Status { get; set; }
//    public DateTime StartDate { get; set; }
//    public DateTime DueDate { get; set; }

//    public Task(Guid userGUID, Guid taskGUID, string title, string note, TaskStatus status, DateTime startDate, DateTime dueDate)
//    {
//        UserGUID = userGUID;
//        TaskGUID = taskGUID; 
//        Title = title;
//        Note = note;
//        Status = status;
//        StartDate = startDate;
//        DueDate = dueDate;
//    }
//}

//public class TaskModifier
//{
//    private string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Persist Security Info=True;User ID=Admin;Password=adamlambert123;Encrypt=True;TrustServerCertificate=True";



//    public ListView todoListView;
//    public ListView upcomingListView;
//    public ListView completedListView;






//    public void setListView(ListView todoListView, ListView upcomingListView, ListView completedListView)
//    {
//        this.todoListView = todoListView;
//        this.upcomingListView = upcomingListView;
//        this.completedListView = completedListView;

//        // Set the view mode for each ListView
//        todoListView.View = View.Details;
//        todoListView.Columns.Add("Title", 200, HorizontalAlignment.Center);
//        todoListView.Columns.Add("Note", 300, HorizontalAlignment.Center);
//        todoListView.Columns.Add("Start Date", 100, HorizontalAlignment.Center);
//        todoListView.Columns.Add("Due Date", 100, HorizontalAlignment.Center);

//        upcomingListView.View = View.Details;
//        upcomingListView.Columns.Add("Title", 200, HorizontalAlignment.Center);
//        upcomingListView.Columns.Add("Note", 300, HorizontalAlignment.Center);
//        upcomingListView.Columns.Add("Start Date", 100, HorizontalAlignment.Center);
//        upcomingListView.Columns.Add("Due Date", 100, HorizontalAlignment.Center);

//        completedListView.View = View.Details;
//        completedListView.Columns.Add("Title", 200, HorizontalAlignment.Center);
//        completedListView.Columns.Add("Note", 300, HorizontalAlignment.Center);
//        completedListView.Columns.Add("Start Date", 100, HorizontalAlignment.Center);
//        completedListView.Columns.Add("Due Date", 100, HorizontalAlignment.Center);

//    }

//    //public void AddTask(string title, string note, TaskStatus status, DateTime startDate, DateTime dueDate)
//    //{
//    //    using (SqlConnection connection = new SqlConnection(connectionString))
//    //    {
//    //        connection.Open();

//    //        Guid userGUID = Accounts.UserSession.CurrentUserGUID;
//    //        Guid taskGUID = Guid.NewGuid();

//    //        // Check if the TaskGUID already exists
//    //        string checkQuery = "SELECT COUNT(*) FROM TaskControl WHERE TaskGUID = @TaskGUID";
//    //        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
//    //        {
//    //            checkCommand.Parameters.AddWithValue("@TaskGUID", taskGUID);

//    //            int count = (int)checkCommand.ExecuteScalar();
//    //            if (count > 0)
//    //            {
//    //                MessageBox.Show("A task with the same GUID already exists. Generating a new GUID.");
//    //                taskGUID = Guid.NewGuid(); // Generate a new GUID
//    //            }

//    //        }

//    //        string insertQuery = "INSERT INTO TaskControl (TaskGUID, Title, Note, Status, [Start Date], [Due Date], UserGUID) VALUES (@TaskGUID, @Title, @Note, @Status, @StartDate, @DueDate, @UserGUID)";
//    //        using (SqlCommand command = new SqlCommand(insertQuery, connection))
//    //        {
//    //            command.Parameters.AddWithValue("@TaskGUID", taskGUID);
//    //            command.Parameters.AddWithValue("@Title", title);
//    //            command.Parameters.AddWithValue("@Note", note);
//    //            command.Parameters.AddWithValue("@Status", status.ToString());
//    //            command.Parameters.AddWithValue("@StartDate", startDate);
//    //            command.Parameters.AddWithValue("@DueDate", dueDate);
//    //            command.Parameters.AddWithValue("@UserGUID", userGUID);

//    //            command.ExecuteNonQuery();
//    //        }
//    //    }
//    //}







//    public void LoadTasks(Guid userGUID)
//    {


//        List<Task> tasks = GetTasks(userGUID);

//        todoListView.Items.Clear();
//        upcomingListView.Items.Clear();
//        completedListView.Items.Clear();



//        foreach (Task task in tasks)
//        {
//            ListViewItem item = new ListViewItem(task.Title);
//            item.SubItems.Add(task.Note);
//            item.SubItems.Add(task.StartDate.ToString("dd-MM-yyyy"));
//            item.SubItems.Add(task.DueDate.ToString("dd-MM-yyyy"));

//            switch (task.Status)
//            {
//                case TaskStatus.ToDo:
//                    todoListView.Items.Add(item);
//                    break;
//                case TaskStatus.Upcoming:
//                    upcomingListView.Items.Add(item);
//                    break;
//                case TaskStatus.Completed:
//                    completedListView.Items.Add(item);
//                    break;
//            }
//        }
//        // Refresh the ListViews to display the bound data
//        todoListView.Refresh();
//        upcomingListView.Refresh();
//        completedListView.Refresh();

//        MessageBox.Show($"Tasks remaining: {tasks.Count} task(s)");

//    }


//    public List<Task> GetTasks(Guid userGUID)
//    {
//        List<Task> tasks = new List<Task>();

//        try
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                string query = "SELECT TaskGUID, Title, Note, [Start Date], [Due Date], Status FROM TaskControl WHERE UserGUID = @userGUID";

//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@userGUID", userGUID);

//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            Guid taskGUID = reader.GetGuid(0);
//                            string title = reader.GetString(1);
//                            string note = reader.GetString(2);
//                            DateTime startDate = reader.GetDateTime(3);
//                            DateTime dueDate = reader.GetDateTime(4);
//                            TaskStatus status = (TaskStatus)Enum.Parse(typeof(TaskStatus), reader.GetString(5));

//                            Task task = new Task(userGUID, taskGUID, title, note, status, startDate, dueDate);
//                            tasks.Add(task);
//                        }
//                    }
//                }
//            }
//        }
//        catch (SqlException ex)
//        {
//            MessageBox.Show("An error occurred while loading tasks: " + ex.Message);
//        }

//        return tasks;
//    }
//}