using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class ТипОшибки : Form
    {
        public ТипОшибки()
        {
            InitializeComponent();
            типОшибкиDataGridView.Columns[0].Visible = false;
        }

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

        private void типОшибкиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.типОшибкиBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.автошколаDataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                this.типОшибкиTableAdapter.Fill(this.автошколаDataSet.ТипОшибки);
            }

        }

        private void ТипОшибки_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автошколаDataSet.ТипОшибки". При необходимости она может быть перемещена или удалена.
            this.типОшибкиTableAdapter.Fill(this.автошколаDataSet.ТипОшибки);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < типОшибкиDataGridView.RowCount; i++)
                {
                    типОшибкиDataGridView.Rows[i].Selected = false;
                    for (int j = 0; j < типОшибкиDataGridView.ColumnCount; j++)
                        if (типОшибкиDataGridView.Rows[i].Cells[j].Value != null)
                            if (типОшибкиDataGridView.Rows[i].Cells[j].Value.ToString().ToLower().Contains(toolStripTextBox1.Text.ToLower()))
                            {
                                типОшибкиDataGridView.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                this.типОшибкиTableAdapter.Fill(this.автошколаDataSet.ТипОшибки);
            }
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
                            myWritet.WriteLine(типОшибкиDataGridView.Columns[1].HeaderText + " ");

                            for (int i = 0; i < типОшибкиDataGridView.RowCount; i++)
                            {
                                for (int j = 1; j < типОшибкиDataGridView.ColumnCount; j++)
                                {
                                    myWritet.Write(типОшибкиDataGridView.Rows[i].Cells[j].Value.ToString() + " ");
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
                this.типОшибкиTableAdapter.Fill(this.автошколаDataSet.ТипОшибки);
            }
        }

        private void типОшибкиDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ошибка!");
        }
    }
}
