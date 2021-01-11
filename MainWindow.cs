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

namespace DBAutoServise
{
    public partial class MainWindow : Form
    {
        public string DataSource { get; private set; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Курсовая\DBAutoServise\DBAutoService.mdf;Integrated Security=True";
        public SqlConnection Connection { get; set; } = null;
        public SqlDataAdapter Adapter { get; set; } = null;
        public DataTable Table { get; set; } = null;
        public DataSet SetData { get; set; } = null;
        public SqlCommand Command { get; set; } = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ForbiddenInputs(KeyPressEventArgs e)
        {
            if (!char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void SearchCar(string text)
        {
            Command = new SqlCommand("SELECT * FROM CarDatabase WHERE Auto =  '%" + text + "%'", Connection);
            Table = new DataTable();
            Table.Load(Command.ExecuteReader());
            dataGridView1.DataSource = Table.DefaultView;
        }
        public void DataLoad()
        {
            Adapter = new SqlDataAdapter("SELECT * FROM CarDatabase", Connection);
            dataGridView1.DataSource = Table;
            SetData = new DataSet();
            Adapter.Fill(SetData, "CarDatabase");
            dataGridView1.DataSource = SetData.Tables["CarDatabase"];
        }
        public void DataReload()
        {
            SetData.Tables["CarDatabase"].Clear();
            Adapter.Fill(SetData, "CarDatabase");
            dataGridView1.DataSource = SetData.Tables["CarDatabase"];
        }
        private void MainWindow_Load(object sender, EventArgs e)
        { 
            Connection = new SqlConnection(DataSource);
            Connection.Open();
            DataLoad();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            DataReload();
        }

        private void ButtonEditingMode_Click(object sender, EventArgs e)
        {
            PassWordWindow passWordWindow = new PassWordWindow();
            passWordWindow.Show();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxSeachCar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
