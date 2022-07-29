using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using MyCloud.Faults;
using MyCloud.Model;
using NLog;
using NLog.LogReceiverService;

namespace MyCloud
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceCloud : IServiceCloud, ILogReceiverServer
    {
        CloudFileContext cloudFileContext;
        Logger logger;

        public ServiceCloud()
        {
            logger = LogManager.GetCurrentClassLogger();
            cloudFileContext = new CloudFileContext();
        }

        public ServiceCloud(CloudFileContext cloudFileContext)
        {
            logger = LogManager.GetCurrentClassLogger();
            this.cloudFileContext = cloudFileContext;
        }

        public CloudFileDTO GetCloudFileWithContent(int fileId)
        {
            CloudFileDTO cloudFileDTO = cloudFileContext
                .CloudFiles
                .Where(x => x.FileId == fileId)
                .Select(p => new CloudFileDTO { FileId = p.FileId, FileName = p.FileName, FileSize = p.FileSize, Username = p.Username, Content = p.Content })
                .FirstOrDefault();
            if (cloudFileDTO is null)
            {
                throw new FaultException<MissingFileFault>(new MissingFileFault(), new FaultReason("File missed in DB"));
            }
            logger.Debug($"FileContent with fileid={fileId} had loaded");
            return cloudFileDTO;
        }

        public void UploadFile(CloudFileDTO cloudFileDTO)
        {
            CloudFile cloudFile = new CloudFile { FileId = cloudFileDTO.FileId, Content = cloudFileDTO.Content, FileName = cloudFileDTO.FileName, FileSize = cloudFileDTO.FileSize, Username = cloudFileDTO.Username };
            cloudFileContext.CloudFiles.Add(cloudFile);
            cloudFileContext.SaveChanges();
            logger.Debug($"File {cloudFile.FileName} saved in DB");
        }

        public void DeleteFile(int fileId)
        {
            CloudFile cloudFile = cloudFileContext.CloudFiles.
                Where(x => x.FileId == fileId).
                FirstOrDefault();
            if (cloudFile is null)
            {
                throw new FaultException<MissingFileFault>(new MissingFileFault(), new FaultReason("File missed in DB"));
            }
            cloudFileContext.CloudFiles.Remove(cloudFile);
            cloudFileContext.SaveChanges();
            logger.Debug($"File {cloudFile.FileName} removed from DB");
        }

        public CloudFileDTO[] UserFilesArray(string username)
        {
            logger.Debug($"User {(string.IsNullOrEmpty(username) ? "\"null\"" : username)} downloaded own files list");
            return cloudFileContext.CloudFiles
                .Where(p => p.Username == username)
                .Select(p => new CloudFileDTO { FileId = p.FileId, FileName = p.FileName, FileSize = p.FileSize, Username = p.Username})
                .ToArray();
        }

        public void ProcessLogMessages(NLogEvents nevents)
        {
            var events = nevents.ToEventInfo();

            foreach (var eachEvent in events)
            {
                var logger = LogManager.GetLogger(eachEvent.LoggerName);
                logger.Log(eachEvent);
            }
        }

    }

    public class FileSizeException : Exception
    {
        public FileSizeException(string message)
            : base(message) { }
    }
}
