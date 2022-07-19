using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloud.Model
{
    public class CloudFileContext : DbContext
    {
        // "testDb" - inMemory DB, "myConn" - postgresql DB
        public CloudFileContext()
            : base("testDb")
        {
        }

        public CloudFileContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public DbSet<CloudFile> CloudFiles { get; set; }
    }
}
