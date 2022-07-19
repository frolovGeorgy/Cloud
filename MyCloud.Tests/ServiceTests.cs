using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyCloud.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyCloud.Tests
{

    [TestClass]
    public class ServiceTests
    {
        List<CloudFile> data;
        CloudFileContext context;
        ServiceCloud service;

        [TestInitialize]
        public void TestInitialize()
        {
            data = new List<CloudFile>
                {
                    new CloudFile { Content = new byte[] { 1 }, FileName = "first.f", FileSize = 1 },
                    new CloudFile { Content = new byte[] { 1, 2 }, FileName = "second.s", FileSize = 2 },
                    new CloudFile { Content = new byte[] { 1, 2, 3 }, FileName = "third.t", FileSize = 3 },
                    new CloudFile { Content = new byte[] { 1, 2, 3, 4 }, FileName = "fourth.f", FileSize = 4 },
                };

            context = new CloudFileContext(Effort.DbConnectionFactory.CreateTransient());

            service = new ServiceCloud(context);

            context.CloudFiles.AddRange(data);
            context.SaveChanges();
        }


        [TestMethod]
        public void UploadFileTest()
        {
            using (context)
            {
                CloudFile cloudFile = new CloudFile { Content = new byte[] { 1, 2, 3, 4, 10 }, FileName = "newContent.txt", FileSize = 5 };
                service.UploadFile(cloudFile);
                Assert.AreEqual(data.Count + 1, context.CloudFiles.Count());
                Assert.IsTrue(context.CloudFiles.Any(c => c.FileId == cloudFile.FileId));
            }
        }

        [TestMethod]
        public void DeleteFileTest()
        {
            using (context)
            {
                CloudFile cloudFile = context.CloudFiles.First();
                service.DeleteFile(cloudFile);
                Assert.AreEqual(data.Count - 1, context.CloudFiles.Count());
                Assert.IsFalse(context.CloudFiles.Any(c => c.FileId == cloudFile.FileId));
            }
        }

        [TestMethod]
        public void FileListTest()
        {
            using (context)
            {
                List<CloudFile> result = service.FilesList();
                Assert.AreEqual(data.Count, result.Count);
            }
        }
        [TestMethod]
        public void FileArrayTest()
        {
            using (context)
            {
                CloudFile[] result = service.FilesArray();
                Assert.AreEqual(data.Count, result.Length);
            }
        }
    }
}
