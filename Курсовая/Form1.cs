using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                Help.ShowHelp(this, "Spravka.chm");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.Результат". При необходимости она может быть перемещена или удалена.
        }

        private void должностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Должность dolz = new Должность();
            dolz.Show();
        }

        private void званиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Звание zavan = new Звание();
            zavan.Show();
        }

        private void подразделениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Подразделение podraz = new Подразделение();
            podraz.Show();
        }

        private void экзаменаторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Экзаменатор ekzamenator = new Экзаменатор();
            ekzamenator.Show();
        }

        private void маршрутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Маршрут marshrut = new Маршрут();
            marshrut.Show();
        }

        private void учащийсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Учащийся ych = new Учащийся();
            ych.Show();
        }

        private void типОшибкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ТипОшибки typemistake = new ТипОшибки();
            typemistake.Show();
        }

        private void ошибкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ошибка mistake = new Ошибка();
            mistake.Show();
        }

        private void маркаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Марка marka = new Марка();
            marka.Show();
        }

        private void типТСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ТипТС typeTC = new ТипТС();
            typeTC.Show();
        }

        private void типТрансмисииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ТипТрансмисии typeTrans = new ТипТрансмисии();
            typeTrans.Show();
        }

        private void автоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Авто car = new Авто();
            car.Show();
        }

        private void экзаменToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Экзамен ekzamen = new Экзамен();
            ekzamen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
                Help.ShowHelp(this, "Spravka.chm");

        }

        private void результатЭкзаменаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void результатЭкзаменаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Результат res = new Результат();
            res.Show();
        }
    }
}
