
namespace LibraryCatalogueProject
{
    public class Customer : ICustomer
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => FirstName + " " + LastName;

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
