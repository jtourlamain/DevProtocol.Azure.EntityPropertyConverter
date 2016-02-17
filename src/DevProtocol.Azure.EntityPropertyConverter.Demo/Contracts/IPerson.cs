namespace DevProtocol.Azure.EntityPropertyConverter.Demo.Contracts
{
    public interface IPerson
    {
        string Id { get; }
        string FirstName { get; }
        string LastName { get; } 
        IContactData ContactData { get; }
    }
}