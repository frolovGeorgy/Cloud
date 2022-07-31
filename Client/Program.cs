using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new ClientForm());
            } 
            catch (TargetInvocationException)
            {
                Application.Run(new ConnectionErrorForm("Не удалось подключится к серверу"));
            }
            catch (EndpointNotFoundException)
            {
                Application.Run(new ConnectionErrorForm("Не удалось связаться с сервером"));
            }
        }
    }
}
