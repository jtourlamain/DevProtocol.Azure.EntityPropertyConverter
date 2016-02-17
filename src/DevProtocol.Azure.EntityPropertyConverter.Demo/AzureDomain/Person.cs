using DevProtocol.Azure.EntityPropertyConverter.Demo.Contracts;

namespace DevProtocol.Azure.EntityPropertyConverter.Demo.AzureDomain
{
    public class Person: IPerson
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IContactData ContactData { get; set; }
    }
}