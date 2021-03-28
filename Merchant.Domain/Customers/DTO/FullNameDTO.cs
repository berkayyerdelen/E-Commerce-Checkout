namespace Merchant.Domain.Customers.UpsertCustomerCommandDTO
{
    public class FullNameDTO
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public FullNameDTO(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }     
    }
}
