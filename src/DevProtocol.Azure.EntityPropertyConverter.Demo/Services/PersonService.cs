using System.Threading.Tasks;
using DevProtocol.Azure.EntityPropertyConverter.Demo.AzureDomain;
using DevProtocol.Azure.EntityPropertyConverter.Demo.Contracts;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DevProtocol.Azure.EntityPropertyConverter.Demo.Services
{
    public class PersonService
    {
        public async Task<IPerson> GetPerson(string Id)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("YOURCONNECTIONSTRING TO AZURE STORAGE TABLES");
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("Persons");
            TableOperation retrieveOperation = TableOperation.Retrieve<Person>("Person", "1");
            TableResult result = await table.ExecuteAsync(retrieveOperation).ConfigureAwait(false);
            var p = result.Result as Person;
            return p;
        }
        
    }
}