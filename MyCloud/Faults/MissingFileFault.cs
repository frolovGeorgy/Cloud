using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyCloud.Faults
{
    [DataContract]
    public class MissingFileFault
    {
        [DataMember]
        public string CustomError;
        public MissingFileFault()
        {
        }
        public MissingFileFault(string error)
        {
            CustomError = error;
        }
    }
}
