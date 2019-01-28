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
using Excel = Microsoft.Office.Interop.Excel;

namespace Курсовая
{
    public partial class Результат : Form
    {
        public Результат()
        {
            InitializeComponent();
        }

        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory +
                @"\Автошкола.mdf;Integrated Security=True;Current Language=Russian";


        private void Результат_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Учащийся". При необходимости она может быть перемещена или удалена.
            this.учащийсяTableAdapter.Fill(this.автошколаDataSet.Учащийся);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Экзамен". При необходимости она может быть перемещена или удалена.
            this.экзаменTableAdapter.Fill(this.автошколаDataSet.Экзамен);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Результат". При необходимости она может быть перемещена или удалена.
            this.результатTableAdapter.Fill(this.автошколаDataSet.Результат);
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand select = new SqlCommand("SELECT НазваниеТипаОшибки FROM Результат WHERE Код_Учащийся = @Код_Учащийся", con);

                    select.Parameters.AddWithValue("@Код_Учащийся", comboBox1.SelectedValue);//учащейся

                    SqlDataReader reader = select.ExecuteReader();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    int grub = 0;
                    int avg = 0;
                    int little = 0;
                    while (reader.Read())
                    {
                        switch (Convert.ToString(reader["НазваниеТипаОшибки"]))
                        {
                            case "Грубые": grub++; break;
                            case "Средние": avg++; break;
                            case "Мелкие": little++; break;
                        }
                    }
                    textBox1.Text += grub;
                    textBox2.Text += avg;
                    textBox3.Text += little;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            результатTableAdapter.Fill(автошколаDataSet.Результат);
            
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;
            toolStripTextBox1.ForeColor = Color.Black;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < результатDataGridView.RowCount; i++)
            {
                результатDataGridView.CurrentCell = null;
                результатDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < результатDataGridView.ColumnCount; j++)
                {
                    if (результатDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (результатDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            результатDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < результатDataGridView.RowCount; i++)
            {
                if (результатDataGridView.Rows[i].Selected == false)
                    результатDataGridView.Rows[i].Visible = false;
            }

            if (toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < результатDataGridView.RowCount; i++)
                {
                    результатDataGridView.Rows[i].Selected = false;
                    результатDataGridView.Rows[i].Visible = true;
                }
            }
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                toolStripTextBox1.Text = "Поиск";
                toolStripTextBox1.ForeColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value > DateTime.Now || dateTimePicker2.Value > DateTime.Now || dateTimePicker1.Value > dateTimePicker2.Value || dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("Неправильная дата");
                    return;
                }
                for (int i = 1; i < результатDataGridView.RowCount; i++)
                {
                    if (Convert.ToDateTime(результатDataGridView.Rows[i].Cells[11].Value) >= dateTimePicker1.Value &&
                        Convert.ToDateTime(результатDataGridView.Rows[i].Cells[11].Value) <= dateTimePicker2.Value)
                    {
                        результатDataGridView.Rows[i].Visible = true;
                    }
                    else
                    {
                        результатDataGridView.Rows[i].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < результатDataGridView.RowCount; i++)
            {
                результатDataGridView.Rows[i].Visible = true;
            }
        }

        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            for (int i = 8; i < результатDataGridView.Columns.Count + 1; i++)
            {
                ExcelWorkSheet.Cells[1, i - 7] = результатDataGridView.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < результатDataGridView.Rows.Count; i++)
            {
                for (int j = 7; j < результатDataGridView.Columns.Count; j++)
                {
                    ExcelWorkSheet.Cells[i + 2, j - 6] = результатDataGridView.Rows[i].Cells[j].Value.ToString();
                }
            }


            ExcelWorkSheet.Columns.EntireColumn.AutoFit();


            ExcelApp.Visible = true;
        }
    }
}
