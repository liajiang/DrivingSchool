using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Маршрут : Form
    {
        public Маршрут()
        {
            InitializeComponent();
        }

        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory +
                @"\Автошкола.mdf;Integrated Security=True;Current Language=Russian";

        int id;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                Help.ShowHelp(this, "Spravka.chm");
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void маршрутBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void Маршрут_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Маршрут". При необходимости она может быть перемещена или удалена.
            this.маршрутTableAdapter.Fill(this.автошколаDataSet.Маршрут);
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void маршрутDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            маршрутTableAdapter.Fill(автошколаDataSet.Маршрут);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (маршрутDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From Маршрут WHERE Код_Маршрут=@Код_Маршрут", con);
                            com.Parameters.AddWithValue("Код_Маршрут", Convert.ToInt32(маршрутDataGridView[0, маршрутDataGridView.CurrentRow.Index].Value.ToString()));
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
            маршрутTableAdapter.Fill(автошколаDataSet.Маршрут);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != ""&& textBox4.Text != "")
                    маршрутTableAdapter.Insert(int.Parse(textBox3.Text),textBox4.Text);
                else
                    MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Validate();
            this.маршрутBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            маршрутTableAdapter.Fill(автошколаDataSet.Маршрут);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    id = Convert.ToInt32(маршрутDataGridView[0, маршрутDataGridView.CurrentRow.Index].Value.ToString());
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Select Номер, Название from Маршрут WHERE [Код_Маршрут] = @Код_Маршрут", con);
                        command.Parameters.AddWithValue("Код_Маршрут", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            textBox2.Text = Convert.ToString(reader[0]);//Номер
                            textBox1.Text = Convert.ToString(reader[1]);//Название
                        }
                    }
                    маршрутTableAdapter.Fill(автошколаDataSet.Маршрут);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox1.Text != "")
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand update = new SqlCommand("Update [Маршрут] Set Название = @Название, Номер = @Номер Where [Код_Маршрут] = @Код_Маршрут", con);

                        update.Parameters.AddWithValue("@Код_Маршрут", id);
                        update.Parameters.AddWithValue("@Название", textBox1.Text);
                        update.Parameters.AddWithValue("@Номер", textBox2.Text);
                        update.ExecuteNonQuery();
                    }
                else
                    MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            маршрутTableAdapter.Fill(автошколаDataSet.Маршрут);
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;
            toolStripTextBox1.ForeColor = Color.Black;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < маршрутDataGridView.RowCount; i++)
            {
                маршрутDataGridView.CurrentCell = null;
                маршрутDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < маршрутDataGridView.ColumnCount; j++)
                {
                    if (маршрутDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (маршрутDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            маршрутDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < маршрутDataGridView.RowCount; i++)
            {
                if (маршрутDataGridView.Rows[i].Selected == false)
                    маршрутDataGridView.Rows[i].Visible = false;
            }

            if (toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < маршрутDataGridView.RowCount; i++)
                {
                    маршрутDataGridView.Rows[i].Selected = false;
                    маршрутDataGridView.Rows[i].Visible = true;
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