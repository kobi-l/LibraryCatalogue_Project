using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace LibraryCatalog.Tests
{
    [TestClass]
    public class Customer_Tests
    {
        [TestMethod]
        public void CreateNewCustomer_NewCustomerShouldBeCreatedSuccessfully()
        {
            // Arrange
            string firstName = null;
            var lastName = "Foxy";

            // Conditional Directives!!! Allow to include or exclude blocks of code!
#if DEBUG 
            firstName = "Samantha";;
#elif RELEASE
            firstName = "Melania";
# endif

            // Act
            var customer = new Customer(firstName, lastName);
            //var expected = firstName + " " + lastName;

            // Assert
            //Assert.AreEqual(expected, customer.FullName);

            // Assert using FluentAssertions
            customer.FullName.Should().Be(firstName + " " + lastName, "Because Full Name consists of First and Last names");
        }
    }
}
