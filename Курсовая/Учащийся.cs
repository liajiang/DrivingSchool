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
    public partial class Учащийся : Form
    {
        public Учащийся()
        {
            InitializeComponent();
            учащийсяDataGridView.Columns[0].Visible = false;
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

        private void учащийсяBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.учащийсяBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                this.учащийсяTableAdapter.Fill(this.автошколаDataSet.Учащийся);
            }

        }

        private void Учащийся_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Учащийся". При необходимости она может быть перемещена или удалена.
            this.учащийсяTableAdapter.Fill(this.автошколаDataSet.Учащийся);
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < учащийсяDataGridView.RowCount; i++)
                {
                    учащийсяDataGridView.Rows[i].Selected = false;
                    for (int j = 0; j < учащийсяDataGridView.ColumnCount; j++)
                        if (учащийсяDataGridView.Rows[i].Cells[j].Value != null)
                            if (учащийсяDataGridView.Rows[i].Cells[j].Value.ToString().ToLower().Contains(toolStripTextBox1.Text.ToLower()))
                            {
                                учащийсяDataGridView.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                this.учащийсяTableAdapter.Fill(this.автошколаDataSet.Учащийся);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            Stream myStream;
            saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Word Document (*.doc)|*.doc|Все файлы (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        StreamWriter myWritet = new StreamWriter(myStream);
                        try
                        {
                            for (int k = 1; k < 5; k++)
                                myWritet.Write(учащийсяDataGridView.Columns[k].HeaderText + " ");
                            myWritet.WriteLine();

                            for (int i = 0; i < учащийсяDataGridView.RowCount; i++)
                            {
                                for (int j = 1; j < учащийсяDataGridView.ColumnCount; j++)
                                {
                                    myWritet.Write(учащийсяDataGridView.Rows[i].Cells[j].Value.ToString() + " ");
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
                this.учащийсяTableAdapter.Fill(this.автошколаDataSet.Учащийся);
            }
        }

        private void учащийсяDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ошибка!");
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            учащийсяTableAdapter.Fill(автошколаDataSet.Учащийся);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != ""&& textBox4.Text != "" && textBox5.Text != ""&& dateTimePicker1.Value < DateTime.Now)
                учащийсяTableAdapter.Insert(dateTimePicker1.Value,textBox3.Text,textBox4.Text,textBox5.Text);
                else
                    MessageBox.Show("Ошибка!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Validate();
            this.учащийсяBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            учащийсяTableAdapter.Fill(автошколаDataSet.Учащийся);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    id = Convert.ToInt32(учащийсяDataGridView[0, учащийсяDataGridView.CurrentRow.Index].Value.ToString());
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Select ДатаРождения,Фамилия,Имя,Отчество " +
                            "from Учащийся WHERE [Код_Учащийся] = @Код_Учащийся", con);
                        command.Parameters.AddWithValue("Код_Учащийся", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            dateTimePicker2.Text = Convert.ToString(reader[0]);//ДатаРождения
                            textBox6.Text = Convert.ToString(reader[1]);//Фамилия
                            textBox2.Text = Convert.ToString(reader[2]);//Имя
                            textBox1.Text = Convert.ToString(reader[3]);//Отчество
                        }
                    }
                    учащийсяTableAdapter.Fill(автошколаDataSet.Учащийся);
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
                if(textBox6.Text != "" && textBox2.Text != "" && textBox1.Text != "" && dateTimePicker1.Value > DateTime.Now)
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand update = new SqlCommand("Update [Учащийся] Set ДатаРождения = @ДатаРождения, Фамилия = @Фамилия," +
                        "Имя = @Имя,Отчество = @Отчество Where [Код_Учащийся] = @Код_Учащийся", con);

                    update.Parameters.AddWithValue("@Код_Учащийся", id);
                    update.Parameters.AddWithValue("@ДатаРождения", Convert.ToDateTime(dateTimePicker2.Text)); ;//ДатаРождения
                    update.Parameters.AddWithValue("@Фамилия", textBox6.Text);//Фамилия
                    update.Parameters.AddWithValue("@Имя", textBox2.Text);//Имя
                    update.Parameters.AddWithValue("@Отчество", textBox1.Text);//Отчество
                    update.ExecuteNonQuery();
                }
                else
                    MessageBox.Show("Ошибка!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            учащийсяTableAdapter.Fill(автошколаDataSet.Учащийся);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (учащийсяDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From Учащийся WHERE Код_Учащийся=@Код_Учащийся", con);
                            com.Parameters.AddWithValue("Код_Учащийся", Convert.ToInt32(учащийсяDataGridView[0, учащийсяDataGridView.CurrentRow.Index].Value.ToString()));
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
            учащийсяTableAdapter.Fill(автошколаDataSet.Учащийся);
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;
            toolStripTextBox1.ForeColor = Color.Black;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < учащийсяDataGridView.RowCount; i++)
            {
                учащийсяDataGridView.CurrentCell = null;
                учащийсяDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < учащийсяDataGridView.ColumnCount; j++)
                {
                    if (учащийсяDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (учащийсяDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            учащийсяDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < учащийсяDataGridView.RowCount; i++)
            {
                if (учащийсяDataGridView.Rows[i].Selected == false)
                    учащийсяDataGridView.Rows[i].Visible = false;
            }

            if (toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < учащийсяDataGridView.RowCount; i++)
                {
                    учащийсяDataGridView.Rows[i].Selected = false;
                    учащийсяDataGridView.Rows[i].Visible = true;
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
