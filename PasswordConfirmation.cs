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
    public partial class PasswordConfirmation : Form
    {
        MainWindow MainWindow = new MainWindow();
        public PasswordConfirmation()
        {
            InitializeComponent();
        }

        private void PasswordConfirmation_Load(object sender, EventArgs e)
        {

        }

        private void ButtonConfirmation_Click(object sender, EventArgs e)
        {
            string password = textBoxConfirmation.Text;
            MainWindow.Table = new DataTable();
            PassWordWindow passWordWindow = new PassWordWindow();
            MainWindow.Connection = new SqlConnection(MainWindow.DataSource);
            MainWindow.Command = new SqlCommand("SELECT * FROM PassWords WHERE PassWord = @key", MainWindow.Connection);
            MainWindow.Command.Parameters.Add("@key", SqlDbType.VarChar).Value = password;
            MainWindow.Adapter = new SqlDataAdapter();
            MainWindow.Adapter.SelectCommand = MainWindow.Command;
            MainWindow.Adapter.Fill(MainWindow.Table);
            if (MainWindow.Table.Rows.Count > 0)
            {
                CreatePass createPass = new CreatePass();
                createPass.Show();
                this.Close();
            }
            else
            {
                labelPassCheckError.Visible = true;
            }
        }
        private void TextBoxConfirmation_KeyPress(object sender, KeyPressEventArgs e)
        {
            MainWindow.ForbiddenInputs(e);
        }
    }
}
