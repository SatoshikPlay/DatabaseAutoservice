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
    public partial class PassWordWindow : Form
    {
        MainWindow MainWindow = new MainWindow();
        public bool FirstPassword { get; set; } = false;
        public PassWordWindow()
        {
            InitializeComponent();
        }
        private void PassWordWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void ButtonPass_Click(object sender, EventArgs e)
        {
            string passWord = textBoxPass.Text;
            MainWindow.Table = new DataTable();
            MainWindow.Connection = new SqlConnection(MainWindow.DataSource);
            MainWindow.Command = new SqlCommand("SELECT * FROM PassWords WHERE PassWord = @key", MainWindow.Connection);
            MainWindow.Command.Parameters.Add("@key", SqlDbType.VarChar).Value = passWord;
            MainWindow.Adapter = new SqlDataAdapter();
            MainWindow.Adapter.SelectCommand = MainWindow.Command;
            MainWindow.Adapter.Fill(MainWindow.Table);
            if (MainWindow.Table.Rows.Count > 0)
            {
                EditingMode editingMode = new EditingMode();
                editingMode.Show();
                this.Close();
            }
            else
            {
                labelError.Visible = true;
            }


        }
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            MainWindow.Table = new DataTable();
            MainWindow.Connection = new SqlConnection(MainWindow.DataSource);
            MainWindow.Command = new SqlCommand("SELECT * FROM PassWords", MainWindow.Connection);
            MainWindow.Adapter = new SqlDataAdapter();
            MainWindow.Adapter.SelectCommand = MainWindow.Command;
            MainWindow.Adapter.Fill(MainWindow.Table);
            if (MainWindow.Table.Rows.Count == 0)
            {
                FirstPassword = true;
                CreatePass createPass = new CreatePass();
                createPass.Show();
                this.Close();
            }
            else
            {
                PasswordConfirmation confirmation = new PasswordConfirmation();
                confirmation.Show();
                this.Close();
            }
        }

        private void TextBoxPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            MainWindow.ForbiddenInputs(e);
        }
    }
}
