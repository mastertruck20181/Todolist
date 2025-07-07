namespace List_To_Do__Tab_.TaskControl
{
    partial class FilterControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterControl));
            this.filterListView = new System.Windows.Forms.ListView();
            this.filterMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alphabetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeAddedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thisWeekToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thisMonthToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thisYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upcomingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.filterMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterListView
            // 
            this.filterListView.GridLines = true;
            this.filterListView.HideSelection = false;
            this.filterListView.Location = new System.Drawing.Point(43, 19);
            this.filterListView.Name = "filterListView";
            this.filterListView.Size = new System.Drawing.Size(905, 608);
            this.filterListView.TabIndex = 3;
            this.filterListView.UseCompatibleStateImageBehavior = false;
            this.filterListView.SelectedIndexChanged += new System.EventHandler(this.filterListView_SelectedIndexChanged_1);
            // 
            // filterMenu
            // 
            this.filterMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.filterMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alphabetToolStripMenuItem,
            this.tagToolStripMenuItem,
            this.timeToolStripMenuItem,
            this.statusToolStripMenuItem});
            this.filterMenu.Name = "filterMenu";
            this.filterMenu.Size = new System.Drawing.Size(140, 100);
            this.filterMenu.Opening += new System.ComponentModel.CancelEventHandler(this.filterMenu_Opening);
            // 
            // alphabetToolStripMenuItem
            // 
            this.alphabetToolStripMenuItem.Name = "alphabetToolStripMenuItem";
            this.alphabetToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.alphabetToolStripMenuItem.Text = "Alphabet";
            this.alphabetToolStripMenuItem.Click += new System.EventHandler(this.alphabetToolStripMenuItem_Click);
            // 
            // tagToolStripMenuItem
            // 
            this.tagToolStripMenuItem.Name = "tagToolStripMenuItem";
            this.tagToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.tagToolStripMenuItem.Text = "Tag";
            this.tagToolStripMenuItem.Click += new System.EventHandler(this.tagToolStripMenuItem_Click);
            // 
            // timeToolStripMenuItem
            // 
            this.timeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeAddedToolStripMenuItem});
            this.timeToolStripMenuItem.Name = "timeToolStripMenuItem";
            this.timeToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.timeToolStripMenuItem.Text = "Time";
            // 
            // timeAddedToolStripMenuItem
            // 
            this.timeAddedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayToolStripMenuItem1,
            this.thisWeekToolStripMenuItem1,
            this.thisMonthToolStripMenuItem1,
            this.thisYearToolStripMenuItem,
            this.ascendingToolStripMenuItem1,
            this.descendingToolStripMenuItem1});
            this.timeAddedToolStripMenuItem.Name = "timeAddedToolStripMenuItem";
            this.timeAddedToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.timeAddedToolStripMenuItem.Text = "Due date";
            // 
            // todayToolStripMenuItem1
            // 
            this.todayToolStripMenuItem1.Name = "todayToolStripMenuItem1";
            this.todayToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.todayToolStripMenuItem1.Text = "Today";
            this.todayToolStripMenuItem1.Click += new System.EventHandler(this.todayToolStripMenuItem1_Click);
            // 
            // thisWeekToolStripMenuItem1
            // 
            this.thisWeekToolStripMenuItem1.Name = "thisWeekToolStripMenuItem1";
            this.thisWeekToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.thisWeekToolStripMenuItem1.Text = "This week";
            this.thisWeekToolStripMenuItem1.Click += new System.EventHandler(this.thisWeekToolStripMenuItem1_Click);
            // 
            // thisMonthToolStripMenuItem1
            // 
            this.thisMonthToolStripMenuItem1.Name = "thisMonthToolStripMenuItem1";
            this.thisMonthToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.thisMonthToolStripMenuItem1.Text = "This month";
            this.thisMonthToolStripMenuItem1.Click += new System.EventHandler(this.thisMonthToolStripMenuItem1_Click);
            // 
            // thisYearToolStripMenuItem
            // 
            this.thisYearToolStripMenuItem.Name = "thisYearToolStripMenuItem";
            this.thisYearToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.thisYearToolStripMenuItem.Text = "This year";
            this.thisYearToolStripMenuItem.Click += new System.EventHandler(this.thisYearToolStripMenuItem_Click);
            // 
            // ascendingToolStripMenuItem1
            // 
            this.ascendingToolStripMenuItem1.Name = "ascendingToolStripMenuItem1";
            this.ascendingToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.ascendingToolStripMenuItem1.Text = "Ascending";
            this.ascendingToolStripMenuItem1.Click += new System.EventHandler(this.ascendingToolStripMenuItem1_Click);
            // 
            // descendingToolStripMenuItem1
            // 
            this.descendingToolStripMenuItem1.Name = "descendingToolStripMenuItem1";
            this.descendingToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.descendingToolStripMenuItem1.Text = "Descending";
            this.descendingToolStripMenuItem1.Click += new System.EventHandler(this.descendingToolStripMenuItem1_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doingToolStripMenuItem,
            this.upcomingToolStripMenuItem,
            this.completedToolStripMenuItem});
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.statusToolStripMenuItem.Text = "Status";
            // 
            // doingToolStripMenuItem
            // 
            this.doingToolStripMenuItem.Name = "doingToolStripMenuItem";
            this.doingToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.doingToolStripMenuItem.Text = "Doing";
            this.doingToolStripMenuItem.Click += new System.EventHandler(this.doingToolStripMenuItem_Click);
            // 
            // upcomingToolStripMenuItem
            // 
            this.upcomingToolStripMenuItem.Name = "upcomingToolStripMenuItem";
            this.upcomingToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.upcomingToolStripMenuItem.Text = "Upcoming";
            this.upcomingToolStripMenuItem.Click += new System.EventHandler(this.upcomingToolStripMenuItem_Click);
            // 
            // completedToolStripMenuItem
            // 
            this.completedToolStripMenuItem.Name = "completedToolStripMenuItem";
            this.completedToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.completedToolStripMenuItem.Text = "Completed";
            this.completedToolStripMenuItem.Click += new System.EventHandler(this.completedToolStripMenuItem_Click);
            // 
            // filterButton
            // 
            this.filterButton.BackColor = System.Drawing.Color.OldLace;
            this.filterButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.filterButton.Image = ((System.Drawing.Image)(resources.GetObject("filterButton.Image")));
            this.filterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterButton.Location = new System.Drawing.Point(63, 46);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(107, 56);
            this.filterButton.TabIndex = 5;
            this.filterButton.Text = "Filters";
            this.filterButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filterButton.UseVisualStyleBackColor = false;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.filterButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 108);
            this.panel1.TabIndex = 6;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.Gold;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(176, 63);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(103, 39);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "Clear Filter";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.filterListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(990, 644);
            this.panel2.TabIndex = 7;
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(990, 752);
            this.Load += new System.EventHandler(this.FilterControl_Load);
            this.filterMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView filterListView;
        private System.Windows.Forms.ContextMenuStrip filterMenu;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.ToolStripMenuItem alphabetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeAddedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todayToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thisWeekToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thisMonthToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem doingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upcomingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completedToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ToolStripMenuItem thisYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ascendingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem descendingToolStripMenuItem1;
        private System.Windows.Forms.Panel panel2;
    }
}
