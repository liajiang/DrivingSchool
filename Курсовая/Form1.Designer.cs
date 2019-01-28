namespace Курсовая
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.автошколаDataSet = new Курсовая.АвтошколаDataSet();
            this.tableAdapterManager = new Курсовая.АвтошколаDataSetTableAdapters.TableAdapterManager();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.должностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подразделениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.званиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экзаменаторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учащийсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ошибкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маркаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типТСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типТрансмисииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экзаменToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.автошколаDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // автошколаDataSet
            // 
            this.автошколаDataSet.DataSetName = "АвтошколаDataSet";
            this.автошколаDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = Курсовая.АвтошколаDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.АвтоTableAdapter = null;
            this.tableAdapterManager.ДолжностьTableAdapter = null;
            this.tableAdapterManager.ЗваниеTableAdapter = null;
            this.tableAdapterManager.МаркаTableAdapter = null;
            this.tableAdapterManager.МаршрутTableAdapter = null;
            this.tableAdapterManager.ОшибкаTableAdapter = null;
            this.tableAdapterManager.ПодразделениеTableAdapter = null;
            this.tableAdapterManager.ТипОшибкиTableAdapter = null;
            this.tableAdapterManager.ТипТрансмисииTableAdapter = null;
            this.tableAdapterManager.ТипТСTableAdapter = null;
            this.tableAdapterManager.УчащийсяTableAdapter = null;
            this.tableAdapterManager.ЭкзаменTableAdapter = null;
            this.tableAdapterManager.ЭкзаменаторTableAdapter = null;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(389, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.должностьToolStripMenuItem,
            this.подразделениеToolStripMenuItem,
            this.званиеToolStripMenuItem,
            this.экзаменаторToolStripMenuItem,
            this.маршрутToolStripMenuItem,
            this.учащийсяToolStripMenuItem,
            this.ошибкаToolStripMenuItem,
            this.маркаToolStripMenuItem,
            this.типТСToolStripMenuItem,
            this.типТрансмисииToolStripMenuItem,
            this.автоToolStripMenuItem,
            this.экзаменToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // должностьToolStripMenuItem
            // 
            this.должностьToolStripMenuItem.Name = "должностьToolStripMenuItem";
            this.должностьToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.должностьToolStripMenuItem.Text = "Должность";
            this.должностьToolStripMenuItem.Click += new System.EventHandler(this.должностьToolStripMenuItem_Click);
            // 
            // подразделениеToolStripMenuItem
            // 
            this.подразделениеToolStripMenuItem.Name = "подразделениеToolStripMenuItem";
            this.подразделениеToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.подразделениеToolStripMenuItem.Text = "Подразделение";
            this.подразделениеToolStripMenuItem.Click += new System.EventHandler(this.подразделениеToolStripMenuItem_Click);
            // 
            // званиеToolStripMenuItem
            // 
            this.званиеToolStripMenuItem.Name = "званиеToolStripMenuItem";
            this.званиеToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.званиеToolStripMenuItem.Text = "Звание";
            this.званиеToolStripMenuItem.Click += new System.EventHandler(this.званиеToolStripMenuItem_Click);
            // 
            // экзаменаторToolStripMenuItem
            // 
            this.экзаменаторToolStripMenuItem.Name = "экзаменаторToolStripMenuItem";
            this.экзаменаторToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.экзаменаторToolStripMenuItem.Text = "Экзаменатор";
            this.экзаменаторToolStripMenuItem.Click += new System.EventHandler(this.экзаменаторToolStripMenuItem_Click);
            // 
            // маршрутToolStripMenuItem
            // 
            this.маршрутToolStripMenuItem.Name = "маршрутToolStripMenuItem";
            this.маршрутToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.маршрутToolStripMenuItem.Text = "Маршрут";
            this.маршрутToolStripMenuItem.Click += new System.EventHandler(this.маршрутToolStripMenuItem_Click);
            // 
            // учащийсяToolStripMenuItem
            // 
            this.учащийсяToolStripMenuItem.Name = "учащийсяToolStripMenuItem";
            this.учащийсяToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.учащийсяToolStripMenuItem.Text = "Учащийся";
            this.учащийсяToolStripMenuItem.Click += new System.EventHandler(this.учащийсяToolStripMenuItem_Click);
            // 
            // ошибкаToolStripMenuItem
            // 
            this.ошибкаToolStripMenuItem.Name = "ошибкаToolStripMenuItem";
            this.ошибкаToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ошибкаToolStripMenuItem.Text = "Ошибка";
            this.ошибкаToolStripMenuItem.Click += new System.EventHandler(this.ошибкаToolStripMenuItem_Click);
            // 
            // маркаToolStripMenuItem
            // 
            this.маркаToolStripMenuItem.Name = "маркаToolStripMenuItem";
            this.маркаToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.маркаToolStripMenuItem.Text = "Марка";
            this.маркаToolStripMenuItem.Click += new System.EventHandler(this.маркаToolStripMenuItem_Click);
            // 
            // типТСToolStripMenuItem
            // 
            this.типТСToolStripMenuItem.Name = "типТСToolStripMenuItem";
            this.типТСToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.типТСToolStripMenuItem.Text = "ТипТС";
            this.типТСToolStripMenuItem.Click += new System.EventHandler(this.типТСToolStripMenuItem_Click);
            // 
            // типТрансмисииToolStripMenuItem
            // 
            this.типТрансмисииToolStripMenuItem.Name = "типТрансмисииToolStripMenuItem";
            this.типТрансмисииToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.типТрансмисииToolStripMenuItem.Text = "ТипТрансмисии";
            this.типТрансмисииToolStripMenuItem.Click += new System.EventHandler(this.типТрансмисииToolStripMenuItem_Click);
            // 
            // автоToolStripMenuItem
            // 
            this.автоToolStripMenuItem.Name = "автоToolStripMenuItem";
            this.автоToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.автоToolStripMenuItem.Text = "Авто";
            this.автоToolStripMenuItem.Click += new System.EventHandler(this.автоToolStripMenuItem_Click);
            // 
            // экзаменToolStripMenuItem
            // 
            this.экзаменToolStripMenuItem.Name = "экзаменToolStripMenuItem";
            this.экзаменToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.экзаменToolStripMenuItem.Text = "Экзамен";
            this.экзаменToolStripMenuItem.Click += new System.EventHandler(this.экзаменToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 98);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(112, 179);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 98);
            this.button3.TabIndex = 3;
            this.button3.Text = "Справка";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 98);
            this.button2.TabIndex = 4;
            this.button2.Text = "Результат";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(389, 422);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.автошколаDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private АвтошколаDataSet автошколаDataSet;
        private АвтошколаDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem должностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подразделениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem званиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экзаменаторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маршрутToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учащийсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ошибкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маркаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типТСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типТрансмисииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem автоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экзаменToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}

