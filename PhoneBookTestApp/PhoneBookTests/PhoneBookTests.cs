using NUnit.Framework;
using PhoneBookTestApp;

namespace PhoneBookTests
{
    [TestFixture]
    public class PhoneBookTests
    {
        [Test]
        public void IsPersonValid_InValidNumberName_ReturnsFalse()
        {
            PhoneBook phoneBook = new PhoneBook();
            Person person = new Person()
            {
                Name = "12John"
            };
            bool result = phoneBook.IsPersonValid(person);
            Assert.IsFalse(result);
        }
        [Test]
        public void IsPersonValid_InValidCharName_ReturnsFalse()
        {
            PhoneBook phoneBook = new PhoneBook();
            Person person = new Person()
            {
                Name = "John;"
            };
            bool result = phoneBook.IsPersonValid(person);
            Assert.IsFalse(result);
        }
    }
}
