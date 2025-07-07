using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq.Expressions;


namespace List_To_Do__Tab_
{
    public partial class LoginMenu : Form
    {
        //readonly string connectionString = "Data Source=DESKTOP-6T53PQ0;Initial Catalog=\"To do list\";Integrated Security=True;User ID=Admin;Trust Server Certificate=True";
        readonly Accounts Accounts = new Accounts();


        //**************************************************************************************************************************************************
        //Logic for pressing Enter instead of hit the Login button
        public LoginMenu()
        {
            InitializeComponent();
            this.KeyPreview = true;  // Ensure the form receives key events
            this.KeyDown += new KeyEventHandler(LoginMenu_KeyDown);
            
        }


        

        private void LoginMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Call the login button click logic directly
                LoginButt_Click_1(sender, e);
            }
        }



        //**************************************************************************************************************************************************

        private void LoginButt_Click_1(object sender, EventArgs e)
        {
            string username = userBox.Text;
            string password = passBox.Text;

            if (username.Trim() == "")
            {
                MessageBox.Show("Please Fill In Your Account ! ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (password.Trim() == "")
            {
                MessageBox.Show("Please Fill In Your Account ! ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                Guid userGUID = Accounts.GetUserGUID(username, password);

                if (userGUID == Guid.Empty)
                    {
                        MessageBox.Show("Wrong information, Please try again!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                    Accounts.UserSession.CurrentUserGUID = userGUID; // Store the userGUID in UserSession
                    string token = JwtHelper.GenerateJwtToken(username, userGUID);
                    MessageBox.Show($"Welcome to Bee Happy - An app that help you track your daily task !", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show(token);
                    
                    MainMenuForm mainMenu = new MainMenuForm();

                    mainMenu.StartPosition = FormStartPosition.Manual; // Allow manual positioning
                    mainMenu.Show(); // Show the form first to ensure width & height are initialized

                    //int centerX = (Screen.PrimaryScreen.Bounds.Width - mainMenu.Width) / 2;
                    //int centerY = (Screen.PrimaryScreen.Bounds.Height - mainMenu.Height) / 2;
                    mainMenu.Location = (new Point(0, 0));

                    //mainMenu.Location = new Point(centerX, centerY);


                    //mainMenu.Location = new Point(0, 0); // Set to top-left corner
                    
                    this.Hide();

                    
                }
            }
        }
       

        //**************************************************************************************************************************************************

        public static class JwtHelper
        {
            private static readonly string SecretKey = "MySuperSecretKeyForJWTAuthentication256bits";  // 32 characters (256 bits)
                                                                                                       // Keep this key secure and private.

            public static string GenerateJwtToken(string username, Guid UserGUID)
            {
                var key = Encoding.UTF8.GetBytes(SecretKey);

                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserGUID", UserGUID.ToString())
        };

                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                    issuer: "Admin",
                    audience: "User",
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: signingCredentials
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            public static ClaimsPrincipal ValidateJwtToken(string token)
            {
                var key = Encoding.UTF8.GetBytes(SecretKey);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Admin",
                    ValidAudience = "Admin",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                    return principal;
                }
                catch
                {
                    return null; // Invalid token
                }
            }
        }

        //**************************************************************************************************************************************************

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog();
            this.Hide();
        }

        private void linkForget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPass forgetPass = new ForgetPass();
            forgetPass.ShowDialog();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

