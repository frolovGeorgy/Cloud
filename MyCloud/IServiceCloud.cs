using MyCloud.Faults;
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
        [FaultContract(typeof(MissingFileFault))]
        CloudFileDTO GetCloudFileWithContent(int fileId);

        [OperationContract]
        void UploadFile(CloudFileDTO cloudFileDTO);

        [OperationContract]
        [FaultContract(typeof(MissingFileFault))]
        void DeleteFile(int fileId);

        [OperationContract]
        CloudFileDTO[] UserFilesArray(string username);
    }
}
