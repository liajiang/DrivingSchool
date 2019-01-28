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
    public partial class Экзаменатор : Form
    {
        public Экзаменатор()
        {
            InitializeComponent();
        }
        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory +
                @"\Автошкола.mdf;Integrated Security=True;Current Language=Russian";

        int id;

        private void Экзаменатор_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Экзаменатор". При необходимости она может быть перемещена или удалена.
            this.экзаменаторTableAdapter.Fill(this.автошколаDataSet.Экзаменатор);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Подразделение". При необходимости она может быть перемещена или удалена.
            this.подразделениеTableAdapter.Fill(this.автошколаDataSet.Подразделение);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Звание". При необходимости она может быть перемещена или удалена.
            this.званиеTableAdapter.Fill(this.автошколаDataSet.Звание);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Должность". При необходимости она может быть перемещена или удалена.
            this.должностьTableAdapter.Fill(this.автошколаDataSet.Должность);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ЭкзаменаторView". При необходимости она может быть перемещена или удалена.
            this.экзаменаторViewTableAdapter.Fill(this.автошколаDataSet.ЭкзаменаторView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ЭкзаменаторView". При необходимости она может быть перемещена или удалена.
            this.экзаменаторViewTableAdapter.Fill(this.автошколаDataSet.ЭкзаменаторView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ЭкзаменView". При необходимости она может быть перемещена или удалена.
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;
        }

        private void экзаменViewBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                    экзаменаторTableAdapter.Insert(int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox3.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()), textBox1.Text, textBox2.Text, textBox3.Text);
                else
                    MessageBox.Show("Заполните все поля!","Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Validate();
            this.экзаменаторBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            экзаменаторTableAdapter.Fill(автошколаDataSet.Экзаменатор);
            экзаменаторViewTableAdapter.Fill(автошколаDataSet.ЭкзаменаторView);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            экзаменаторTableAdapter.Fill(автошколаDataSet.Экзаменатор);
            экзаменаторViewTableAdapter.Fill(автошколаDataSet.ЭкзаменаторView);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            экзаменаторTableAdapter.Update(автошколаDataSet);

            экзаменаторTableAdapter.Fill(автошколаDataSet.Экзаменатор);
            экзаменаторViewTableAdapter.Fill(автошколаDataSet.ЭкзаменаторView);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (экзаменаторViewDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From Экзаменатор WHERE Код_Экзаменатор=@Код_Экзаменатор", con);
                            com.Parameters.AddWithValue("Код_Экзаменатор", Convert.ToInt32(экзаменаторViewDataGridView[0, экзаменаторViewDataGridView.CurrentRow.Index].Value.ToString()));
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
            экзаменаторTableAdapter.Fill(автошколаDataSet.Экзаменатор);
            экзаменаторViewTableAdapter.Fill(автошколаDataSet.ЭкзаменаторView);
        }

        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    id = Convert.ToInt32(экзаменаторViewDataGridView[0, экзаменаторViewDataGridView.CurrentRow.Index].Value.ToString());
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Select Код_Должность,Код_Подразделение, Код_Звание, Фамилия, " +
                            "Имя, Отчество from Экзаменатор WHERE [Код_Экзаменатор] = @Код_Экзаменатор", con);
                        command.Parameters.AddWithValue("Код_Экзаменатор", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox6.SelectedValue = Convert.ToString(reader[0]);//Должность
                            comboBox4.SelectedValue = Convert.ToString(reader[1]);//Подразделение
                            comboBox5.SelectedValue = Convert.ToString(reader[2]);//Звание
                            textBox6.Text = Convert.ToString(reader[3]);//Фамилия
                            textBox5.Text = Convert.ToString(reader[4]);//Имя
                            textBox4.Text = Convert.ToString(reader[5]);//Отчество
                        }
                    }
                    экзаменаторTableAdapter.Fill(автошколаDataSet.Экзаменатор);
                    экзаменаторViewTableAdapter.Fill(автошколаDataSet.ЭкзаменаторView);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text != "" && textBox5.Text != "" && textBox4.Text != "")
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand update = new SqlCommand("Update [Экзаменатор] Set Код_Должность = @Код_Должность, Код_Подразделение = @Код_Подразделение," +
    "Код_Звание = @Код_Звание,Фамилия = @Фамилия,Имя = @Имя, Отчество = @Отчество  Where [Код_Экзаменатор] = @Код_Экзаменатор", con);

                    update.Parameters.AddWithValue("@Код_Экзаменатор", id);
                    update.Parameters.AddWithValue("@Код_Должность", comboBox6.SelectedValue);//Должность
                    update.Parameters.AddWithValue("@Код_Подразделение", comboBox4.SelectedValue);//Подразделение
                    update.Parameters.AddWithValue("@Код_Звание", comboBox5.SelectedValue);//Звание
                    update.Parameters.AddWithValue("@Фамилия", textBox6.Text);//Фамилия
                    update.Parameters.AddWithValue("@Имя", textBox5.Text);//Имя
                    update.Parameters.AddWithValue("@Отчество", textBox4.Text);//Отчество
                    update.ExecuteNonQuery();
                }
                else
                    MessageBox.Show("Заполните все поля!","Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            экзаменаторTableAdapter.Fill(автошколаDataSet.Экзаменатор);
            экзаменаторViewTableAdapter.Fill(автошколаDataSet.ЭкзаменаторView);
        }

        private void обновитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            экзаменаторTableAdapter.Fill(автошколаDataSet.Экзаменатор);
            экзаменаторViewTableAdapter.Fill(автошколаDataSet.ЭкзаменаторView);
        }

        private void удалитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (экзаменаторViewDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From Экзаменатор WHERE Код_Экзаменатор=@Код_Экзаменатор", con);
                            com.Parameters.AddWithValue("Код_Экзаменатор", Convert.ToInt32(экзаменаторViewDataGridView[0, экзаменаторViewDataGridView.CurrentRow.Index].Value.ToString()));
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
            экзаменаторTableAdapter.Fill(автошколаDataSet.Экзаменатор);
            экзаменаторViewTableAdapter.Fill(автошколаDataSet.ЭкзаменаторView);
        }

        private void toolStripTextBox1_Enter_1(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;
            toolStripTextBox1.ForeColor = Color.Black;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < экзаменаторViewDataGridView.RowCount; i++)
            {
                экзаменаторViewDataGridView.CurrentCell = null;
                экзаменаторViewDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < экзаменаторViewDataGridView.ColumnCount; j++)
                {
                    if (экзаменаторViewDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (экзаменаторViewDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            экзаменаторViewDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < экзаменаторViewDataGridView.RowCount; i++)
            {
                if (экзаменаторViewDataGridView.Rows[i].Selected == false)
                    экзаменаторViewDataGridView.Rows[i].Visible = false;
            }

            if (toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < экзаменаторViewDataGridView.RowCount; i++)
                {
                    экзаменаторViewDataGridView.Rows[i].Selected = false;
                    экзаменаторViewDataGridView.Rows[i].Visible = true;
                }
            }
        }

        private void toolStripTextBox1_Leave_1(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                toolStripTextBox1.Text = "Поиск";
                toolStripTextBox1.ForeColor = Color.Gray;
            }
        }
    }
}
