using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevProtocol.Azure.EntityPropertyConverter.Demo.AzureDomain;
using DevProtocol.Azure.EntityPropertyConverter.Demo.Services;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DevProtocol.Azure.EntityPropertyConverter.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = PrintPersonData();
            t.Wait();
            Console.WriteLine();
            Console.ReadLine();
        }

        private static async Task PrintPersonData()
        {
            var service = new PersonService();
            var result = await service.GetPerson("1");
            Console.WriteLine($"Found Person: {result.FirstName}");
        }
    }
}
