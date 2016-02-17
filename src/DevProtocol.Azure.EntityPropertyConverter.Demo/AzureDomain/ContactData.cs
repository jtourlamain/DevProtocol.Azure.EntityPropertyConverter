using DevProtocol.Azure.EntityPropertyConverter.Demo.Contracts;

namespace DevProtocol.Azure.EntityPropertyConverter.Demo.AzureDomain
{
    public class ContactData: IContactData
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}