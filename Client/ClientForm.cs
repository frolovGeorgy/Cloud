using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MyCloud.Model;
using MyCloud;
using System.IO;
using NLog;
using System.ServiceModel;
using MyCloud.Faults;

namespace Client
{
    public partial class ClientForm : Form
    {
        private static Logger logger;
        HostClient.ServiceCloudClient client;
        public string login { get; set; }

        public ClientForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            runApp();
            logger.Trace("Form1 loaded");
        }

        public void runApp()
        {
            client = new HostClient.ServiceCloudClient();
            logger = LogManager.GetCurrentClassLogger();
            cloudFileBindingSource = new BindingSource();
            updateSourceBinding();
        }

        public void updateSourceBinding()
        {
            if (!string.IsNullOrEmpty(login))
            {
                cloudFileBindingSource.DataSource = client.UserFilesArray(login);
                cloudFileDataGridView.DataSource = cloudFileBindingSource;
                logger.Debug("SourceBinding updated");
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.ShowDialog();
            if (!string.IsNullOrEmpty(login))
            {
                loginButton.Text = "Сменить пользователя";
                downloadButton.Enabled = true;
                uploadButton.Enabled = true;
                deleteButton.Enabled = true;

            }
            updateSourceBinding();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (cloudFileDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один файл из списка", "Ошибка");
                logger.Debug("Download button had clicked while no one file has been chosen");
                return;
            }
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
            {
                logger.Debug("User closed the folderBrowserDialog1 or pressed \"Cancel\"");
                return;
            }

            string path = folderBrowserDialog1.SelectedPath;
            logger.Debug($"Selected path is {path}");
            foreach (DataGridViewRow row in cloudFileDataGridView.SelectedRows)
            {
                CloudFileDTO cloudFileDTO = (CloudFileDTO)row.DataBoundItem;
                try
                {
                    CloudFileDTO cloudFileWithContent = client.GetCloudFileWithContent(cloudFileDTO.FileId);
                    using (FileStream fileStream = new FileStream(path + @"\" + cloudFileWithContent.FileName, FileMode.OpenOrCreate))
                    {
                        fileStream.Write(cloudFileWithContent.Content, 0, cloudFileWithContent.Content.Length);
                        logger.Debug($"The file {cloudFileDTO.FileName} had written to the path: {fileStream.Name}");
                    }
                }
                catch (FaultException<MissingFileFault>)
                {
                    logger.Debug($"File (FileId={cloudFileDTO.FileId}) wasn't in cloud");
                    MessageBox.Show($"Файл {cloudFileDTO.FileName} отсутствует в облаке", "Ошибка");
                    updateSourceBinding();
                }
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                logger.Debug("User closed the openFileDialog1 or pressed \"Cancel\"");
                return;
            }

            foreach (string path in openFileDialog1.FileNames)
            {
                string fileName = path.Substring(path.LastIndexOf('\\') + 1);
                logger.Debug($"Selected path is {path}");
                try
                {
                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        long fileSize = fileStream.Length;
                        try
                        {
                            if (fileSize > 500000000)
                            {
                                throw new FileSizeException("File size can not be larger than 500 MB"));
                            }
                            byte[] content = new byte[fileSize];
                            fileStream.Read(content, 0, content.Length);
                            CloudFileDTO cloudFile = new CloudFileDTO { Content = content, FileName = fileName, FileSize = fileSize, Username = login };
                            client.UploadFile(cloudFile);
                            logger.Debug($"File {cloudFile.FileName} had uploaded");
                        }
                        catch (FileSizeException)
                        {
                            logger.Debug($"File's size was bigger than 500000000 B (file size = {fileSize} B)");
                            MessageBox.Show($"Файл не может быть больше 500 МБ.", "Ошибка");
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    logger.Debug($"User {login} don't have permission to the path: {path}");
                    MessageBox.Show($"У Вас не прав доступа по данному пути", "Ошибка");
                }
            }
            updateSourceBinding();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (cloudFileDataGridView.SelectedRows.Count == 0)
            {
                logger.Debug("Delete button had clicked while no one file has been chosen");
                MessageBox.Show("Пожалуйста, выберите хотя бы один файл из списка", "Ошибка");
                return;
            }

            foreach (DataGridViewRow row in cloudFileDataGridView.SelectedRows)
            {
                CloudFileDTO cloudFileDTO = (CloudFileDTO)row.DataBoundItem;
                try
                {
                    client.DeleteFile(cloudFileDTO.FileId);
                    logger.Debug($"File {cloudFileDTO.FileId} had deleted");
                }
                catch (FaultException<MissingFileFault>)
                {
                    logger.Debug($"File (FileId={cloudFileDTO.FileId}) wasn't in cloud");
                    MessageBox.Show($"Файл {cloudFileDTO.FileName} отсутствует в облаке", "Ошибка");
                }
            }
            updateSourceBinding();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Debug($"User \"{login}\" disconected");
            client.Close();
        }

    }
}
