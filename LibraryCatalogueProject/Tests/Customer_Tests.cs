using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.Tests
{
    [TestClass]
    public class Customer_Tests
    {
        [TestMethod]
        public void CreateNewCustomer_NewCustomerShouldBeCreatedSuccessfully()
        {
            // Arrange
            var firstName = "Sam";
            var lastName = "Foxy";

            // Act
            var customer = new Customer(firstName, lastName);
            var expected = firstName + " " + lastName;

            // Assert
            Assert.AreEqual(expected, customer.FullName);
        }
    }
}
