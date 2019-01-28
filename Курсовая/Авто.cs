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
    public partial class Авто : Form
    {
        public Авто()
        {
            InitializeComponent();
        }
        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory +
                @"\Автошкола.mdf;Integrated Security=True;Current Language=Russian";

        int id;

        private void Авто_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ТипТрансмисии". При необходимости она может быть перемещена или удалена.
            this.типТрансмисииTableAdapter.Fill(this.автошколаDataSet.ТипТрансмисии);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ТипТС". При необходимости она может быть перемещена или удалена.
            this.типТСTableAdapter.Fill(this.автошколаDataSet.ТипТС);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Марка". При необходимости она может быть перемещена или удалена.
            this.маркаTableAdapter.Fill(this.автошколаDataSet.Марка);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.автошколаDataSet.Авто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.автошколаDataSet.Авто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.АвтоView". При необходимости она может быть перемещена или удалена.
            this.автоViewTableAdapter.Fill(this.автошколаDataSet.АвтоView);
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value > DateTime.Now)
                {
                    MessageBox.Show("Неправильная дата");
                }
                else
                {
                    автоTableAdapter.Insert(int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()),
                        int.Parse(comboBox3.SelectedValue.ToString()), textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Validate();
            this.автоBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            автоTableAdapter.Fill(автошколаDataSet.Авто);
            автоViewTableAdapter.Fill(автошколаDataSet.АвтоView);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (автоViewDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From Авто WHERE Код_Авто=@Код_Авто", con);
                            com.Parameters.AddWithValue("Код_Авто", Convert.ToInt32(автоViewDataGridView[0, автоViewDataGridView.CurrentRow.Index].Value.ToString()));
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
            автоTableAdapter.Fill(автошколаDataSet.Авто);
            автоViewTableAdapter.Fill(автошколаDataSet.АвтоView);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            автоTableAdapter.Fill(автошколаDataSet.Авто);
            автоViewTableAdapter.Fill(автошколаDataSet.АвтоView);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value > DateTime.Now)
                {
                    MessageBox.Show("Неправильная дата");
                }
                else
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand update = new SqlCommand("Update [Авто] Set Код_Марка = @Код_Марка, Код_ТипТС = @Код_ТипТС," +
        "Код_ТипТрансмисии = @Код_ТипТрансмисии,Цвет = @Цвет,ГосНомер = @ГосНомер, Модель = @Модель, ГодВыпуска = @ГодВыпуска  Where [Код_Авто] = @Код_Авто", con);

                        update.Parameters.AddWithValue("@Код_Авто", id);
                        update.Parameters.AddWithValue("@Код_Марка", comboBox6.SelectedValue);//код марка
                        update.Parameters.AddWithValue("@Код_ТипТС", comboBox5.SelectedValue);//код типтс
                        update.Parameters.AddWithValue("@Код_ТипТрансмисии", comboBox4.SelectedValue);//код_типтрансмисии
                        update.Parameters.AddWithValue("@Цвет", textBox7.Text);//цвет
                        update.Parameters.AddWithValue("@ГосНомер", textBox6.Text);//ГосНомер
                        update.Parameters.AddWithValue("@Модель", textBox5.Text);//модель
                        update.Parameters.AddWithValue("@ГодВыпуска", Convert.ToDateTime(dateTimePicker2.Text));//год выпуска
                        update.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            автоTableAdapter.Fill(автошколаDataSet.Авто);
            автоViewTableAdapter.Fill(автошколаDataSet.АвтоView);
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;
            toolStripTextBox1.ForeColor = Color.Black;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < автоViewDataGridView.RowCount; i++)
            {
                автоViewDataGridView.CurrentCell = null;
                автоViewDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < автоViewDataGridView.ColumnCount; j++)
                {
                    if (автоViewDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (автоViewDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            автоViewDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < автоViewDataGridView.RowCount; i++)
            {
                if (автоViewDataGridView.Rows[i].Selected == false)
                    автоViewDataGridView.Rows[i].Visible = false;
            }

            if (toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < автоViewDataGridView.RowCount; i++)
                {
                    автоViewDataGridView.Rows[i].Selected = false;
                    автоViewDataGridView.Rows[i].Visible = true;
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

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    id = Convert.ToInt32(автоViewDataGridView[0, автоViewDataGridView.CurrentRow.Index].Value.ToString());
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Select Код_Марка,Код_ТипТС,Код_ТипТрансмисии,Цвет, " +
                            "ГосНомер, Модель, ГодВыпуска from Авто WHERE [Код_Авто] = @Код_Авто", con);
                        command.Parameters.AddWithValue("@Код_Авто", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox6.SelectedValue = Convert.ToString(reader[0]);//код марка
                            comboBox5.SelectedValue = Convert.ToString(reader[1]);//код типтс
                            comboBox4.SelectedValue = Convert.ToString(reader[2]);//код_типтрансмисии
                            textBox7.Text = Convert.ToString(reader[3]);//цвет
                            textBox6.Text = Convert.ToString(reader[4]);//ГосНомер
                            textBox5.Text = Convert.ToString(reader[5]);//модель
                            dateTimePicker2.Text = Convert.ToString(reader[6]);//год выпуска
                        }
                    }
                    автоTableAdapter.Fill(автошколаDataSet.Авто);
                    автоViewTableAdapter.Fill(автошколаDataSet.АвтоView);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
