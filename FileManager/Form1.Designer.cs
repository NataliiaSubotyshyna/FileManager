namespace FileManager
{
    partial class Form1
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
            this.cb_Disks = new System.Windows.Forms.ComboBox();
            this.lbl_FreeMemory = new System.Windows.Forms.Label();
            this.lbl_freeMemoryDisk2 = new System.Windows.Forms.Label();
            this.cb_Disk2 = new System.Windows.Forms.ComboBox();
            this.lv_leftPartFiles = new System.Windows.Forms.ListView();
            this.ch_NameFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tb_leftPartPath = new System.Windows.Forms.TextBox();
            this.tb_rightPartPath = new System.Windows.Forms.TextBox();
            this.lv_rightPartFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_Disks
            // 
            this.cb_Disks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Disks.FormattingEnabled = true;
            this.cb_Disks.ItemHeight = 13;
            this.cb_Disks.Location = new System.Drawing.Point(12, 32);
            this.cb_Disks.MaximumSize = new System.Drawing.Size(100, 0);
            this.cb_Disks.Name = "cb_Disks";
            this.cb_Disks.Size = new System.Drawing.Size(51, 21);
            this.cb_Disks.TabIndex = 0;
            this.cb_Disks.SelectedIndexChanged += new System.EventHandler(this.cb_Disks_SelectedIndexChanged);
            // 
            // lbl_FreeMemory
            // 
            this.lbl_FreeMemory.AutoSize = true;
            this.lbl_FreeMemory.Location = new System.Drawing.Point(79, 32);
            this.lbl_FreeMemory.Name = "lbl_FreeMemory";
            this.lbl_FreeMemory.Size = new System.Drawing.Size(35, 13);
            this.lbl_FreeMemory.TabIndex = 2;
            this.lbl_FreeMemory.Text = "label1";
            this.lbl_FreeMemory.Click += new System.EventHandler(this.lbl_FreeMemory_Click);
            // 
            // lbl_freeMemoryDisk2
            // 
            this.lbl_freeMemoryDisk2.AutoSize = true;
            this.lbl_freeMemoryDisk2.Location = new System.Drawing.Point(658, 32);
            this.lbl_freeMemoryDisk2.Name = "lbl_freeMemoryDisk2";
            this.lbl_freeMemoryDisk2.Size = new System.Drawing.Size(35, 13);
            this.lbl_freeMemoryDisk2.TabIndex = 2;
            this.lbl_freeMemoryDisk2.Text = "label1";
            // 
            // cb_Disk2
            // 
            this.cb_Disk2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Disk2.FormattingEnabled = true;
            this.cb_Disk2.ItemHeight = 13;
            this.cb_Disk2.Location = new System.Drawing.Point(599, 32);
            this.cb_Disk2.MaximumSize = new System.Drawing.Size(100, 0);
            this.cb_Disk2.Name = "cb_Disk2";
            this.cb_Disk2.Size = new System.Drawing.Size(51, 21);
            this.cb_Disk2.TabIndex = 0;
            this.cb_Disk2.SelectedIndexChanged += new System.EventHandler(this.cb_Disk2_SelectedIndexChanged);
            // 
            // lv_leftPartFiles
            // 
            this.lv_leftPartFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_NameFile,
            this.ch_type,
            this.ch_Size,
            this.ch_Date});
            this.lv_leftPartFiles.FullRowSelect = true;
            this.lv_leftPartFiles.GridLines = true;
            this.lv_leftPartFiles.Location = new System.Drawing.Point(12, 72);
            this.lv_leftPartFiles.Name = "lv_leftPartFiles";
            this.lv_leftPartFiles.Size = new System.Drawing.Size(581, 254);
            this.lv_leftPartFiles.TabIndex = 5;
            this.lv_leftPartFiles.UseCompatibleStateImageBehavior = false;
            this.lv_leftPartFiles.View = System.Windows.Forms.View.Details;
            this.lv_leftPartFiles.SelectedIndexChanged += new System.EventHandler(this.lv_leftPartFiles_SelectedIndexChanged);
            this.lv_leftPartFiles.DoubleClick += new System.EventHandler(this.lv_leftPartFiles_DoubleClick);
            // 
            // ch_NameFile
            // 
            this.ch_NameFile.Text = "Имя";
            this.ch_NameFile.Width = 220;
            // 
            // ch_type
            // 
            this.ch_type.Text = "Тип";
            this.ch_type.Width = 75;
            // 
            // ch_Size
            // 
            this.ch_Size.Text = "Размер";
            this.ch_Size.Width = 80;
            // 
            // ch_Date
            // 
            this.ch_Date.Text = "Дата";
            this.ch_Date.Width = 111;
            // 
            // tb_leftPartPath
            // 
            this.tb_leftPartPath.Location = new System.Drawing.Point(12, 337);
            this.tb_leftPartPath.Name = "tb_leftPartPath";
            this.tb_leftPartPath.Size = new System.Drawing.Size(581, 20);
            this.tb_leftPartPath.TabIndex = 6;
            // 
            // tb_rightPartPath
            // 
            this.tb_rightPartPath.Location = new System.Drawing.Point(599, 337);
            this.tb_rightPartPath.Name = "tb_rightPartPath";
            this.tb_rightPartPath.Size = new System.Drawing.Size(564, 20);
            this.tb_rightPartPath.TabIndex = 8;
            // 
            // lv_rightPartFiles
            // 
            this.lv_rightPartFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_rightPartFiles.FullRowSelect = true;
            this.lv_rightPartFiles.GridLines = true;
            this.lv_rightPartFiles.Location = new System.Drawing.Point(599, 72);
            this.lv_rightPartFiles.Name = "lv_rightPartFiles";
            this.lv_rightPartFiles.Size = new System.Drawing.Size(564, 254);
            this.lv_rightPartFiles.TabIndex = 7;
            this.lv_rightPartFiles.UseCompatibleStateImageBehavior = false;
            this.lv_rightPartFiles.View = System.Windows.Forms.View.Details;
            this.lv_rightPartFiles.SelectedIndexChanged += new System.EventHandler(this.lv_rightPartFiles_SelectedIndexChanged);
            this.lv_rightPartFiles.DoubleClick += new System.EventHandler(this.lv_rightPartFiles_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Тип";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Размер";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Дата";
            this.columnHeader4.Width = 111;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(598, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Копировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(465, 435);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Просмотр";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(598, 435);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Создать каталог";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(598, 406);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Переместить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(465, 406);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Удалить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(465, 376);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(128, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = " Правка";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(532, 474);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(128, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "Выход";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1128, 500);
            this.Controls.Add(this.lbl_freeMemoryDisk2);
            this.Controls.Add(this.cb_Disks);
            this.Controls.Add(this.cb_Disk2);
            this.Controls.Add(this.lbl_FreeMemory);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.tb_rightPartPath);
            this.Controls.Add(this.tb_leftPartPath);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lv_rightPartFiles);
            this.Controls.Add(this.lv_leftPartFiles);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Disks;
        private System.Windows.Forms.Label lbl_FreeMemory;
        private System.Windows.Forms.Label lbl_freeMemoryDisk2;
        private System.Windows.Forms.ComboBox cb_Disk2;
        private System.Windows.Forms.ListView lv_leftPartFiles;
        private System.Windows.Forms.ColumnHeader ch_NameFile;
        private System.Windows.Forms.ColumnHeader ch_type;
        private System.Windows.Forms.ColumnHeader ch_Size;
        private System.Windows.Forms.ColumnHeader ch_Date;
        private System.Windows.Forms.TextBox tb_leftPartPath;
        private System.Windows.Forms.TextBox tb_rightPartPath;
        private System.Windows.Forms.ListView lv_rightPartFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

