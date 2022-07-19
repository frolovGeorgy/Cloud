using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using MyCloud.Model;

namespace MyCloud
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceCloud : IServiceCloud
    {
        CloudFileContext cloudFileContext;

        public ServiceCloud()
        {
            cloudFileContext = new CloudFileContext();
        }

        public ServiceCloud(CloudFileContext cloudFileContext)
        {
            this.cloudFileContext = cloudFileContext;
        }

        public void UploadFile(CloudFile cloudFile)
        {
            cloudFileContext.CloudFiles.Add(cloudFile);
            cloudFileContext.SaveChanges();
        }

        public void DeleteFile(int fileId)
        {
            CloudFile cloudFile = cloudFileContext.CloudFiles.Where(x => x.FileId == fileId).FirstOrDefault();
            cloudFileContext.CloudFiles.Remove(cloudFile);
            cloudFileContext.SaveChanges();
        }

        public List<CloudFile> FilesList()
        {
            return cloudFileContext.CloudFiles.ToList();
        }

        public CloudFile[] FilesArray()
        {
            return cloudFileContext.CloudFiles.ToArray();
        }

    }
    public class FileSizeException : Exception
    {
        public FileSizeException(string message)
            : base(message) { }
    }
}
