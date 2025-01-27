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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace List_To_Do__Tab_
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            
            this.Width = 800;
            this.Height = 1050;


            //TaskModifier taskModifier = new TaskModifier();
            
            sidebarMenu.Width = 60;

        }
        private bool isSidebarExpanded = false;
        private bool isDragging = false;
        private Point mouseOffset;
        private string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Persist Security Info=True;User ID=Admin;Password=adamlambert123;Encrypt=True;TrustServerCertificate=True";



        //****************************************************************************************************************************************

        private void menuButton_Click(object sender, EventArgs e)
        {
            if (!isSidebarExpanded)
            {
                // Expand sidebar to maximum width
                sidebarMenu.Width = 320;
            }
            else
            {
                // Collapse sidebar to minimum width
                sidebarMenu.Width = 60;
            }

            isSidebarExpanded = !isSidebarExpanded; // Toggle the state
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            sidebarTimer.Enabled = false;
            sidebarMenu.Width = 60; // Adjust as needed
            isSidebarExpanded = false;
        }



        
        
        //****************************************************************************************************************************************



        private void headerPanel_MouseDown(object sender, MouseEventArgs e) // Replace 'panel1' with your actual panel name
        {
            isDragging = true;
            mouseOffset = new Point(e.X, e.Y);
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e) // Replace 'panel1' with your actual panel name
        {
            if (isDragging)
            {
                int x = e.X + this.Location.X - mouseOffset.X;
                int y = e.Y + this.Location.Y - mouseOffset.Y;
                this.Location = new Point(x, y);
            }
        }

        private void headerPanel_MouseUp(object sender, MouseEventArgs e) // Replace 'panel1' with your actual panel name
        {
            isDragging = false;
        }

        
        //****************************************************************************************************************************************


        private void addTaskButton_Click(object sender, EventArgs e)
        {
            addTask addTask = new addTask();
            addTask.Show();

        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            TaskModifier taskModifier = new TaskModifier();
            Guid userGUID = Accounts.UserSession.CurrentUserGUID;
            // Set up the ListViews
            taskModifier.setListView(todoListView, upcomingListView, completedListView);
            // Load tasks from database first
            taskModifier.LoadTasks(userGUID); // Pass 'this' to access ListViews from TaskModifier

            
        }

        private void CloseBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}