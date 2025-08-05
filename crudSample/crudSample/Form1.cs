using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace crudSample
{
    public partial class Form1 : Form
    {
        string server = "localhost";
        string uid = "root";
        string password = "";
        string database = "practice";
        int selectedID = -1;
        public Form1()
        {
            InitializeComponent();
            getTable();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //CRUD Insert Function
            string message = "SampleInsert";
            string conString = "server=" + server + ";uid=" + uid + ";password=" + password + ";database=" + database;
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string table = "insert into record(task) values('" + message + "')";
            MySqlCommand cmd = new MySqlCommand(table, con);
            int response = cmd.ExecuteNonQuery();
            MessageBox.Show("Task Added");
            getTable();
        }
        public void getTable()
        {
            //CRUD Read Function
            string conString = "server=" + server + ";uid=" + uid + ";password=" + password + ";database=" + database;
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string table = "select * from record";
            MySqlCommand cmd = new MySqlCommand(table, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //CRUD Update Function
            if (selectedID != -1)
            {
                string message = "UpdatedData";
                string conString = "server=" + server + ";uid=" + uid + ";password=" + password + ";database=" + database;
                MySqlConnection con = new MySqlConnection(conString);
                con.Open();
                string table = "update record set task = '" + message + "' where id = '" + selectedID + "'";
                MySqlCommand cmd = new MySqlCommand(table, con);
                int response = cmd.ExecuteNonQuery();
                MessageBox.Show("Task Updated");
                getTable();
            }
            else
            {
                MessageBox.Show("No Selected Cell");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //CRUD Delete Function
            if (selectedID != -1)
            {
                string conString = "server=" + server + ";uid=" + uid + ";password=" + password + ";database=" + database;
                MySqlConnection con = new MySqlConnection(conString);
                con.Open();
                string table = "delete from record where id = '" + selectedID + "'";
                MySqlCommand cmd = new MySqlCommand(table, con);
                int response = cmd.ExecuteNonQuery();
                MessageBox.Show("Task Deleted");
                getTable();
            }
            else
            {
                MessageBox.Show("No Selected Cell");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedID = Convert.ToInt32(row.Cells["id"].Value);
            }
        }
    }
}