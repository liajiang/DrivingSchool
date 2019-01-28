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

namespace Курсовая
{
    public partial class Ошибка : Form
    {
        public Ошибка()
        {
            InitializeComponent();
        }

        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory +
               @"\Автошкола.mdf;Integrated Security=True;Current Language=Russian";

        int id;

        private void Ошибка_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ТипОшибки". При необходимости она может быть перемещена или удалена.
            this.типОшибкиTableAdapter.Fill(this.автошколаDataSet.ТипОшибки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Ошибка". При необходимости она может быть перемещена или удалена.
            this.ошибкаTableAdapter.Fill(this.автошколаDataSet.Ошибка);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ОшибкаView". При необходимости она может быть перемещена или удалена.
            this.ошибкаViewTableAdapter.Fill(this.автошколаDataSet.ОшибкаView);
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ошибкаTableAdapter.Insert(int.Parse(comboBox1.SelectedValue.ToString()), textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Validate();
            this.ошибкаBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            ошибкаTableAdapter.Fill(автошколаDataSet.Ошибка);
            ошибкаViewTableAdapter.Fill(автошколаDataSet.ОшибкаView);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ошибкаTableAdapter.Fill(автошколаDataSet.Ошибка);
            ошибкаViewTableAdapter.Fill(автошколаDataSet.ОшибкаView);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (ошибкаViewDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From Ошибка WHERE Код_Ошибка=@Код_Ошибка", con);
                            com.Parameters.AddWithValue("Код_Ошибка", Convert.ToInt32(ошибкаViewDataGridView[0, ошибкаViewDataGridView.CurrentRow.Index].Value.ToString()));
                            try
                            {
                                com.ExecuteNonQuery();
                            }
                            catch (Exception ex)

                            {
                                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                    }
                }
            }
            ошибкаTableAdapter.Fill(автошколаDataSet.Ошибка);
            ошибкаViewTableAdapter.Fill(автошколаDataSet.ОшибкаView);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand update = new SqlCommand("Update [Ошибка] Set Название = @Название, Код_ТипОшибки = @Код_ТипОшибки from Ошибка Where [Код_Ошибка] = @Код_Ошибка", con);

                        update.Parameters.AddWithValue("@Код_Ошибка", id);
                        update.Parameters.AddWithValue("@Название", textBox2.Text);//Название
                        update.Parameters.AddWithValue("@Код_ТипОшибки", comboBox2.SelectedValue);//Код_ТипОшибки

                    update.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ошибкаTableAdapter.Fill(автошколаDataSet.Ошибка);
            ошибкаViewTableAdapter.Fill(автошколаDataSet.ОшибкаView);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    id = Convert.ToInt32(ошибкаViewDataGridView[0, ошибкаViewDataGridView.CurrentRow.Index].Value.ToString());
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Select Название, Код_ТипОшибки from Ошибка WHERE [Код_Ошибка] = @Код_Ошибка", con);
                        command.Parameters.AddWithValue("Код_Ошибка", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            textBox2.Text = Convert.ToString(reader[0]);//Название
                            comboBox2.SelectedValue = Convert.ToString(reader[1]);//Код_ТипОшибки
                        }
                    }
                    ошибкаTableAdapter.Fill(автошколаDataSet.Ошибка);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;
            toolStripTextBox1.ForeColor = Color.Black;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < ошибкаViewDataGridView.RowCount; i++)
            {
                ошибкаViewDataGridView.CurrentCell = null;
                ошибкаViewDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < ошибкаViewDataGridView.ColumnCount; j++)
                {
                    if (ошибкаViewDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (ошибкаViewDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            ошибкаViewDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < ошибкаViewDataGridView.RowCount; i++)
            {
                if (ошибкаViewDataGridView.Rows[i].Selected == false)
                    ошибкаViewDataGridView.Rows[i].Visible = false;
            }

            if (toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < ошибкаViewDataGridView.RowCount; i++)
                {
                    ошибкаViewDataGridView.Rows[i].Selected = false;
                    ошибкаViewDataGridView.Rows[i].Visible = true;
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
    }
}