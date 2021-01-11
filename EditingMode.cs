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
    public partial class EditingMode : Form
    {
        public SqlCommandBuilder CommandBuilder { get; set; } = null;
        public bool AddNewRow { get; set; } = false;
        MainWindow MainWindow = new MainWindow();
        public EditingMode()
        {
            InitializeComponent();
        }
        public void DataReload()
        {
            MainWindow.SetData.Tables["CarDatabase"].Clear();
            MainWindow.Adapter.Fill(MainWindow.SetData, "CarDatabase");
            dataGridView1.DataSource = MainWindow.SetData.Tables["CarDatabase"];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[5, i] = linkCell;
            }
        }
        public void DataLoad()
        {
            MainWindow.Adapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Delete] FROM CarDatabase", MainWindow.Connection);
            dataGridView1.DataSource = MainWindow.Table;
            CommandBuilder = new SqlCommandBuilder(MainWindow.Adapter);
            CommandBuilder.GetInsertCommand();
            CommandBuilder.GetUpdateCommand();
            CommandBuilder.GetDeleteCommand();
            MainWindow.SetData = new DataSet();
            MainWindow.Adapter.Fill(MainWindow.SetData, "CarDatabase");
            dataGridView1.DataSource = MainWindow.SetData.Tables["CarDatabase"];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[5, i] = linkCell;
            }

        }
        private void EditingModeWindow_Load(object sender, EventArgs e)
        {
            MainWindow.Connection = new SqlConnection(MainWindow.DataSource);
            MainWindow.Connection.Open();
            DataLoad();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            DataReload();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (e.ColumnIndex == 5)
            {
                if (task == "Delete")
                {
                    if (MessageBox.Show("Удалить объект?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        MainWindow.Adapter.Update(MainWindow.SetData, "CarDatabase");
                    }
                }
                else
                if (task == "Incert")
                {
                    int rowIndex = dataGridView1.Rows.Count - 2;
                    DataRow row = MainWindow.SetData.Tables["CarDatabase"].NewRow();
                    row["Номер автомобиля (ID)"] = dataGridView1.Rows[rowIndex].Cells["Номер автомобиля (ID)"].Value;
                    row["Марка автомобиля"] = dataGridView1.Rows[rowIndex].Cells["Марка автомобиля"].Value;
                    row["Причина поломки"] = dataGridView1.Rows[rowIndex].Cells["Причина поломки"].Value;
                    row["Цена ремонта"] = dataGridView1.Rows[rowIndex].Cells["Цена ремонта"].Value;
                    row["Дата ремонта"] = dataGridView1.Rows[rowIndex].Cells["Дата ремонта"].Value;
                    MainWindow.SetData.Tables["CarDatabase"].Rows.Add(row);
                    MainWindow.SetData.Tables["CarDatabase"].Rows.RemoveAt(MainWindow.SetData.Tables["CarDatabase"].Rows.Count - 1);
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                    MainWindow.Adapter.Update(MainWindow.SetData, "CarDatabase");
                    AddNewRow = false;
                }
                else
                if (task == "Update")
                {
                    int rowIndex = e.RowIndex;
                    MainWindow.SetData.Tables["CarDatabase"].Rows[rowIndex]["Номер автомобиля (ID)"] = dataGridView1.Rows[rowIndex].Cells["Номер автомобиля (ID)"].Value;
                    MainWindow.SetData.Tables["CarDatabase"].Rows[rowIndex]["Марка автомобиля"] = dataGridView1.Rows[rowIndex].Cells["Марка автомобиля"].Value;
                    MainWindow.SetData.Tables["CarDatabase"].Rows[rowIndex]["Причина поломки"] = dataGridView1.Rows[rowIndex].Cells["Причина поломки"].Value;
                    MainWindow.SetData.Tables["CarDatabase"].Rows[rowIndex]["Цена ремонта"] = dataGridView1.Rows[rowIndex].Cells["Цена ремонта"].Value;
                    MainWindow.SetData.Tables["CarDatabase"].Rows[rowIndex]["Дата ремонта"] = dataGridView1.Rows[rowIndex].Cells["Дата ремонта"].Value;
                    MainWindow.Adapter.Update(MainWindow.SetData, "CarDatabase");
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                }
                DataReload();
            }
        }

        private void DataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (AddNewRow == false)
            {
                AddNewRow = true;
                int lastRow = dataGridView1.Rows.Count - 2;
                DataGridViewRow row = dataGridView1.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[5, lastRow] = linkCell;
                row.Cells["Delete"].Value = "Incert";
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (AddNewRow == false)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[5, rowIndex] = linkCell;
                editingRow.Cells["Delete"].Value = "Update";
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if ((dataGridView1.CurrentCell.ColumnIndex == 3) || (dataGridView1.CurrentCell.ColumnIndex == 4))
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }
        private void Column_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
