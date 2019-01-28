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
    public partial class ТипТС : Form
    {
        public ТипТС()
        {
            InitializeComponent();
            типТСDataGridView.Columns[0].Visible = false;
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

        private void типТСBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.типТСBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                this.типТСTableAdapter.Fill(this.автошколаDataSet.ТипТС);
            }

        }

        private void ТипТС_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ТипТС". При необходимости она может быть перемещена или удалена.
            this.типТСTableAdapter.Fill(this.автошколаDataSet.ТипТС);
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Stream myStream;
                saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Word Document (*.doc)|*.doc|Все файлы (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        StreamWriter myWritet = new StreamWriter(myStream);
                        try
                        {
                            myWritet.WriteLine(типТСDataGridView.Columns[1].HeaderText + " ");

                            for (int i = 0; i < типТСDataGridView.RowCount; i++)
                            {
                                for (int j = 1; j < типТСDataGridView.ColumnCount; j++)
                                {
                                    myWritet.Write(типТСDataGridView.Rows[i].Cells[j].Value.ToString() + " ");
                                }
                                myWritet.WriteLine();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            myWritet.Close();
                        }
                        myStream.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                this.типТСTableAdapter.Fill(this.автошколаDataSet.ТипТС);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < типТСDataGridView.RowCount; i++)
                {
                    типТСDataGridView.Rows[i].Selected = false;
                    for (int j = 0; j < типТСDataGridView.ColumnCount; j++)
                        if (типТСDataGridView.Rows[i].Cells[j].Value != null)
                            if (типТСDataGridView.Rows[i].Cells[j].Value.ToString().ToLower().Contains(toolStripTextBox1.Text.ToLower()))
                            {
                                типТСDataGridView.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                this.типТСTableAdapter.Fill(this.автошколаDataSet.ТипТС);
            }
        }

        private void типТСDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ошибка!");
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;
            toolStripTextBox1.ForeColor = Color.Black;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < типТСDataGridView.RowCount; i++)
            {
                типТСDataGridView.CurrentCell = null;
                типТСDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < типТСDataGridView.ColumnCount; j++)
                {
                    if (типТСDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (типТСDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            типТСDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < типТСDataGridView.RowCount; i++)
            {
                if (типТСDataGridView.Rows[i].Selected == false)
                    типТСDataGridView.Rows[i].Visible = false;
            }

            if (toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < типТСDataGridView.RowCount; i++)
                {
                    типТСDataGridView.Rows[i].Selected = false;
                    типТСDataGridView.Rows[i].Visible = true;
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (типТСDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From ТипТС WHERE Код_ТипТС=@Код_ТипТС", con);
                            com.Parameters.AddWithValue("Код_ТипТС", Convert.ToInt32(типТСDataGridView[0, типТСDataGridView.CurrentRow.Index].Value.ToString()));
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
            типТСTableAdapter.Fill(автошколаDataSet.ТипТС);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            типТСTableAdapter.Fill(автошколаDataSet.ТипТС);
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                toolStripTextBox1.Text = "Поиск";
                toolStripTextBox1.ForeColor = Color.Gray;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    id = Convert.ToInt32(типТСDataGridView[0, типТСDataGridView.CurrentRow.Index].Value.ToString());
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Select НазваниеТС from ТипТС WHERE [Код_ТипТС] = @Код_ТипТС", con);
                        command.Parameters.AddWithValue("Код_ТипТС", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            textBox2.Text = Convert.ToString(reader[0]);//код тип тс
                        }
                    }
                    типТСTableAdapter.Fill(автошколаDataSet.ТипТС);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                    типТСTableAdapter.Insert(textBox1.Text);
                else
                    MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Validate();
            this.типТСBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            типТСTableAdapter.Fill(автошколаDataSet.ТипТС);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand update = new SqlCommand("Update [ТипТС] Set НазваниеТС = @НазваниеТС Where [Код_ТипТС] = @Код_ТипТС", con);

                        update.Parameters.AddWithValue("@Код_ТипТС", id);
                        update.Parameters.AddWithValue("@НазваниеТС", textBox2.Text);
                        update.ExecuteNonQuery();
                    }
                else
                    MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            типТСTableAdapter.Fill(автошколаDataSet.ТипТС);
        }
    }
}
