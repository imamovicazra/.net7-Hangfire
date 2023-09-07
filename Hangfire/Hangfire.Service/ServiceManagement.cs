using Hangfire.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Service
{
    public class ServiceManagement : IServiceManagement
    {
        public void GenerateMerchandise()
        {
            Console.WriteLine($"Generate Merchandise: Long running task {DateTime.Now.ToString()}");
        }

        public void SendEmail()
        {
            Console.WriteLine($"Send Email: Short running task {DateTime.Now.ToString()}");
        }

        public void SyncData()
        {
            Console.WriteLine($"Sync Data: Short running task {DateTime.Now.ToString()}");
        }

        public void UpdateDatabase()
        {
            Console.WriteLine($"Update Database: Long running task {DateTime.Now.ToString()}");
        }
    }
}
