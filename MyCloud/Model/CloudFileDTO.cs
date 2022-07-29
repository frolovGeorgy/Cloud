using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloud.Model
{
    public class CloudFileDTO
    {
        public int FileId { get; set; }

        public byte[] Content { get; set; }

        public string FileName { get; set; }

        public float FileSize { get; set; }

        public string Username { get; set; }
    }
}
