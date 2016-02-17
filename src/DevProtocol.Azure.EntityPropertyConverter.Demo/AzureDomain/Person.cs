using System.Collections.Generic;
using DevProtocol.Azure.EntityPropertyConverter.Demo.Contracts;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DevProtocol.Azure.EntityPropertyConverter.Demo.AzureDomain
{
    public class Person: TableEntity, IPerson
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EntityPropertyConverter(typeof(ContactData))]
        public IContactData ContactData { get; set; }

        public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            var results = base.WriteEntity(operationContext);
            EntityPropertyConvert.Serialize(this, results);
            return results;
        }

        public override void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            base.ReadEntity(properties, operationContext);
            EntityPropertyConvert.DeSerialize(this, properties);
        }
    }
}