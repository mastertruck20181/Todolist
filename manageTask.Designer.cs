namespace List_To_Do__Tab_
{
    partial class manageTask
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manageTask));
            this.statusBox = new System.Windows.Forms.ComboBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.to_do_listDataSet = new List_To_Do__Tab_.To_do_listDataSet();
            this.todolistDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.todolistDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.to_do_listStatus = new List_To_Do__Tab_.To_do_listStatus();
            this.taskControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskControlTableAdapter = new List_To_Do__Tab_.To_do_listStatusTableAdapters.TaskControlTableAdapter();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_do_listDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todolistDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todolistDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_do_listStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskControlBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBox
            // 
            this.statusBox.BackColor = System.Drawing.Color.Gold;
            this.statusBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statusBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBox.FormattingEnabled = true;
            this.statusBox.Location = new System.Drawing.Point(64, 85);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(158, 27);
            this.statusBox.TabIndex = 0;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(64, 134);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(494, 27);
            this.titleTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(7, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(7, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Note:";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Gold;
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.Location = new System.Drawing.Point(13, 341);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(112, 51);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // noteTextBox
            // 
            this.noteTextBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteTextBox.Location = new System.Drawing.Point(64, 185);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(494, 27);
            this.noteTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(4, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(518, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(227, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Start date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(227, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Due date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Location = new System.Drawing.Point(325, 248);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 22);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker2.Location = new System.Drawing.Point(325, 291);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(233, 22);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(138, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(322, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "What do you want to do ?";
            // 
            // to_do_listDataSet
            // 
            this.to_do_listDataSet.DataSetName = "To_do_listDataSet";
            this.to_do_listDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // todolistDataSetBindingSource
            // 
            this.todolistDataSetBindingSource.DataSource = this.to_do_listDataSet;
            this.todolistDataSetBindingSource.Position = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Gold;
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(143, 341);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(125, 51);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Delete";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Gold;
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(285, 341);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(129, 51);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // todolistDataSetBindingSource1
            // 
            this.todolistDataSetBindingSource1.DataSource = this.to_do_listDataSet;
            this.todolistDataSetBindingSource1.Position = 0;
            // 
            // to_do_listStatus
            // 
            this.to_do_listStatus.DataSetName = "To_do_listStatus";
            this.to_do_listStatus.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taskControlBindingSource
            // 
            this.taskControlBindingSource.DataMember = "TaskControl";
            this.taskControlBindingSource.DataSource = this.to_do_listStatus;
            // 
            // taskControlTableAdapter
            // 
            this.taskControlTableAdapter.ClearBeforeFill = true;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.Gold;
            this.refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.Location = new System.Drawing.Point(431, 341);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(129, 51);
            this.refreshButton.TabIndex = 15;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // manageTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(575, 404);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.statusBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "manageTask";
            this.Text = "addTask";
            this.Load += new System.EventHandler(this.manageTask_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_do_listDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todolistDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todolistDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_do_listStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskControlBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox statusBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource todolistDataSetBindingSource;
        private To_do_listDataSet to_do_listDataSet;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.BindingSource todolistDataSetBindingSource1;
        private To_do_listStatus to_do_listStatus;
        private System.Windows.Forms.BindingSource taskControlBindingSource;
        private To_do_listStatusTableAdapters.TaskControlTableAdapter taskControlTableAdapter;
        private System.Windows.Forms.Button refreshButton;
    }
}