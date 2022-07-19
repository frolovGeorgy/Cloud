using MyCloud.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyCloud
{
    [ServiceContract]
    public interface IServiceCloud
    {

        [OperationContract]
        void UploadFile(CloudFile cloudFile);

        [OperationContract]
        void DeleteFile(int fileId);

        [OperationContract]
        List<CloudFile> FilesList();

        [OperationContract]
        CloudFile[] FilesArray();
    }
}
