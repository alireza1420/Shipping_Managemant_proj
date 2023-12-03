using System.Data.OleDb;

namespace Shipping_Managemant_proj
{
    public partial class dashbord : Form
    {
        public dashbord()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users1.accdb;Persist Security Info=False;");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_Submit_Click(object sender, EventArgs e)
        {
            if (Terms_CheckedChanged != null)
            {
                try
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = "INSERT INTO db_Shipments (loading_port, destination, loading_date, workers, Insurance) " +
                            " VALUES (?, ?, ?, ? ,? )";
                        cmd.Parameters.AddWithValue("loading_port", loading_port.Text);
                        cmd.Parameters.AddWithValue("destination", destination.Text);
                        cmd.Parameters.AddWithValue("loading_date", dateTimePicker1.Text);
                        cmd.Parameters.AddWithValue("workers", workers_number.Text);
                        if (Terms.Checked)
                        {
                            cmd.Parameters.AddWithValue("Insurance", "Yes");

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("Insurance", "No");
                        }
                        using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users1.accdb;Persist Security Info=False;"))
                        {
                            cmd.Connection = connection;
                            connection.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(" Shipment was received Successfully", "Shipment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Shipment failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please Accept Terms of Service", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Terms_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
