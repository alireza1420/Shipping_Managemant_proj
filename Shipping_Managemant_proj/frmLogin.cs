using System.Data.OleDb;

namespace Shipping_Managemant_proj
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users1.accdb;Persist Security Info=False;");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Username and Password fields cannot be empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = "SELECT * FROM db_users WHERE username='" + txtUsername.Text + "and password='" + txtPassword.Text + "'";
                        OleDbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            MessageBox.Show("Login was Successful", "Login Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Username and Password field are empty", "Registeration Faield", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close(); //close the database connection
                }
            }
            */
            /*
            connection.Open();
            string login = "SELECT * FROM db_users WHERE username='" + txtUsername.Text + "and password='" + txtPassword.Text + "'";
            cmd = new OleDbCommand(login);
            OleDbDataReader reader = cmd.ExecuteReader();
            connection.Close();
            */

            new dashbord().Show();
            this.Hide();


            /*
            if (reader.Read() == true)
            {


                MessageBox.Show("Username and Password field are empty", "Registeration Faield", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtUsername.Text = "";
                txtUsername.Focus();


            }

            */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";

            txtUsername.Focus();
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked == true)
            {
                txtUsername.PasswordChar = '\0';

            }
            else
            {
                txtUsername.PasswordChar = '*';

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
