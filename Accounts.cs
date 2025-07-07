using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using BCrypt.Net;

namespace List_To_Do__Tab_
{
    internal class Accounts
    {
        private static string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Persist Security Info=True;User ID=Admin;Password=adamlambert123;Encrypt=True;TrustServerCertificate=True";
       
        public Accounts()
        {
           
        }

        public static class UserSession
        {
            public static Guid CurrentUserGUID { get; set; }

        }

        public static bool Login(string username, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    // Query to get UserGUID and Hashed Password
                    string query = "SELECT UserGUID, Password FROM Accounts WHERE Username = @Username";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHashedPassword = reader["Password"].ToString();
                                Guid userGUID = (Guid)reader["UserGUID"];

                                // Verify password with hashed value
                                if (BCrypt.Net.BCrypt.Verify(password, storedHashedPassword))
                                {
                                    // ✅ Set the logged-in UserGUID in the session
                                    UserSession.CurrentUserGUID = userGUID;
                                    return true;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during login: {ex.Message}");
                }
            }

            return false; // Login failed
        }

        public void addAccount(string username, string password, string firstName, string lastName, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Generate a unique ID (assuming an auto-incrementing primary key for Id column)
                Guid UserGUID = Guid.NewGuid();
                string hashedPassword = HashPassword(password);

                string insertQuery = $"INSERT INTO Accounts (UserGUID, Username, Password, [First Name], [Last Name], Email) VALUES (@UserGUID, @Username, @Password, @Firstname, @Lastname, @Email)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserGUID", UserGUID);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Firstname", firstName);
                    command.Parameters.AddWithValue("@Lastname", lastName);
                    command.Parameters.AddWithValue("@Email", email);


                    command.ExecuteNonQuery();
                }



            }
        }

        private string HashPassword(string password)
        {
            // Use a secure password hashing library like BCrypt.Net
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        //**************************************************************************************************************************************************

        //User GUID

        public static Guid GetUserGUID(string username, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    // Define the query
                    string query = "SELECT UserGUID FROM Accounts WHERE Username = @Username AND Password = @Password";

                    // Create the command
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        // **Clear any existing parameters to avoid duplication**
                        sqlCommand.Parameters.Clear();

                        // Add parameters to the query
                        sqlCommand.Parameters.AddWithValue("@Username", username);
                        sqlCommand.Parameters.AddWithValue("@Password", password);
                        //sqlCommand.Parameters.AddWithValue("@Email", email);

                        // Execute the query
                        object result = sqlCommand.ExecuteScalar();  // Returns a single value or null

                        // Return the UserGUID if found, otherwise return -1
                        return result != null ? (Guid)result : Guid.Empty;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception details (e.g., using a logger)
                    Console.WriteLine($"Error getting user GUID: {ex.Message}");

                    // Optionally, throw a more specific exception or return a specific error code
                    throw new InvalidOperationException("Failed to retrieve user GUID.");
                }
            }

        }




        //**************************************************************************************************************************************************
        //Check Account availability
        public static bool IsUsernameAvailable(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // Replace with your connection string
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Accounts WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    int count = (int)command.ExecuteScalar();

                    return count == 0;
                }
            }
        }

        //**************************************************************************************************************************************************



        //
        public void Command(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["List_To_Do__Tab_.Properties.Settings.todoConnString"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        foreach (var param in parameters)
                        {
                            sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error executing the command", ex);
                }
            }
        }
        //**************************************************************************************************************************************************






    }
}

