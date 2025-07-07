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

namespace List_To_Do__Tab_.TaskControl
{
    public partial class FilterControl : UserControl
    {
        private MainMenuForm _mainMenuForm; // Class-level field
        private void FilterControl_Load(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu(); // Local variable
            SetListView(filterListView);
            LoadTasks(); // Accessing class-level field
        }
        public FilterControl()
        {
            InitializeComponent();

        }

        //****************************************************************************************************************************************

        private string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Persist Security Info=True;User ID=Admin;Password=adamlambert123;Encrypt=True;TrustServerCertificate=True";
        public enum TaskStatus
        {
            Doing,
            Upcoming,
            Completed
        }
        public class Task
        {

            public Guid UserGUID { get; set; }
            public Guid TaskGUID { get; set; }
            public string Title { get; set; }
            public string Note { get; set; }
            public TaskStatus Status { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime DueDate { get; set; }
            public string Tag { get; set; }

            public Task(Guid userGUID, Guid taskGUID, string title, string note, TaskStatus status, DateTime startDate, DateTime dueDate, string tag)
            {
                UserGUID = userGUID;
                TaskGUID = taskGUID;
                Title = title;
                Note = note;
                Status = status;
                StartDate = startDate;
                DueDate = dueDate;
                Tag = tag;
            }
        }
        private List<Task> allTasks = new List<Task>(); // Class-level for task

        public class TaskInfo 
        {
            public Guid TaskGUID { get; set; }
            public TaskStatus Status { get; set; }
        }

        public class FilterData
        {
            public TaskStatus? StatusFilter { get; set; }
            public string TagFilter { get; set; }
            public string TagSortOrder { get; set; } = null;
            public string TitleSortOrder { get; set; } = null;

            public DateTime? DueDateFilter { get; set; } = null;
            public string DueDateLengthSort { get; set; }
            public string DueDateComparison { get; set; }
           


        }

        private FilterData currentFilter = new FilterData();
        public void ClearFilters()
        {
            currentFilter = new FilterData(); // Reset the filter object ***
            LoadTasks(); 
        }
        //****************************************************************************************************************************************

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (filterMenu.Visible)
            {
                filterMenu.Close();
            }
            else
            {
                filterMenu.Show(filterButton, new Point(0, filterButton.Height));
            }
        }

        private void FilterCondition(ref string query, List<SqlParameter> parameters)
        {
            List<string> whereConditions = new List<string>();
            List<string> orderByConditions = new List<string>();

            // Apply Status filter
            if (currentFilter.StatusFilter.HasValue)
            {
                whereConditions.Add("Status = @status");
                parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar) { Value = currentFilter.StatusFilter.ToString() });
            }

            // Apply Tag filter
            if (!string.IsNullOrEmpty(currentFilter.TagFilter))
            {
                whereConditions.Add("Tag = @tag");
                parameters.Add(new SqlParameter("@tag", SqlDbType.NVarChar) { Value = currentFilter.TagFilter });
            }

            // Apply Due Date comparison filters
            if (!string.IsNullOrEmpty(currentFilter.DueDateComparison))
            {
                switch (currentFilter.DueDateComparison.ToLower())
                {
                    case "today":
                        whereConditions.Add("CAST([Due Date] AS DATE) = CAST(GETDATE() AS DATE)");
                        break;
                    case "this week":
                        whereConditions.Add("[Due Date] >= DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 0) AND [Due Date] < DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 7)");
                        break;
                    case "this month":
                        whereConditions.Add("YEAR([Due Date]) = YEAR(GETDATE()) AND MONTH([Due Date]) = MONTH(GETDATE())");
                        break;
                    case "this year":
                        whereConditions.Add("YEAR([Due Date]) = YEAR(GETDATE())");
                        break;
                }
            }

            // Sorting Conditions (Only one ORDER BY allowed)
            if (!string.IsNullOrEmpty(currentFilter.TagSortOrder))
            {
                orderByConditions.Add($"Tag {currentFilter.TagSortOrder}");
            }
            if (!string.IsNullOrEmpty(currentFilter.DueDateLengthSort))
            {
                orderByConditions.Add($"[Due Date] {(currentFilter.DueDateLengthSort.ToLower() == "ascending" ? "ASC" : "DESC")}");
            }
            if (!string.IsNullOrEmpty(currentFilter.TitleSortOrder))
            {
                orderByConditions.Add($"Title {currentFilter.TitleSortOrder}");
            }

            // Append WHERE conditions if any exist
            if (whereConditions.Count > 0)
            {
                query += " AND " + string.Join(" AND ", whereConditions);
            }

            // Append ORDER BY if any sorting conditions exist
            if (orderByConditions.Count > 0)
            {
                query += " ORDER BY " + string.Join(", ", orderByConditions);
            }
        }


        public void LoadTasks()
        {
            try
            {
                // ✅ Get UserGUID from session
                Guid userGUID = Accounts.UserSession.CurrentUserGUID;
                //MessageBox.Show($"Current UserGUID: {Accounts.UserSession.CurrentUserGUID}");



                if (userGUID == Guid.Empty)
                {
                    MessageBox.Show("User is not logged in or has an invalid GUID.");
                    return;
                }

                filterListView.Items.Clear();
               

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM TaskControl WHERE UserGUID = @userGUID"; //TaskGUID, Tag, Title, Note, [Start Date], [Due Date], Status
                    List<SqlParameter> parameters = new List<SqlParameter>
                    {
                    new SqlParameter("@UserGUID", SqlDbType.UniqueIdentifier) { Value = userGUID }
                    };


                    //// Apply Status filter
                    //if (currentFilter.StatusFilter.HasValue)
                    //{
                    //    query += " AND Status = @status";
                    //    parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar) { Value = currentFilter.StatusFilter.ToString() });
                    //}
                    //// Apply Tag filter
                    //if (!string.IsNullOrEmpty(currentFilter.TagFilter))
                    //{
                    //    query += " AND Tag = @tag";
                    //    parameters.Add(new SqlParameter("@tag", SqlDbType.NVarChar) { Value = currentFilter.TagFilter });
                    //}

                    //    //Tag Sorting
                    //    if (!string.IsNullOrEmpty(currentFilter.TagSortOrder))
                    //    {
                    //        query += $" ORDER BY Tag {currentFilter.TagSortOrder}";
                    //    }


                    //// Apply Title sort
                    //if (!string.IsNullOrEmpty(currentFilter.TitleSortOrder))
                    //{
                    //    query += $" ORDER BY Title {currentFilter.TitleSortOrder}";
                    //}

                    //// Apply Due Date comparison filters
                    //if (!string.IsNullOrEmpty(currentFilter.DueDateComparison))
                    //{
                    //    switch (currentFilter.DueDateComparison.ToLower())
                    //    {
                    //        case "today":
                    //            query += " AND CAST([Due Date] AS DATE) = CAST(GETDATE() AS DATE)";
                    //            break;
                    //        case "this week":
                    //            query += " AND [Due Date] >= DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 0) AND [Due Date] < DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 7)";
                    //            break;
                    //        case "this month":
                    //            query += " AND YEAR([Due Date]) = YEAR(GETDATE()) AND MONTH([Due Date]) = MONTH(GETDATE())";
                    //            break;
                    //        case "this year":
                    //            query += " AND YEAR([Due Date]) = YEAR(GETDATE())";
                    //            break;
                    //    }
                    //}

                    //// Apply Due Date sorting
                    //if (!string.IsNullOrEmpty(currentFilter.DueDateLengthSort))
                    //{
                    //    query += $" ORDER BY [Due Date] {(currentFilter.DueDateLengthSort.ToLower() == "ascending" ? "ASC" : "DESC")}";
                    //}


                    FilterCondition(ref query, parameters);  // Modify query based on filter conditions



                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters.ToArray()); // Add all parameters

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tag = reader["Tag"] == DBNull.Value || string.IsNullOrEmpty(reader["Tag"].ToString()) ? "None" : reader["Tag"].ToString();
                                ListViewItem item = new ListViewItem(tag);
                                item.SubItems.Add(reader["Title"].ToString());
                                item.SubItems.Add(reader["Note"].ToString());
                                item.SubItems.Add(Convert.ToDateTime(reader["Start Date"]).ToString("dd-MM-yyyy"));
                                item.SubItems.Add(Convert.ToDateTime(reader["Due Date"]).ToString("dd-MM-yyyy"));

                                TaskStatus status;
                                if (Enum.TryParse(reader["Status"].ToString().Trim(), out status))
                                {
                                    item.Tag = new TaskInfo { TaskGUID = Guid.Parse(reader["TaskGUID"].ToString()), Status = status };
                                }
                                else
                                {
                                    string errorMessage = $"Error parsing TaskStatus: {reader["Status"].ToString()} for TaskGUID: {reader["TaskGUID"].ToString()}";
                                    Console.WriteLine(errorMessage);
                                    throw new InvalidOperationException(errorMessage);
                                }

                                filterListView.Items.Add(item);
                            }

                            filterListView.Refresh();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while loading tasks: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void filterListView_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filterListView.SelectedItems.Count > 0 && filterListView.SelectedItems[0].Tag is TaskInfo taskInfo)
            {
                MessageBox.Show($"Selected Task Status: {taskInfo.Status}");
            }
        }
        //****************************************************************************************************************************************

        private void filterListView_ColumnHeaderPaint(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.LightGray))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            e.DrawText();
        }

        private void filterListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawText(TextFormatFlags.Left);
        }

        private void filterListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true; // Use default drawing for rows, only header is light grey.
        }





        //****************************************************************************************************************************************
        // Modify Button

        


        private void refreshButton_Click(object sender, EventArgs e)
        {
            ClearFilters();

        }
        //private void searchButton_Click(object sender, EventArgs e)
        //{

        //    //LoadTasks(); 

        //}
        


        //private void searchBox_TextChanged(object sender, EventArgs e)
        //{
        //    string input = searchBox.Text.Trim().ToLower();
        //    var filteredTasks = string.IsNullOrEmpty(input)
        //        ? allTasks
        //        : allTasks.Where(task =>
        //            new[] { task.Tag, task.Title, task.Note, task.Status.ToString(),
        //            task.StartDate.ToString("dd-MM-yyyy"), task.DueDate.ToString("dd-MM-yyyy") }
        //            .Any(field => field.ToLower().Contains(input)))
        //        .ToList();

        //    UpdateListView(filteredTasks);
        //}

        //private void UpdateListView(List<Task> tasks)
        //{
        //    filterListView.Items.Clear();
        //    tasks.ForEach(task =>
        //    {
        //        var item = new ListViewItem(task.Tag)
        //        {
        //            Tag = new TaskInfo { TaskGUID = task.TaskGUID, Status = task.Status }
        //        };
        //        item.SubItems.AddRange(new[] { task.Title, task.Note, task.StartDate.ToString("dd-MM-yyyy"), task.DueDate.ToString("dd-MM-yyyy") });
        //        filterListView.Items.Add(item);
        //    });
        //}










        //Filter Condition to sort out the tasks       
        //Sorting by Order (Title - Tag)

        private void alphabetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ClearFilters();
            //currentFilter.TitleSortOrder = (currentFilter.TitleSortOrder == "ASC") ? "DESC" : "ASC";
            //LoadTasks();

            // Toggle Title Sorting
            if (currentFilter.TitleSortOrder == "ASC")
                currentFilter.TitleSortOrder = "DESC";
            else
                currentFilter.TitleSortOrder = "ASC";

            // Reset other sorting filters
            currentFilter.TagSortOrder = null;
            currentFilter.DueDateLengthSort = null;

            LoadTasks();
        }

       
        private void tagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ClearFilters();
            //currentFilter.TagSortOrder = (currentFilter.TagSortOrder == "ASC") ? "DESC" : "ASC";
            //LoadTasks();

            // Toggle Tag Sorting
            if (currentFilter.TagSortOrder == "ASC")
                currentFilter.TagSortOrder = "DESC";
            else
                currentFilter.TagSortOrder = "ASC";

            // Reset other sorting filters
            currentFilter.TitleSortOrder = null;
            currentFilter.DueDateLengthSort = null;

            LoadTasks();
        }

        //Due Date Condition
        private void ascendingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currentFilter.DueDateLengthSort = "ascending";
            currentFilter.DueDateComparison = null; // Reset filtering when sorting
            LoadTasks();
        }

        private void descendingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currentFilter.DueDateLengthSort = "descending";
            currentFilter.DueDateComparison = null; // Reset filtering when sorting
            LoadTasks();
        }

        private void todayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currentFilter.DueDateComparison = "today";
            currentFilter.DueDateLengthSort = null; // Reset sorting when filtering
            LoadTasks();
        }

        private void thisWeekToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currentFilter.DueDateComparison = "this week";
            currentFilter.DueDateLengthSort = null; // Reset sorting when filtering
            LoadTasks();
        }

        private void thisMonthToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currentFilter.DueDateComparison = "this month";
            currentFilter.DueDateLengthSort = null; // Reset sorting when filtering
            LoadTasks();
        }

        private void thisYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentFilter.DueDateComparison = "this year";
            currentFilter.DueDateLengthSort = null; // Reset sorting when filtering
            LoadTasks();
        }


        //Status Filter
        private void doingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentFilter.StatusFilter = TaskStatus.Doing;
            LoadTasks();
        }

        private void upcomingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentFilter.StatusFilter = TaskStatus.Upcoming;
            LoadTasks();
        }

        private void completedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentFilter.StatusFilter = TaskStatus.Completed;
            LoadTasks();
        }




        private void filterMenu_Opening(object sender, CancelEventArgs e)
        {
            // Disable already applied filter options
            todayToolStripMenuItem1.Enabled = (currentFilter.DueDateComparison != "today");
            thisWeekToolStripMenuItem1.Enabled = (currentFilter.DueDateComparison != "this week");
            thisMonthToolStripMenuItem1.Enabled = (currentFilter.DueDateComparison != "this month");
            thisYearToolStripMenuItem.Enabled = (currentFilter.DueDateComparison != "this year");

            // Disable sorting options when a due date filter is active
            ascendingToolStripMenuItem1.Enabled = (currentFilter.DueDateComparison == null);
            descendingToolStripMenuItem1.Enabled = (currentFilter.DueDateComparison == null);
        }
        //****************************************************************************************************************************************
        // Set list view and colored Column Header
        private void SetListView(ListView listView)
        {
            
            filterListView.View = View.Details;
            filterListView.Columns.Add("Tag", 100, HorizontalAlignment.Center);
            filterListView.Columns.Add("Title", 250, HorizontalAlignment.Center);
            filterListView.Columns.Add("Note", 350, HorizontalAlignment.Center);
            filterListView.Columns.Add("Start Date", 100, HorizontalAlignment.Center);
            filterListView.Columns.Add("Due Date", 100, HorizontalAlignment.Center);

            filterListView.OwnerDraw = true;
            filterListView.DrawSubItem += RowPaint;
            filterListView.DrawColumnHeader += ColumnHeaderPaint;

        }


        private void ColumnHeaderPaint(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(180, 180, 180)))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            e.DrawText();
        }

        private void SubItemPaint(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawText(TextFormatFlags.Left); // 🔹 Draw text for all columns
        }

        private void RowPaint(object sender, DrawListViewSubItemEventArgs e)
        {
            ListView listView = (ListView)sender;
            Color backgroundColor = Color.White;

           
            // Get Due Date (4th column)
            if (e.Item.SubItems.Count > 4)
            {
                DateTime dueDate;
                bool isDateParsed = DateTime.TryParseExact(
                    e.Item.SubItems[4].Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dueDate);

                if (isDateParsed)
                {
                    DateTime today = DateTime.Today;

                    if (dueDate < today)
                    {
                        backgroundColor = Color.FromArgb(255, 100, 100); // Mild red
                    }
                    else if (dueDate == today)
                    {
                        backgroundColor = Color.FromArgb(255, 200, 130); // Softer orange
                    }
                    else if (dueDate > today && dueDate <= today.AddDays(30)) //for due within a month
                    {
                        backgroundColor = Color.FromArgb(200, 220, 255); // Light blue 
                    }
                }
            }



            using (SolidBrush brush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Draw text over the painted background so text being Visible when hovering mouse through
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, e.SubItem.ForeColor, TextFormatFlags.Left);

            if (e.Item.Selected)
            {
                e.DrawFocusRectangle(e.Bounds);
            }
        }

        






    }
}


/*
 *  public void LoadTasks()
        {
            try
            {
                // ✅ Get UserGUID from session
                Guid userGUID = Accounts.UserSession.CurrentUserGUID;
                //MessageBox.Show($"Current UserGUID: {Accounts.UserSession.CurrentUserGUID}");



                if (userGUID == Guid.Empty)
                {
                    MessageBox.Show("User is not logged in or has an invalid GUID.");
                    return;
                }

                filterListView.Items.Clear();
               

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM TaskControl WHERE UserGUID = @userGUID"; //TaskGUID, Tag, Title, Note, [Start Date], [Due Date], Status
                    List<SqlParameter> parameters = new List<SqlParameter>
                    {
                    new SqlParameter("@UserGUID", SqlDbType.UniqueIdentifier) { Value = userGUID }
                    };


                    FilterCondition();


                    


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters.ToArray()); // Add all parameters

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tag = reader["Tag"] == DBNull.Value || string.IsNullOrEmpty(reader["Tag"].ToString()) ? "None" : reader["Tag"].ToString();
                                ListViewItem item = new ListViewItem(tag);
                                item.SubItems.Add(reader["Title"].ToString());
                                item.SubItems.Add(reader["Note"].ToString());
                                item.SubItems.Add(Convert.ToDateTime(reader["Start Date"]).ToString("dd-MM-yyyy"));
                                item.SubItems.Add(Convert.ToDateTime(reader["Due Date"]).ToString("dd-MM-yyyy"));

                                TaskStatus status;
                                if (Enum.TryParse(reader["Status"].ToString().Trim(), out status))
                                {
                                    item.Tag = new TaskInfo { TaskGUID = Guid.Parse(reader["TaskGUID"].ToString()), Status = status };
                                }
                                else
                                {
                                    string errorMessage = $"Error parsing TaskStatus: {reader["Status"].ToString()} for TaskGUID: {reader["TaskGUID"].ToString()}";
                                    Console.WriteLine(errorMessage);
                                    throw new InvalidOperationException(errorMessage);
                                }

                                filterListView.Items.Add(item);
                            }

                            filterListView.Refresh();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while loading tasks: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

                private void FilterCondition()
                {   
                    string query;

                    // Apply Status filter
                    if (currentFilter.StatusFilter.HasValue)
                    {
                        query += " AND Status = @status";
                        parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar) { Value = currentFilter.StatusFilter.ToString() });
                    }
                    // Apply Tag filter
                    if (!string.IsNullOrEmpty(currentFilter.TagFilter))
                    {
                        query += " AND Tag = @tag";
                        parameters.Add(new SqlParameter("@tag", SqlDbType.NVarChar) { Value = currentFilter.TagFilter });
                    }

                    //Tag Sorting
                    if (!string.IsNullOrEmpty(currentFilter.TagSortOrder))
                    {
                        query += $" ORDER BY Tag {currentFilter.TagSortOrder}";
                    }
                    
                    // Apply Due Date sorting
                    if (!string.IsNullOrEmpty(currentFilter.DueDateLengthSort))
                    {
                        query += $" ORDER BY [Due Date] {(currentFilter.DueDateLengthSort.ToLower() == "ascending" ? "ASC" : "DESC")}";
                    }
                    // Apply Title sort
                    if (!string.IsNullOrEmpty(currentFilter.TitleSortOrder))
                    {
                        query += $" ORDER BY Title {currentFilter.TitleSortOrder}";
                    }

                    // Apply Due Date comparison filters
                    if (!string.IsNullOrEmpty(currentFilter.DueDateComparison))
                    {
                        switch (currentFilter.DueDateComparison.ToLower())
                        {
                            case "today":
                                query += " AND CAST([Due Date] AS DATE) = CAST(GETDATE() AS DATE)";
                                break;
                            case "this week":
                                query += " AND [Due Date] >= DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 0) AND [Due Date] < DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 7)";
                                break;
                            case "this month":
                                query += " AND YEAR([Due Date]) = YEAR(GETDATE()) AND MONTH([Due Date]) = MONTH(GETDATE())";
                                break;
                            case "this year":
                                query += " AND YEAR([Due Date]) = YEAR(GETDATE())";
                                break;
                        }
                    }
                }

 */