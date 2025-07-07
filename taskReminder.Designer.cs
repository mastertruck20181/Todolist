namespace List_To_Do__Tab_
{
    partial class taskReminder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(taskReminder));
            this.reminderTag = new System.Windows.Forms.ComboBox();
            this.reminderStatus = new System.Windows.Forms.ComboBox();
            this.closeBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reminderDueDate = new System.Windows.Forms.DateTimePicker();
            this.reminderTitle = new System.Windows.Forms.TextBox();
            this.leftBox = new System.Windows.Forms.PictureBox();
            this.rightBox = new System.Windows.Forms.PictureBox();
            this.taskCount = new System.Windows.Forms.Label();
            this.reminderBlink = new System.Windows.Forms.Timer(this.components);
            this.taskTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.closeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBox)).BeginInit();
            this.SuspendLayout();
            // 
            // reminderTag
            // 
            this.reminderTag.FormattingEnabled = true;
            this.reminderTag.Location = new System.Drawing.Point(95, 229);
            this.reminderTag.Name = "reminderTag";
            this.reminderTag.Size = new System.Drawing.Size(236, 27);
            this.reminderTag.TabIndex = 41;
            // 
            // reminderStatus
            // 
            this.reminderStatus.FormattingEnabled = true;
            this.reminderStatus.Location = new System.Drawing.Point(95, 117);
            this.reminderStatus.Name = "reminderStatus";
            this.reminderStatus.Size = new System.Drawing.Size(236, 27);
            this.reminderStatus.TabIndex = 34;
            // 
            // closeBox
            // 
            this.closeBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBox.Image = ((System.Drawing.Image)(resources.GetObject("closeBox.Image")));
            this.closeBox.Location = new System.Drawing.Point(392, 3);
            this.closeBox.Name = "closeBox";
            this.closeBox.Size = new System.Drawing.Size(45, 45);
            this.closeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeBox.TabIndex = 48;
            this.closeBox.TabStop = false;
            this.closeBox.Click += new System.EventHandler(this.closeBox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(15, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 47;
            this.label7.Text = "Tag:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(15, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 46;
            this.label5.Text = "Due Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(15, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "Title:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(15, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 42;
            this.label1.Text = "Status: ";
            // 
            // reminderDueDate
            // 
            this.reminderDueDate.CalendarFont = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reminderDueDate.Location = new System.Drawing.Point(95, 192);
            this.reminderDueDate.Name = "reminderDueDate";
            this.reminderDueDate.Size = new System.Drawing.Size(236, 27);
            this.reminderDueDate.TabIndex = 40;
            // 
            // reminderTitle
            // 
            this.reminderTitle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reminderTitle.Location = new System.Drawing.Point(95, 154);
            this.reminderTitle.Name = "reminderTitle";
            this.reminderTitle.Size = new System.Drawing.Size(329, 27);
            this.reminderTitle.TabIndex = 36;
            // 
            // leftBox
            // 
            this.leftBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.leftBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftBox.Image = ((System.Drawing.Image)(resources.GetObject("leftBox.Image")));
            this.leftBox.Location = new System.Drawing.Point(53, 306);
            this.leftBox.Name = "leftBox";
            this.leftBox.Size = new System.Drawing.Size(50, 50);
            this.leftBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.leftBox.TabIndex = 37;
            this.leftBox.TabStop = false;
            this.leftBox.Click += new System.EventHandler(this.leftBox_Click);
            // 
            // rightBox
            // 
            this.rightBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rightBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rightBox.Image = ((System.Drawing.Image)(resources.GetObject("rightBox.Image")));
            this.rightBox.Location = new System.Drawing.Point(338, 306);
            this.rightBox.Name = "rightBox";
            this.rightBox.Size = new System.Drawing.Size(50, 50);
            this.rightBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rightBox.TabIndex = 35;
            this.rightBox.TabStop = false;
            this.rightBox.Click += new System.EventHandler(this.rightBox_Click);
            // 
            // taskCount
            // 
            this.taskCount.AutoSize = true;
            this.taskCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskCount.ForeColor = System.Drawing.Color.Red;
            this.taskCount.Location = new System.Drawing.Point(193, 276);
            this.taskCount.Name = "taskCount";
            this.taskCount.Size = new System.Drawing.Size(56, 22);
            this.taskCount.TabIndex = 50;
            this.taskCount.Text = "1 of 1";
            // 
            // reminderBlink
            // 
            this.reminderBlink.Enabled = true;
            // 
            // taskTotal
            // 
            this.taskTotal.AutoSize = true;
            this.taskTotal.BackColor = System.Drawing.Color.Transparent;
            this.taskTotal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.taskTotal.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskTotal.ForeColor = System.Drawing.Color.Gold;
            this.taskTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskTotal.Location = new System.Drawing.Point(14, 72);
            this.taskTotal.Name = "taskTotal";
            this.taskTotal.Size = new System.Drawing.Size(334, 20);
            this.taskTotal.TabIndex = 51;
            this.taskTotal.Text = "Hey there! You’ve got X tasks coming up !";
            this.taskTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taskReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(440, 395);
            this.Controls.Add(this.taskTotal);
            this.Controls.Add(this.taskCount);
            this.Controls.Add(this.reminderTag);
            this.Controls.Add(this.reminderStatus);
            this.Controls.Add(this.closeBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reminderDueDate);
            this.Controls.Add(this.reminderTitle);
            this.Controls.Add(this.leftBox);
            this.Controls.Add(this.rightBox);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "taskReminder";
            this.Text = "taskReminder";
            this.Load += new System.EventHandler(this.taskReminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.closeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox reminderTag;
        private System.Windows.Forms.ComboBox reminderStatus;
        private System.Windows.Forms.PictureBox closeBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker reminderDueDate;
        private System.Windows.Forms.TextBox reminderTitle;
        private System.Windows.Forms.PictureBox leftBox;
        private System.Windows.Forms.PictureBox rightBox;
        private System.Windows.Forms.Label taskCount;
        private System.Windows.Forms.Timer reminderBlink;
        private System.Windows.Forms.Label taskTotal;
    }
}