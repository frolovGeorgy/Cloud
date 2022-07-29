namespace Client
{
    partial class ClientForm
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
            this.components = new System.ComponentModel.Container();
            this.downloadButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.deleteButton = new System.Windows.Forms.Button();
            this.cloudFileDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cloudFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loginButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cloudFileDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Enabled = false;
            this.downloadButton.Location = new System.Drawing.Point(12, 415);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(102, 23);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Скачать файлы";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Enabled = false;
            this.uploadButton.Location = new System.Drawing.Point(222, 415);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(106, 23);
            this.uploadButton.TabIndex = 2;
            this.uploadButton.Text = "Загрузить файлы";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(120, 415);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(96, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить файлы";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // cloudFileDataGridView
            // 
            this.cloudFileDataGridView.AllowUserToAddRows = false;
            this.cloudFileDataGridView.AllowUserToDeleteRows = false;
            this.cloudFileDataGridView.AutoGenerateColumns = false;
            this.cloudFileDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cloudFileDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.cloudFileDataGridView.DataSource = this.cloudFileBindingSource;
            this.cloudFileDataGridView.Location = new System.Drawing.Point(12, 12);
            this.cloudFileDataGridView.Name = "cloudFileDataGridView";
            this.cloudFileDataGridView.ReadOnly = true;
            this.cloudFileDataGridView.Size = new System.Drawing.Size(468, 397);
            this.cloudFileDataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FileName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FileSize";
            this.dataGridViewTextBoxColumn3.HeaderText = "Размер, Б";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // cloudFileBindingSource
            // 
            this.cloudFileBindingSource.DataSource = typeof(MyCloud.Model.CloudFileDTO);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(334, 415);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(146, 23);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "Авторизироваться";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 458);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.cloudFileDataGridView);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.downloadButton);
            this.Name = "ClientForm";
            this.Text = "Файловое облако";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cloudFileDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudFileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.BindingSource cloudFileBindingSource;
        private System.Windows.Forms.DataGridView cloudFileDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button loginButton;
    }
}

