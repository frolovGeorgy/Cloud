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
                    new CloudFile { Content = new byte[] { 1 }, FileName = "first.f", FileSize = 1, Username = "Bob" },
                    new CloudFile { Content = new byte[] { 1, 2 }, FileName = "second.s", FileSize = 2, Username = "Bob" },
                    new CloudFile { Content = new byte[] { 1, 2, 3 }, FileName = "third.t", FileSize = 3, Username = "Cat" },
                    new CloudFile { Content = new byte[] { 1, 2, 3, 4 }, FileName = "fourth.f", FileSize = 4, Username = "Bob" },
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
                CloudFileDTO cloudFile = new CloudFileDTO { Content = new byte[] { 1, 2, 3, 4, 10 }, FileName = "newContent.txt", FileSize = 5, Username = "Dog" };
                service.UploadFile(cloudFile);
                Assert.AreEqual(data.Count + 1, context.CloudFiles.Count());
                Assert.IsTrue(context.CloudFiles.Any(c => c.FileId == data.Count + 1));
            }
        }

        [TestMethod]
        public void DeleteFileTest()
        {
            using (context)
            {
                CloudFile cloudFile = context.CloudFiles.First();
                service.DeleteFile(cloudFile.FileId);
                Assert.AreEqual(data.Count - 1, context.CloudFiles.Count());
                Assert.IsFalse(context.CloudFiles.Any(c => c.FileId == cloudFile.FileId));
            }
        }

        [TestMethod]
        public void FileArrayTest()
        {
            using (context)
            {
                var login = "Bob";
                CloudFileDTO[] result = service.UserFilesArray(login);
                Assert.AreEqual(data.Where(p => p.Username == login).ToList().Count, result.Length);
            }
        }
    }
}
