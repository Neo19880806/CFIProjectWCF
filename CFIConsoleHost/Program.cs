using CFIWCFServiceLiabrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CFIConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(CFIDBService));
            try
            {
                host.Open();
                Console.WriteLine("Service starts correct");
                Console.ReadLine();
                host.Close();
            }catch(Exception ex)
            {
                Console.WriteLine("Service starts with error:{0}",ex.ToString());
                Console.ReadLine();
                host.Abort();
            }
            
        }
    }
}
