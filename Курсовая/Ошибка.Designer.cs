namespace Курсовая
{
    partial class Ошибка
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label фамилияLabel;
            System.Windows.Forms.Label имяLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ошибкаViewDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ошибкаViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.автошколаDataSet = new Курсовая.АвтошколаDataSet();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.типОшибкиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.ошибкаViewTableAdapter = new Курсовая.АвтошколаDataSetTableAdapters.ОшибкаViewTableAdapter();
            this.tableAdapterManager = new Курсовая.АвтошколаDataSetTableAdapters.TableAdapterManager();
            this.ошибкаTableAdapter = new Курсовая.АвтошколаDataSetTableAdapters.ОшибкаTableAdapter();
            this.типОшибкиTableAdapter = new Курсовая.АвтошколаDataSetTableAdapters.ТипОшибкиTableAdapter();
            this.ошибкаBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            фамилияLabel = new System.Windows.Forms.Label();
            имяLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ошибкаViewDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ошибкаViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.автошколаDataSet)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.типОшибкиBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ошибкаBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // фамилияLabel
            // 
            фамилияLabel.AutoSize = true;
            фамилияLabel.Location = new System.Drawing.Point(249, 113);
            фамилияLabel.Name = "фамилияLabel";
            фамилияLabel.Size = new System.Drawing.Size(130, 17);
            фамилияLabel.TabIndex = 42;
            фамилияLabel.Text = "Название ошибки:";
            // 
            // имяLabel
            // 
            имяLabel.AutoSize = true;
            имяLabel.Location = new System.Drawing.Point(249, 141);
            имяLabel.Name = "имяLabel";
            имяLabel.Size = new System.Drawing.Size(170, 17);
            имяLabel.TabIndex = 43;
            имяLabel.Text = "Название Типа Ошибки:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(233, 102);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(130, 17);
            label1.TabIndex = 51;
            label1.Text = "Название ошибки:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(233, 130);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(170, 17);
            label2.TabIndex = 52;
            label2.Text = "Название Типа Ошибки:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.обновитьToolStripMenuItem,
            this.toolStripTextBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1273, 31);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(77, 27);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1249, 578);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ошибкаViewDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1241, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ошибка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ошибкаViewDataGridView
            // 
            this.ошибкаViewDataGridView.AllowUserToAddRows = false;
            this.ошибкаViewDataGridView.AllowUserToDeleteRows = false;
            this.ошибкаViewDataGridView.AutoGenerateColumns = false;
            this.ошибкаViewDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ошибкаViewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ошибкаViewDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.ошибкаViewDataGridView.DataSource = this.ошибкаViewBindingSource;
            this.ошибкаViewDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ошибкаViewDataGridView.Name = "ошибкаViewDataGridView";
            this.ошибкаViewDataGridView.ReadOnly = true;
            this.ошибкаViewDataGridView.RowTemplate.Height = 24;
            this.ошибкаViewDataGridView.Size = new System.Drawing.Size(1241, 558);
            this.ошибкаViewDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Код_Ошибка";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код_Ошибка";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Название ошибки";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название ошибки";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Название Типа Ошибки";
            this.dataGridViewTextBoxColumn3.HeaderText = "Название Типа Ошибки";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // ошибкаViewBindingSource
            // 
            this.ошибкаViewBindingSource.DataMember = "ОшибкаView";
            this.ошибкаViewBindingSource.DataSource = this.автошколаDataSet;
            // 
            // автошколаDataSet
            // 
            this.автошколаDataSet.DataSetName = "АвтошколаDataSet";
            this.автошколаDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(фамилияLabel);
            this.tabPage2.Controls.Add(имяLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1241, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Добавить";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.типОшибкиBindingSource;
            this.comboBox1.DisplayMember = "НазваниеТипаОшибки";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(436, 141);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(588, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "Код_ТипОшибки";
            // 
            // типОшибкиBindingSource
            // 
            this.типОшибкиBindingSource.DataMember = "ТипОшибки";
            this.типОшибкиBindingSource.DataSource = this.автошколаDataSet;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(436, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(588, 22);
            this.textBox1.TabIndex = 45;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(524, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 81);
            this.button1.TabIndex = 14;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBox2);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(label1);
            this.tabPage3.Controls.Add(label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1241, 549);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Изменить";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.типОшибкиBindingSource;
            this.comboBox2.DisplayMember = "НазваниеТипаОшибки";
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Location = new System.Drawing.Point(420, 130);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(588, 24);
            this.comboBox2.TabIndex = 49;
            this.comboBox2.ValueMember = "Код_ТипОшибки";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(420, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(588, 22);
            this.textBox2.TabIndex = 53;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(508, 366);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(227, 81);
            this.button3.TabIndex = 50;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ошибкаViewTableAdapter
            // 
            this.ошибкаViewTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Курсовая.АвтошколаDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.АвтоTableAdapter = null;
            this.tableAdapterManager.ДолжностьTableAdapter = null;
            this.tableAdapterManager.ЗваниеTableAdapter = null;
            this.tableAdapterManager.МаркаTableAdapter = null;
            this.tableAdapterManager.МаршрутTableAdapter = null;
            this.tableAdapterManager.ОшибкаTableAdapter = this.ошибкаTableAdapter;
            this.tableAdapterManager.ПодразделениеTableAdapter = null;
            this.tableAdapterManager.ТипОшибкиTableAdapter = this.типОшибкиTableAdapter;
            this.tableAdapterManager.ТипТрансмисииTableAdapter = null;
            this.tableAdapterManager.ТипТСTableAdapter = null;
            this.tableAdapterManager.УчащийсяTableAdapter = null;
            this.tableAdapterManager.ЭкзаменTableAdapter = null;
            this.tableAdapterManager.ЭкзаменаторTableAdapter = null;
            // 
            // ошибкаTableAdapter
            // 
            this.ошибкаTableAdapter.ClearBeforeFill = true;
            // 
            // типОшибкиTableAdapter
            // 
            this.типОшибкиTableAdapter.ClearBeforeFill = true;
            // 
            // ошибкаBindingSource
            // 
            this.ошибкаBindingSource.DataMember = "Ошибка";
            this.ошибкаBindingSource.DataSource = this.автошколаDataSet;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(200, 27);
            this.toolStripTextBox1.Enter += new System.EventHandler(this.toolStripTextBox1_Enter);
            this.toolStripTextBox1.Leave += new System.EventHandler(this.toolStripTextBox1_Leave);
            this.toolStripTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            // 
            // Ошибка
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 634);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "Ошибка";
            this.Text = "Ошибка";
            this.Load += new System.EventHandler(this.Ошибка_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ошибкаViewDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ошибкаViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.автошколаDataSet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.типОшибкиBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ошибкаBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private АвтошколаDataSet автошколаDataSet;
        private System.Windows.Forms.BindingSource ошибкаViewBindingSource;
        private АвтошколаDataSetTableAdapters.ОшибкаViewTableAdapter ошибкаViewTableAdapter;
        private АвтошколаDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private АвтошколаDataSetTableAdapters.ОшибкаTableAdapter ошибкаTableAdapter;
        private System.Windows.Forms.BindingSource ошибкаBindingSource;
        private АвтошколаDataSetTableAdapters.ТипОшибкиTableAdapter типОшибкиTableAdapter;
        private System.Windows.Forms.BindingSource типОшибкиBindingSource;
        private System.Windows.Forms.DataGridView ошибкаViewDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}