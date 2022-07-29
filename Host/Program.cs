using MyCloud;
using NLog;
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
            Logger logger = LogManager.GetCurrentClassLogger();
            using (var host = new ServiceHost(typeof(ServiceCloud)))
            {
                try
                {
                    host.Open();
                    logger.Debug("Server started in host");
                    Console.WriteLine("Server started");
                    Console.WriteLine("Press Enter to stop server");
                    Console.Read();
                }
                catch (TimeoutException timeProblem)
                {
                    Console.WriteLine(timeProblem.Message);
                    Console.ReadLine();
                }
                catch (CommunicationException commProblem)
                {
                    Console.WriteLine(commProblem.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
