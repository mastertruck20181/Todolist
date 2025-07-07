namespace List_To_Do__Tab_
{
    partial class taskManager
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(taskManager));
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.statusBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tagManager = new System.Windows.Forms.ComboBox();
            this.tagDelete = new System.Windows.Forms.Button();
            this.taskPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.taskPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(112, 118);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(286, 27);
            this.titleTextBox.TabIndex = 1;
            // 
            // noteTextBox
            // 
            this.noteTextBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteTextBox.Location = new System.Drawing.Point(112, 157);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(286, 27);
            this.noteTextBox.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 198);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(217, 22);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(112, 235);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(217, 22);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // statusBox
            // 
            this.statusBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statusBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBox.ForeColor = System.Drawing.Color.Black;
            this.statusBox.FormattingEnabled = true;
            this.statusBox.Location = new System.Drawing.Point(112, 78);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(171, 27);
            this.statusBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Gold;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(49, 19);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(145, 45);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click_1);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Gold;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(247, 97);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(145, 45);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click_1);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.Gold;
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(49, 97);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(145, 45);
            this.editButton.TabIndex = 7;
            this.editButton.Text = "Save";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.Gold;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(247, 19);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(145, 45);
            this.refreshButton.TabIndex = 8;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Status: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(25, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Note:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Start Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(25, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Due Date:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(393, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(271, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "What do you want to do ?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(25, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tag:";
            // 
            // tagManager
            // 
            this.tagManager.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tagManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tagManager.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagManager.FormattingEnabled = true;
            this.tagManager.Location = new System.Drawing.Point(112, 268);
            this.tagManager.Name = "tagManager";
            this.tagManager.Size = new System.Drawing.Size(196, 27);
            this.tagManager.TabIndex = 5;
            this.tagManager.SelectedIndexChanged += new System.EventHandler(this.tagManager_SelectedIndexChanged);
            // 
            // tagDelete
            // 
            this.tagDelete.BackColor = System.Drawing.Color.Gold;
            this.tagDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tagDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tagDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tagDelete.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagDelete.Location = new System.Drawing.Point(314, 268);
            this.tagDelete.Name = "tagDelete";
            this.tagDelete.Size = new System.Drawing.Size(84, 27);
            this.tagDelete.TabIndex = 18;
            this.tagDelete.Text = "Delete Tag";
            this.tagDelete.UseVisualStyleBackColor = false;
            this.tagDelete.Click += new System.EventHandler(this.tagDelete_Click);
            // 
            // taskPanel
            // 
            this.taskPanel.Controls.Add(this.refreshButton);
            this.taskPanel.Controls.Add(this.addButton);
            this.taskPanel.Controls.Add(this.deleteButton);
            this.taskPanel.Controls.Add(this.editButton);
            this.taskPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.taskPanel.Location = new System.Drawing.Point(0, 333);
            this.taskPanel.Name = "taskPanel";
            this.taskPanel.Size = new System.Drawing.Size(440, 159);
            this.taskPanel.TabIndex = 19;
            // 
            // taskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(440, 492);
            this.Controls.Add(this.taskPanel);
            this.Controls.Add(this.tagDelete);
            this.Controls.Add(this.tagManager);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "taskManager";
            this.Text = "taskManager";
            this.Load += new System.EventHandler(this.taskManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.taskPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox statusBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tagManager;
        private System.Windows.Forms.Button tagDelete;
        private System.Windows.Forms.Panel taskPanel;
    }
}