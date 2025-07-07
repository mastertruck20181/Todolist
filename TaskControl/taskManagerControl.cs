using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace List_To_Do__Tab_.TaskControl
{
    public partial class taskManagerControl : UserControl
    {
        public taskManagerControl()
        {
            InitializeComponent();
            //parentForm.TitleText = this.TitleTextBox.Text;
            //parentForm.NoteText = this.NoteTextBox.Text;
            //parentForm.StartDateValue = this.StartDatePicker.Value;
            //parentForm.DueDateValue = this.DueDatePicker.Value;
            //parentForm.TagManagerSelectedItem = this.TagComboBox.SelectedItem?.ToString();
            //parentForm.StatusBoxSelectedItem = this.StatusComboBox.SelectedItem?.ToString();

        }
        private taskManager parentForm;

        //public void SetParentForm(taskManager form)
        //{
        //    parentForm = form;
        //}


        public TextBox TitleTextBox { get; private set; }
        public TextBox NoteTextBox { get; private set; }
        public DateTimePicker StartDatePicker { get; private set; }
        public DateTimePicker DueDatePicker { get; private set; }
        public ComboBox TagComboBox { get; private set; }
        public ComboBox StatusComboBox { get; private set; }

        private void addButton_Click(object sender, EventArgs e)
        {
            //if (parentForm == null)
            //{
            //    MessageBox.Show("Parent form is not set!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //// Transfer values from UserControl to parent form
            //parentForm.TitleText = this.TitleTextBox.Text;
            //parentForm.NoteText = this.NoteTextBox.Text;
            //parentForm.StartDateValue = this.StartDatePicker.Value;
            //parentForm.DueDateValue = this.DueDatePicker.Value;
            //parentForm.TagManagerSelectedItem = this.TagComboBox.SelectedItem?.ToString();
            //parentForm.StatusBoxSelectedItem = this.StatusComboBox.SelectedItem?.ToString();

            //parentForm.AddTask();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            //parentForm?.RefreshTask();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //parentForm?.EditTask();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //parentForm?.DeleteTask();
        }
    }
}
