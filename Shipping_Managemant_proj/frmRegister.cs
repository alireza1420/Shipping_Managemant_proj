using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;

namespace Shipping_Managemant_proj
{


    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();

        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users1.accdb;Persist Security Info=False;");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConPassword.Text))
            {
                MessageBox.Show("Username and Password fields cannot be empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPassword.Text == txtConPassword.Text)
            {
                try
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = "INSERT INTO db_users (username, [password]) VALUES (?, ?)";
                        cmd.Parameters.AddWithValue("username", txtUsername.Text);
                        string hashedPassword = HashPassword(txtPassword.Text);
                        cmd.Parameters.AddWithValue("password", hashedPassword);

                        using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users1.accdb;Persist Security Info=False;"))
                        {
                            cmd.Connection = connection;
                            connection.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User registered successfully", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUsername.Text = "";
                                txtPassword.Text = "";
                                txtConPassword.Text = "";
                                new dashbord().Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Registration failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Passwords do not match", "Please Re-enter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Text = "";
                txtConPassword.Text = "";
                txtPassword.Focus();
            }

        }

        private string HashPassword(string password)
        {
            // Implement a secure password hashing algorithm (e.g., using BCrypt or Argon2)
            // For simplicity, let's assume a basic hash for demonstration purposes.
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConPassword.PasswordChar = '*';


            }
        }

        private void txtConPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}
