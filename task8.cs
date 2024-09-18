using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ADO
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {

            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = "Server=DESKTOP-VPENOVD\\SQLEXPRESS;Database=iTi;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public void get_istructors()
        {
            SqlCommand sqlCommand = new SqlCommand("select [Ins_Id],[Ins_Name],[Ins_Degree],[Salary],[Dept_Id] from Instructor", conn);
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            conn.Close();
            dvg_instructors.DataSource = dt;

        }
        void get_department()
        {
            SqlCommand sqlCommand = new SqlCommand("select [Dept_Id],[Dept_Name] from Department", conn);
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            conn.Close();
            cb_dn.DataSource = dt;
            cb_dn.DisplayMember = "Dept_Name";
            cb_dn.ValueMember = "Dept_Id";
            cb_dn.SelectedIndex = -1;


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }
        int idcurrent = 0;
        int rows_effected = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Instructor (Ins_Name, Ins_Degree, Salary, Dept_Id) VALUES (@ins_n, @ins_d, @ins_s, @d_id)", conn))
            {
                sqlCommand.Parameters.AddWithValue("@ins_n", txt_name.Text);
                sqlCommand.Parameters.AddWithValue("@ins_d", txt_degree.Text);
                sqlCommand.Parameters.AddWithValue("@ins_s", Convert.ToDouble(txt_salary.Text));
                sqlCommand.Parameters.AddWithValue("@d_id", cb_dn.SelectedValue);

                conn.Open();
                int rows_effected = sqlCommand.ExecuteNonQuery();
                conn.Close();

                if (rows_effected > 0)
                {
                    MessageBox.Show("Added data successfully");
                    get_istructors();
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            get_istructors();
            get_department();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nud_degree_ValueChanged(object sender, EventArgs e)
        {

        }

        public void clear()
        {
            txt_degree.Text = txt_name.Text = txt_salary.Text = string.Empty;
            cb_dn.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Instructor SET Ins_Name = @ins_n, Ins_Degree = @ins_d, Salary = @ins_s, Dept_Id = @d_id WHERE Ins_Id = @id", conn);

            sqlCommand.Parameters.AddWithValue("@ins_n", txt_name.Text);
            sqlCommand.Parameters.AddWithValue("@ins_d", txt_degree.Text);
            sqlCommand.Parameters.AddWithValue("@ins_s", Convert.ToDouble(txt_salary.Text));
            sqlCommand.Parameters.AddWithValue("@d_id", cb_dn.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@id", idcurrent);

            conn.Open();
            rows_effected = sqlCommand.ExecuteNonQuery();
            conn.Close();
            if (rows_effected > 0)
            {
                MessageBox.Show("updated is done");
                get_istructors();
                clear();
                
            }

        }

        private void dvg_instructors_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dvg_instructors.SelectedRows[0];
            idcurrent = (int)row.Cells["Ins_Id"].Value;
            txt_name.Text = row.Cells["Ins_Name"].Value.ToString();
            txt_degree.Text = row.Cells["Ins_Degree"].Value.ToString();
            txt_salary.Text = row.Cells["Salary"].Value.ToString();
            cb_dn.SelectedValue = row.Cells["Dept_Id"].Value;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Instructor WHERE Ins_Id=@id", conn);

            SqlCommand sqlCommand1 = new SqlCommand($"DELETE FROM Ins_Course WHERE Ins_Id=@id", conn);

            sqlCommand.Parameters.AddWithValue("id",idcurrent );
            sqlCommand1.Parameters.AddWithValue("id",idcurrent );

            conn.Open();
            rows_effected =sqlCommand1.ExecuteNonQuery();
            rows_effected =sqlCommand.ExecuteNonQuery();
            conn.Close();
            if (rows_effected > 0)
            {
                MessageBox.Show("deleted is done ");
                get_istructors();
                clear();

            }

        }
    }
}