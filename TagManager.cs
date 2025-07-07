using Azure;
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

namespace List_To_Do__Tab_
{
    public partial class TagManager : Form
    {
        public TagManager()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Persist Security Info=True;User ID=Admin;Password=adamlambert123;Encrypt=True;TrustServerCertificate=True";

        public string NewTag { get; private set; }
        private void addButton_Click(object sender, EventArgs e)
        {
            AddTag();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelAdd();
        }



        private void AddTag()
        {
            try
            {
                Guid userGUID = Accounts.UserSession.CurrentUserGUID;

                if (userGUID == Guid.Empty)
                {
                    MessageBox.Show("User is not logged in.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(tagBox.Text))
                {
                    MessageBox.Show("Tag name cannot be empty.");
                    return;
                }

                string newTag = tagBox.Text.Trim();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check for duplicate tag
                    string checkQuery = "SELECT COUNT(*) FROM TagName WHERE UserGUID = @UserGUID AND Tag = @Tag";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = userGUID;
                        checkCommand.Parameters.Add("@Tag", SqlDbType.NVarChar).Value = newTag;

                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Tag already exists for this user.");
                            return;
                        }
                    }

                    // Insert the new tag
                    string insertQuery = "INSERT INTO TagName (UserGUID, Tag) VALUES (@UserGUID, @Tag)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = userGUID;
                        insertCommand.Parameters.Add("@Tag", SqlDbType.NVarChar).Value = newTag;

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Tag = newTag;
                            DialogResult = DialogResult.OK;
                            MessageBox.Show("Tag added!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add tag.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CancelAdd()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
