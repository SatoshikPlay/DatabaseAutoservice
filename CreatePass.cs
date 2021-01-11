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
    public partial class CreatePass : Form
    {
        MainWindow MainWindow = new MainWindow();
        public CreatePass()
        {
            InitializeComponent();
        }

        private void CreatePass_Load(object sender, EventArgs e)
        {

        }

        private void ButtonCreatePass_Click(object sender, EventArgs e)
        {
            string passWordCreate = textBoxPass.Text;
            string passWordCreateRepeat = textBoxPassRepeat.Text;
            if (passWordCreate == passWordCreateRepeat)
            {
                PassWordWindow passWordWindow = new PassWordWindow();
                MainWindow.Connection = new SqlConnection(MainWindow.DataSource);
                MainWindow.Table = new DataTable();
                MainWindow.Connection = new SqlConnection(MainWindow.DataSource);

                MainWindow.Command = new SqlCommand("INSERT INTO PassWords (PassWord) VALUES (@key)", MainWindow.Connection);
                MainWindow.Command.Parameters.Add("@key", SqlDbType.VarChar).Value = passWordCreate;

                MainWindow.Adapter = new SqlDataAdapter();
                MainWindow.Adapter.SelectCommand = MainWindow.Command;
                MainWindow.Adapter.Fill(MainWindow.Table);
                this.Close();
                passWordWindow.Show();
            }
            else
            {
                labelCreatePassError.Visible = true;
            }
        }

        private void TextBoxPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            MainWindow.ForbiddenInputs(e);
        }

        private void TextBoxPassRepeat_KeyPress(object sender, KeyPressEventArgs e)
        {
            MainWindow.ForbiddenInputs(e);
        }
    }
}
