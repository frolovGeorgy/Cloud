using MyCloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCloud serviceCloud = new ServiceCloud();
            using (var host = new ServiceHost(typeof(ServiceCloud)))
            {
                host.Open();
                Console.WriteLine("Server started");
                Console.WriteLine("Press Enter to stop server");
                Console.Read();
            }
        }
    }
}
