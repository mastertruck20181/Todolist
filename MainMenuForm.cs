using List_To_Do__Tab_.TaskControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace List_To_Do__Tab_
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            this.Height = 850;
            this.Width = 1040;

            sidebarMenu.Width = 50;
            this.Shown += (sender, e) => PopUpDueTasks(); // Call PopUpDueTasks() when form is shown
        }
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            Guid userGUID = Accounts.UserSession.CurrentUserGUID;
            if (userGUID == Guid.Empty)
            {
                MessageBox.Show("User is not logged in. Please log in first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            
            //PopUpDueTasks();

            //this.LocationChanged += (s, args) =>
            //{
            //    if (managerform != null && managerform.Visible)
            //    {
            //        PositionPopup();
            //    }
            //};
            setListView(todoListView, upcomingListView, completedListView);
            LoadTasks();

            defaultControls = panelContainer.Controls.Cast<Control>().ToArray();
            this.DoubleBuffered = true;

        }
        private bool isSidebarExpanded = false;
        private bool isDragging = false;
        private Point mouseOffset;
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

       

        //****************************************************************************************************************************************
        // Code for Menu sidebar

        private bool isSidebarExpanding = false; // Add this flag

        private void menuButton_Click(object sender, EventArgs e)
        {
            

            if (!isSidebarExpanded)
            {
                // Expand sidebar
                isSidebarExpanding = true;
                sidebarTimer.Interval = 20; // Adjust for animation speed
                sidebarTimer.Start();
            }
            else
            {
                // Collapse sidebar
                isSidebarExpanding = false;
                sidebarTimer.Interval = 20; // Adjust for animation speed
                sidebarTimer.Start();
            }

            isSidebarExpanded = !isSidebarExpanded;



        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            
            int animationStep = 20; // Adjust for animation speed

            if (isSidebarExpanding)
            {
                if (sidebarMenu.Width < 320)
                {
                    sidebarMenu.Width += animationStep;
                    //sidebarMenu.BringToFront();

                    if (sidebarMenu.Width > 320) sidebarMenu.Width = 320; // Ensure it doesn't overshoot
                }
                else
                {
                    sidebarTimer.Stop();
                }
            }
            else
            {
                if (sidebarMenu.Width > 50)
                {
                    sidebarMenu.Width -= animationStep;
                    if (sidebarMenu.Width < 50) sidebarMenu.Width = 50; // Ensure it doesn't undershoot
                }
                else
                {
                    sidebarTimer.Stop();
                }
            }

            // Update panelContainer position and size
            panelContainer.Location = new Point(sidebarMenu.Width, 0);
            panelContainer.Width = this.ClientSize.Width - sidebarMenu.Width;
            panelContainer.ResumeLayout(true);
        }

        







        //****************************************************************************************************************************************
        // Menu bar Button //938, 211
        private Control[] defaultControls;

        private void addMenuControl(UserControl panelControl)
        {
            panelControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(panelControl);
            panelControl.Show();
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.AddRange(defaultControls); // Restore default controls
        }
        private void filterButton_Click(object sender, EventArgs e)
        {
            FilterControl filterControl = new FilterControl();
            addMenuControl(filterControl);
        }




        //****************************************************************************************************************************************
        // code for Head Panel to move


        private void headerPanel_MouseDown(object sender, MouseEventArgs e) 
        {
            isDragging = true;
            mouseOffset = new Point(e.X, e.Y);
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e) 
        {
            if (isDragging)
            {
                int x = e.X + this.Location.X - mouseOffset.X;
                int y = e.Y + this.Location.Y - mouseOffset.Y;
                this.Location = new Point(x, y);
            }
        }

        private void headerPanel_MouseUp(object sender, MouseEventArgs e) 
        {
            isDragging = false;
        }


        //****************************************************************************************************************************************

        private taskManager managerform = null;
        private void taskButton_Click(object sender, EventArgs e)
        {
            if (managerform == null || managerform.IsDisposed)
            {
                // Open Task Manager
                managerform = new taskManager();
                managerform.SetMainMenuForm(this);
                managerform.Show();
                int x = this.Location.X + this.Width;
                int y = this.Location.Y;

                managerform.Location = new Point(x, y);
                //PositionPopup();

                managerform.FormClosed += (s, args) => managerform = null;

                this.LocationChanged += (s, args) =>
                {
                    if (managerform != null && managerform.Visible)
                    {
                        PositionPopup();
                    }
                };
            }
            else
            {
                // Close Task Manager if it's already open
                managerform.Close();
                managerform = null;
            }


        }

        private void PositionPopup()
        {
            if (managerform != null && !managerform.IsDisposed)
            {
                managerform.Location = this.PointToScreen(new Point(this.Width, 0));
            }

            if (reminderForm != null && !reminderForm.IsDisposed)
            {
                
                //int centerX = (Screen.PrimaryScreen.Bounds.Width ) /2; // Center horizontally
                //int centerY = (Screen.PrimaryScreen.Bounds.Height ) /2 ; // Center vertically

                reminderForm.Location = this.PointToScreen(new Point(this.Width-1500/2, 150));

                //reminderForm.Location = this.PointToScreen(new Point(centerX, centerY));
            }
        }



        public taskReminder reminderForm = null;
        public void reminderButton_Click(object sender, EventArgs e)
        {
            
            if (reminderForm == null || reminderForm.IsDisposed)
            {
                // Open the form
                reminderForm = new taskReminder(this);
                reminderForm.LoadReminders(); // Load reminders before showing

                reminderForm.StartPosition = FormStartPosition.Manual; // Ensure manual positioning
                reminderForm.Show();
                PositionPopup();


                reminderForm.TopMost = true;
                reminderForm.BringToFront();

                reminderForm.FormClosed += (s, args) => reminderForm = null;

                this.LocationChanged += (s, args) =>
                {
                    if (reminderForm != null && reminderForm.Visible)
                    {
                        PositionPopup();
                    }
                };
            }
            else
            {
                // Close the form if it's already open
                reminderForm.Close();
                reminderForm = null;
            }
        }


        private bool isReminderHighlighted = false;

        // Start blinking when there are tasks
        public void StartReminderBlink()
        {
            if (!reminderBlink.Enabled)
            {
                reminderBlink.Start();// change background color
                reminderButton.BackColor = Color.OrangeRed; // Start with red

            }
        }

        // Stop blinking when tasks are cleared
        public void StopReminderBlink()
        {
            reminderBlink.Stop();
            reminderButton.BackColor = Color.SaddleBrown; 
        }

        private void reminderBlink_Tick(object sender, EventArgs e)
        {
            // Toggle background color between red and default
            reminderButton.BackColor = isReminderHighlighted ? Color.SaddleBrown : Color.OrangeRed;
            isReminderHighlighted = !isReminderHighlighted;
        }

        public void PopUpDueTasks() //List<taskReminder.TaskReminder> dueTasks
        {

            reminderForm = new taskReminder(this); // Initialize the class variable
            reminderForm.LoadReminders();
            reminderForm.StartPosition = FormStartPosition.Manual; // Ensure manual positioning


            if (reminderForm.GetTaskCount() > 0)
            {
                PositionPopup();
                reminderForm.Show();
                reminderForm.FormClosed += (s, args) => reminderForm = null;

            }
            else
            {
                reminderForm.Dispose();
                reminderForm = null; // Set to null to prevent errors if LocationChanged fires
            }
        }




        //****************************************************************************************************************************************
        //Manage List View

        public void setListView(ListView todoListView, ListView upcomingListView, ListView completedListView)
        {
         
            this.todoListView = todoListView;
            this.upcomingListView = upcomingListView;
            this.completedListView = completedListView;

            


            // Configure To-Do ListView
            todoListView.View = View.Details;
            todoListView.Columns.Add("Tag", 100, HorizontalAlignment.Center);
            todoListView.Columns.Add("Title", 250, HorizontalAlignment.Center);
            todoListView.Columns.Add("Note", 350, HorizontalAlignment.Center);
            todoListView.Columns.Add("Start Date", 100, HorizontalAlignment.Center);
            todoListView.Columns.Add("Due Date", 100, HorizontalAlignment.Center);
            //todoListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // Configure Upcoming ListView
            upcomingListView.View = View.Details;
            upcomingListView.Columns.Add("Tag", 100, HorizontalAlignment.Center);
            upcomingListView.Columns.Add("Title", 250, HorizontalAlignment.Center);
            upcomingListView.Columns.Add("Note", 350, HorizontalAlignment.Center);
            upcomingListView.Columns.Add("Start Date", 100, HorizontalAlignment.Center);
            upcomingListView.Columns.Add("Due Date", 100, HorizontalAlignment.Center);
            //upcomingListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // Configure Completed ListView
            completedListView.View = View.Details;
            completedListView.Columns.Add("Tag", 100, HorizontalAlignment.Center);
            completedListView.Columns.Add("Title", 250, HorizontalAlignment.Center);
            completedListView.Columns.Add("Note", 350, HorizontalAlignment.Center);
            completedListView.Columns.Add("Start Date", 100, HorizontalAlignment.Center);
            completedListView.Columns.Add("Due Date", 100, HorizontalAlignment.Center);
            //completedListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            todoListView.OwnerDraw = true;
            todoListView.DrawSubItem += RowPaint;
            todoListView.DrawColumnHeader += ColumnHeaderPaint;

            upcomingListView.OwnerDraw = true;
            upcomingListView.DrawSubItem += RowPaint;
            upcomingListView.DrawColumnHeader += ColumnHeaderPaint;


            completedListView.OwnerDraw = true;
            completedListView.DrawSubItem += RowPaint;
            completedListView.DrawColumnHeader += ColumnHeaderPaint;

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

            if (listView == completedListView)
            {
                // If the row is in the completed list, set background to white and return
                using (SolidBrush brush = new SolidBrush(backgroundColor))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }

                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, e.SubItem.ForeColor, TextFormatFlags.Left);

                if (e.Item.Selected)
                {
                    e.DrawFocusRectangle(e.Bounds);
                }
                return;
            }

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






        private void todoListView_Click(object sender, EventArgs e) => HandleListViewClick(todoListView);
        private void upcomingListView_Click(object sender, EventArgs e) => HandleListViewClick(upcomingListView);
        private void completedListView_Click(object sender, EventArgs e) => HandleListViewClick(completedListView);
        
        private void HandleListViewClick(ListView listView)
        {
            if (listView.SelectedItems.Count == 0) return;

            ListViewItem selectedItem = listView.SelectedItems[0];

            Guid taskGUID = (Guid)selectedItem.Tag;
            string tag = string.IsNullOrEmpty(selectedItem.SubItems[0].Text) ? "None" : selectedItem.SubItems[0].Text;
            string title = selectedItem.SubItems[1].Text;
            string note = selectedItem.SubItems[2].Text;
            DateTime startDate = DateTime.ParseExact(selectedItem.SubItems[3].Text, "dd-MM-yyyy", null);
            DateTime dueDate = DateTime.ParseExact(selectedItem.SubItems[4].Text, "dd-MM-yyyy", null);


            // 🔹 Get status from the actual ListView row
            string SelectedTaskStatus = "Doing"; 
            if (listView == upcomingListView)
                SelectedTaskStatus = "Upcoming";
            else if (listView == completedListView)
                SelectedTaskStatus = "Completed";


            if (managerform == null || managerform.IsDisposed)
            {
                managerform = new taskManager();
                managerform.SetMainMenuForm(this);
                managerform.Show();
            }
            else
            {
                PositionPopup();
                managerform.Show();
            }

            managerform.LoadTaskDetails(taskGUID, title, note, startDate, dueDate, SelectedTaskStatus, tag);
        }

        //****************************************************************************************************************************************
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

                todoListView.Items.Clear();
                upcomingListView.Items.Clear();
                completedListView.Items.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT TaskGUID, Tag, Title, Note, [Start Date], [Due Date], Status FROM TaskControl WHERE UserGUID = @userGUID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = userGUID;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int taskRemain = 0;
                            int taskDone = 0;
                            while (reader.Read())
                            {
                                string tag = reader["Tag"] == DBNull.Value || string.IsNullOrEmpty(reader["Tag"].ToString()) ? "None" : reader["Tag"].ToString(); // Handle null/empty tag
                                ListViewItem item = new ListViewItem(tag);
                                item.SubItems.Add(reader["Title"].ToString());
                                item.SubItems.Add(reader["Note"].ToString());
                                item.SubItems.Add(Convert.ToDateTime(reader["Start Date"]).ToString("dd-MM-yyyy"));
                                item.SubItems.Add(Convert.ToDateTime(reader["Due Date"]).ToString("dd-MM-yyyy"));

                                item.Tag = Guid.Parse(reader["TaskGUID"].ToString());

                                TaskStatus status = (TaskStatus)Enum.Parse(typeof(TaskStatus), reader["Status"].ToString());

                                switch (status)
                                {
                                    case TaskStatus.Doing:
                                        todoListView.Items.Add(item);
                                        taskRemain++;
                                        break;
                                    case TaskStatus.Upcoming:
                                        upcomingListView.Items.Add(item);
                                        taskRemain++;
                                        break;
                                    case TaskStatus.Completed:
                                        completedListView.Items.Add(item);
                                        taskDone++;
                                        break;
                                }
                            }

                            // Refresh list views
                            todoListView.Refresh();
                            upcomingListView.Refresh();
                            completedListView.Refresh();

                            MessageBox.Show($"-Tasks remaining: {taskRemain}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while loading tasks: " + ex.Message);
            }
        }
        //****************************************************************************************************************************************
       

        //****************************************************************************************************************************************
        private void CloseBox_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}