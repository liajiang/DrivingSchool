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
    public partial class Подразделение : Form
    {
        public Подразделение()
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

        private void подразделениеBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void Подразделение_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Подразделение". При необходимости она может быть перемещена или удалена.
            this.подразделениеTableAdapter.Fill(this.автошколаDataSet.Подразделение);
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void подразделениеDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text!="")
                подразделениеTableAdapter.Insert(textBox1.Text);
                else
                    MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Validate();
            this.подразделениеBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            подразделениеTableAdapter.Fill(автошколаDataSet.Подразделение);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2.Text!="")
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand update = new SqlCommand("Update [Подразделение] Set Название = @Название Where [Код_Подразделение] = @Код_Подразделение", con);

                    update.Parameters.AddWithValue("@Код_Подразделение", id);
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
            подразделениеTableAdapter.Fill(автошколаDataSet.Подразделение);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (подразделениеDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From Подразделение WHERE Код_Подразделение=@Код_Подразделение", con);
                            com.Parameters.AddWithValue("Код_Подразделение", Convert.ToInt32(подразделениеDataGridView[0, подразделениеDataGridView.CurrentRow.Index].Value.ToString()));
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
            подразделениеTableAdapter.Fill(автошколаDataSet.Подразделение);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            подразделениеTableAdapter.Fill(автошколаDataSet.Подразделение);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    id = Convert.ToInt32(подразделениеDataGridView[0, подразделениеDataGridView.CurrentRow.Index].Value.ToString());
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Select Название from Подразделение WHERE [Код_Подразделение] = @Код_Подразделение", con);
                        command.Parameters.AddWithValue("Код_Подразделение", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            textBox2.Text = Convert.ToString(reader[0]);//подразделение название
                        }
                    }
                    подразделениеTableAdapter.Fill(автошколаDataSet.Подразделение);
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

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                toolStripTextBox1.Text = "Поиск";
                toolStripTextBox1.ForeColor = Color.Gray;
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < подразделениеDataGridView.RowCount; i++)
            {
                подразделениеDataGridView.CurrentCell = null;
                подразделениеDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < подразделениеDataGridView.ColumnCount; j++)
                {
                    if (подразделениеDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (подразделениеDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            подразделениеDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < подразделениеDataGridView.RowCount; i++)
            {
                if (подразделениеDataGridView.Rows[i].Selected == false)
                    подразделениеDataGridView.Rows[i].Visible = false;
            }

            if (toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < подразделениеDataGridView.RowCount; i++)
                {
                    подразделениеDataGridView.Rows[i].Selected = false;
                    подразделениеDataGridView.Rows[i].Visible = true;
                }
            }
        }
    }
}
