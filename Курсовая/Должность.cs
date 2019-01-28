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
    public partial class Должность : Form
    {
        public Должность()
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

        private void должностьBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.должностьBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                this.должностьTableAdapter.Fill(this.автошколаDataSet.Должность);
            }

        }

        private void Должность_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Должность". При необходимости она может быть перемещена или удалена.
            this.должностьTableAdapter.Fill(this.автошколаDataSet.Должность);
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void должностьDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ошибка!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text!="")
                должностьTableAdapter.Insert(textBox1.Text);
                else
                    MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Validate();
            this.должностьBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            должностьTableAdapter.Fill(автошколаDataSet.Должность);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            должностьTableAdapter.Fill(автошколаDataSet.Должность);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2.Text!="")
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand update = new SqlCommand("Update [Должность] Set Название = @Название Where [Код_Должность] = @Код_Должность", con);

                    update.Parameters.AddWithValue("@Код_Должность", id);
                    update.Parameters.AddWithValue("@Название", textBox2.Text);
                    update.ExecuteNonQuery();
                }
                else
                    MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            должностьTableAdapter.Fill(автошколаDataSet.Должность);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    id = Convert.ToInt32(должностьDataGridView[0, должностьDataGridView.CurrentRow.Index].Value.ToString());
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Select Должность.Название from Должность WHERE [Код_Должность] = @Код_Должность", con);
                        command.Parameters.AddWithValue("Код_Должность", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            textBox2.Text = Convert.ToString(reader[0]);//должность название
                        }
                    }
                    должностьTableAdapter.Fill(автошколаDataSet.Должность);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (должностьDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From Должность WHERE Код_Должность=@Код_Должность", con);
                            com.Parameters.AddWithValue("Код_Должность", Convert.ToInt32(должностьDataGridView[0, должностьDataGridView.CurrentRow.Index].Value.ToString()));
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
            должностьTableAdapter.Fill(автошколаDataSet.Должность);
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;
            toolStripTextBox1.ForeColor = Color.Black;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < должностьDataGridView.RowCount; i++)
            {
                должностьDataGridView.CurrentCell = null;
                должностьDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < должностьDataGridView.ColumnCount; j++)
                {
                    if (должностьDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (должностьDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            должностьDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < должностьDataGridView.RowCount; i++)
            {
                if (должностьDataGridView.Rows[i].Selected == false)
                    должностьDataGridView.Rows[i].Visible = false;
            }

            if (toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < должностьDataGridView.RowCount; i++)
                {
                    должностьDataGridView.Rows[i].Selected = false;
                    должностьDataGridView.Rows[i].Visible = true;
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
