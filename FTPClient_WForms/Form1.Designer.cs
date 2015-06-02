namespace FTPClient_WForms
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.connect_button = new System.Windows.Forms.Button();
            this.port_label = new System.Windows.Forms.Label();
            this.pass_label = new System.Windows.Forms.Label();
            this.user_label = new System.Windows.Forms.Label();
            this.host_label = new System.Windows.Forms.Label();
            this.port_box = new System.Windows.Forms.TextBox();
            this.pass_box = new System.Windows.Forms.TextBox();
            this.user_box = new System.Windows.Forms.TextBox();
            this.host_box = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.consoleLog = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.localFolders = new System.Windows.Forms.DataGridView();
            this.remoteFolder = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size_local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.connect_button);
            this.panel1.Controls.Add(this.port_label);
            this.panel1.Controls.Add(this.pass_label);
            this.panel1.Controls.Add(this.user_label);
            this.panel1.Controls.Add(this.host_label);
            this.panel1.Controls.Add(this.port_box);
            this.panel1.Controls.Add(this.pass_box);
            this.panel1.Controls.Add(this.user_box);
            this.panel1.Controls.Add(this.host_box);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 45);
            this.panel1.TabIndex = 0;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(602, 9);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(75, 23);
            this.connect_button.TabIndex = 8;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.Location = new System.Drawing.Point(510, 12);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(35, 13);
            this.port_label.TabIndex = 7;
            this.port_label.Text = "Порт:";
            // 
            // pass_label
            // 
            this.pass_label.AutoSize = true;
            this.pass_label.Location = new System.Drawing.Point(356, 12);
            this.pass_label.Name = "pass_label";
            this.pass_label.Size = new System.Drawing.Size(48, 13);
            this.pass_label.TabIndex = 6;
            this.pass_label.Text = "Пароль:";
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.Location = new System.Drawing.Point(144, 12);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(106, 13);
            this.user_label.TabIndex = 5;
            this.user_label.Text = "Имя пользователя:";
            // 
            // host_label
            // 
            this.host_label.AutoSize = true;
            this.host_label.Location = new System.Drawing.Point(3, 12);
            this.host_label.Name = "host_label";
            this.host_label.Size = new System.Drawing.Size(34, 13);
            this.host_label.TabIndex = 4;
            this.host_label.Text = "Хост:";
            // 
            // port_box
            // 
            this.port_box.Location = new System.Drawing.Point(550, 9);
            this.port_box.Name = "port_box";
            this.port_box.Size = new System.Drawing.Size(46, 20);
            this.port_box.TabIndex = 3;
            // 
            // pass_box
            // 
            this.pass_box.Location = new System.Drawing.Point(407, 9);
            this.pass_box.Name = "pass_box";
            this.pass_box.Size = new System.Drawing.Size(100, 20);
            this.pass_box.TabIndex = 2;
            this.pass_box.UseSystemPasswordChar = true;
            // 
            // user_box
            // 
            this.user_box.Location = new System.Drawing.Point(253, 9);
            this.user_box.Name = "user_box";
            this.user_box.Size = new System.Drawing.Size(100, 20);
            this.user_box.TabIndex = 1;
            // 
            // host_box
            // 
            this.host_box.Location = new System.Drawing.Point(41, 9);
            this.host_box.Name = "host_box";
            this.host_box.Size = new System.Drawing.Size(100, 20);
            this.host_box.TabIndex = 0;
            this.host_box.Text = "localhost";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.consoleLog);
            this.panel2.Location = new System.Drawing.Point(13, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 100);
            this.panel2.TabIndex = 1;
            // 
            // consoleLog
            // 
            this.consoleLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleLog.Location = new System.Drawing.Point(4, 4);
            this.consoleLog.Name = "consoleLog";
            this.consoleLog.ReadOnly = true;
            this.consoleLog.Size = new System.Drawing.Size(678, 96);
            this.consoleLog.TabIndex = 0;
            this.consoleLog.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.localFolders, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.remoteFolder, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 172);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(685, 180);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // localFolders
            // 
            this.localFolders.AllowUserToAddRows = false;
            this.localFolders.AllowUserToDeleteRows = false;
            this.localFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.localFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name_local,
            this.size_local,
            this.local_type});
            this.localFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localFolders.Location = new System.Drawing.Point(3, 3);
            this.localFolders.Name = "localFolders";
            this.localFolders.ReadOnly = true;
            this.localFolders.RowHeadersVisible = false;
            this.localFolders.Size = new System.Drawing.Size(336, 174);
            this.localFolders.TabIndex = 0;
            this.localFolders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.localFolders_MouseDoubleClick);
            // 
            // remoteFolder
            // 
            this.remoteFolder.AllowUserToAddRows = false;
            this.remoteFolder.AllowUserToDeleteRows = false;
            this.remoteFolder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.remoteFolder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.size,
            this.type});
            this.remoteFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteFolder.Location = new System.Drawing.Point(345, 3);
            this.remoteFolder.Name = "remoteFolder";
            this.remoteFolder.ReadOnly = true;
            this.remoteFolder.RowHeadersVisible = false;
            this.remoteFolder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.remoteFolder.Size = new System.Drawing.Size(337, 174);
            this.remoteFolder.TabIndex = 1;
            this.remoteFolder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.remoteFolder_MouseDoubleClick);
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // size
            // 
            this.size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.size.DefaultCellStyle = dataGridViewCellStyle2;
            this.size.HeaderText = "Размер";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.size.Width = 71;
            // 
            // type
            // 
            this.type.HeaderText = "type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Visible = false;
            // 
            // name_local
            // 
            this.name_local.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name_local.HeaderText = "Название";
            this.name_local.Name = "name_local";
            this.name_local.ReadOnly = true;
            this.name_local.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // size_local
            // 
            this.size_local.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.size_local.DefaultCellStyle = dataGridViewCellStyle1;
            this.size_local.HeaderText = "Размер";
            this.size_local.Name = "size_local";
            this.size_local.ReadOnly = true;
            this.size_local.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.size_local.Width = 71;
            // 
            // local_type
            // 
            this.local_type.HeaderText = "local_type";
            this.local_type.Name = "local_type";
            this.local_type.ReadOnly = true;
            this.local_type.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 381);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.localFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteFolder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox port_box;
        private System.Windows.Forms.TextBox pass_box;
        private System.Windows.Forms.TextBox user_box;
        private System.Windows.Forms.TextBox host_box;
        private System.Windows.Forms.Label port_label;
        private System.Windows.Forms.Label pass_label;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Label host_label;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox consoleLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView localFolders;
        private System.Windows.Forms.DataGridView remoteFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_local;
        private System.Windows.Forms.DataGridViewTextBoxColumn size_local;
        private System.Windows.Forms.DataGridViewTextBoxColumn local_type;
    }
}

