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
    public partial class Экзамен : Form
    {
        public Экзамен()
        {
            InitializeComponent();
        }

        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory +
                @"\Автошкола.mdf;Integrated Security=True;Current Language=Russian";

        int id;

        private void Экзамен_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.автошколаDataSet.Авто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Ошибка". При необходимости она может быть перемещена или удалена.
            this.ошибкаTableAdapter.Fill(this.автошколаDataSet.Ошибка);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Учащийся". При необходимости она может быть перемещена или удалена.
            this.учащийсяTableAdapter.Fill(this.автошколаDataSet.Учащийся);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Маршрут". При необходимости она может быть перемещена или удалена.
            this.маршрутTableAdapter.Fill(this.автошколаDataSet.Маршрут);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Экзаменатор". При необходимости она может быть перемещена или удалена.
            this.экзаменаторTableAdapter.Fill(this.автошколаDataSet.Экзаменатор);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Экзамен". При необходимости она может быть перемещена или удалена.
            this.экзаменTableAdapter.Fill(this.автошколаDataSet.Экзамен);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ЭкзаменView". При необходимости она может быть перемещена или удалена.
            this.экзаменViewTableAdapter.Fill(this.автошколаDataSet.ЭкзаменView);
            toolStripTextBox1.Text = "Поиск";
            toolStripTextBox1.ForeColor = Color.Gray;
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
                    экзаменTableAdapter.Insert(int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()),
                        int.Parse(comboBox3.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), int.Parse(comboBox5.SelectedValue.ToString())
                        , comboBox7.SelectedValue.ToString(), dateTimePicker1.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            экзаменTableAdapter.Fill(автошколаDataSet.Экзамен);
            экзаменViewTableAdapter.Fill(автошколаDataSet.ЭкзаменView);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            экзаменTableAdapter.Fill(автошколаDataSet.Экзамен);
            экзаменViewTableAdapter.Fill(автошколаDataSet.ЭкзаменView);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (экзаменViewDataGridView.SelectedCells.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Вы действительно хотите удалить ", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (res)
                    {
                        case DialogResult.OK:

                            SqlCommand com = new SqlCommand("DELETE From Экзамен WHERE Код_Экзамен=@Код_Экзамен", con);
                            com.Parameters.AddWithValue("Код_Экзамен", Convert.ToInt32(экзаменViewDataGridView[0, экзаменViewDataGridView.CurrentRow.Index].Value.ToString()));
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
            экзаменTableAdapter.Fill(автошколаDataSet.Экзамен);
            экзаменViewTableAdapter.Fill(автошколаDataSet.ЭкзаменView);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поискToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

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
                    SqlCommand update = new SqlCommand("Update [Экзамен] Set Код_Экзаменатор = @Код_Экзаменатор, Код_Маршрут = @Код_Маршрут," +
    "Код_Учащийся = @Код_Учащийся,Код_Ошибка = @Код_Ошибка,Код_Авто = @Код_Авто, Тип = @Тип, ДатаПроведения = @ДатаПроведения  Where [Код_Экзамен] = @Код_Экзамен", con);

                    update.Parameters.AddWithValue("@Код_Экзамен", id);
                    update.Parameters.AddWithValue("@Код_Экзаменатор", comboBox12.SelectedValue);//экзаменатор
                    update.Parameters.AddWithValue("@Код_Маршрут", comboBox11.SelectedValue);//маршрут
                    update.Parameters.AddWithValue("@Код_Учащийся", comboBox10.SelectedValue);//Фамилия
                    update.Parameters.AddWithValue("@Код_Ошибка", comboBox9.SelectedValue);//ошибка
                    update.Parameters.AddWithValue("@Код_Авто", comboBox8.SelectedValue);//авто
                    update.Parameters.AddWithValue("@Тип", comboBox6.SelectedValue);//тип
                    update.Parameters.AddWithValue("@ДатаПроведения", Convert.ToDateTime(dateTimePicker2.Text));//дата проведения
                    update.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            экзаменTableAdapter.Fill(автошколаDataSet.Экзамен);
            экзаменViewTableAdapter.Fill(автошколаDataSet.ЭкзаменView);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    id = Convert.ToInt32(экзаменViewDataGridView[0, экзаменViewDataGridView.CurrentRow.Index].Value.ToString());
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Select Код_Экзаменатор,Код_Маршрут,Код_Учащийся,Код_Ошибка, " +
                            "Код_Авто, Тип, ДатаПроведения from Экзамен WHERE [Код_Экзамен] = @Код_Экзамен", con);
                        command.Parameters.AddWithValue("Код_Экзамен", id);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox12.SelectedValue = Convert.ToString(reader[0]);//экзаменатор
                            comboBox11.SelectedValue = Convert.ToString(reader[1]);//маршрут
                            comboBox10.SelectedValue = Convert.ToString(reader[2]);//Фамилия
                            comboBox9.SelectedValue = Convert.ToString(reader[3]);//ошибка
                            comboBox8.SelectedValue = Convert.ToString(reader[4]);//авто
                            comboBox6.SelectedValue = Convert.ToString(reader[5]);//тип
                            dateTimePicker2.Text = Convert.ToString(reader[6]);//дата проведения
                        }
                    }
                    экзаменTableAdapter.Fill(автошколаDataSet.Экзамен);
                    экзаменViewTableAdapter.Fill(автошколаDataSet.ЭкзаменView);
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

        private void toolStripTextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < экзаменViewDataGridView.RowCount; i++)
            {
                экзаменViewDataGridView.CurrentCell = null;
                экзаменViewDataGridView.Rows[i].Selected = false;

                for (int j = 0; j < экзаменViewDataGridView.ColumnCount; j++)
                {
                    if (экзаменViewDataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (экзаменViewDataGridView.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text.ToString()))
                        {
                            экзаменViewDataGridView.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < экзаменViewDataGridView.RowCount; i++)
            {
                if (экзаменViewDataGridView.Rows[i].Selected == false)
                    экзаменViewDataGridView.Rows[i].Visible = false;
            }

            if(toolStripTextBox1.Text == "")
            {
                for (int i = 0; i < экзаменViewDataGridView.RowCount; i++)
                {
                    экзаменViewDataGridView.Rows[i].Selected = false;
                    экзаменViewDataGridView.Rows[i].Visible = true;
                }
            }
        }
    }
}
