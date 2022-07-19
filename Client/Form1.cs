using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MyCloud.Model;
using MyCloud;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        HostClient.ServiceCloudClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            runApp();
        }

        public void runApp()
        {
            client = new HostClient.ServiceCloudClient();
            cloudFileBindingSource = new BindingSource();
            updateSourceBinding();
        }

        public void updateSourceBinding()
        {
            cloudFileBindingSource.DataSource = client.FilesArray();
            cloudFileDataGridView.DataSource = cloudFileBindingSource;
        }

        private void downloadButton_Click(object sender, EventArgs e)
        { 
            if (cloudFileDataGridView.SelectedRows.Count == 0)
            { 
                MessageBox.Show("Пожалуйста, выберите хотя бы один файл из списка", "Ошибка");
                return;
            }

            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;

            string path = folderBrowserDialog1.SelectedPath;
            foreach (DataGridViewRow row in cloudFileDataGridView.SelectedRows)
            {
                CloudFile cloudFile = (CloudFile)row.DataBoundItem;
                try
                {
                    using (FileStream fileStream = new FileStream(path + @"\" + cloudFile.FileName, FileMode.OpenOrCreate))
                    {
                        fileStream.Write(cloudFile.Content, 0, cloudFile.Content.Length);
                    }
                } catch (System.ServiceModel.FaultException)
                {
                    MessageBox.Show($"Файл {cloudFile.FileName} отсутствует в облаке", "Ошибка");
                    updateSourceBinding();
                }
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            foreach (string path in openFileDialog1.FileNames)
            {
                string fileName = path.Substring(path.LastIndexOf('\\') + 1);

                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    try
                    { 
                        long fileSize = fileStream.Length;
                        if (fileSize > 500000000)
                        {
                            throw new FileSizeException("File size can not be larger than 500 MB");
                        }
                        byte[] content = new byte[fileSize];
                        fileStream.Read(content, 0, content.Length);
                        CloudFile cloudFile = new CloudFile { Content = content, FileName = fileName, FileSize = fileSize };
                        client.UploadFile(cloudFile);
                    } catch (FileSizeException)
                    {
                        MessageBox.Show($"Файл не может быть больше 500 МБ.", "Ошибка");
                    }
                }
            }
            updateSourceBinding();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (cloudFileDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один файл из списка", "Ошибка");
                return;
            }

            foreach (DataGridViewRow row in cloudFileDataGridView.SelectedRows)
            {
                CloudFile cloudFile = (CloudFile)row.DataBoundItem;
                try
                {
                    client.DeleteFile(cloudFile.FileId);
                } catch (System.ServiceModel.FaultException)
                {
                    MessageBox.Show($"Файл {cloudFile.FileName} отсутствует в облаке", "Ошибка");
                } finally
                {
                    updateSourceBinding();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }
    }
}
