using NUnit.Framework;
using PhoneBookTestApp;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {
        public PhoneBookTest()
        {
            DatabaseUtil.initializeDatabase();
        }
        [Test]
        public void IsPersonValid_NullName_ReturnsFalse()
        {
            PhoneBook phoneBook = new PhoneBook();
            Person person = new Person();
            bool result = phoneBook.IsPersonValid(person);
            Assert.IsFalse(result);
        }
        [Test]
        public void IsPersonValid_ValidName_ReturnsTrue()
        {
            PhoneBook phoneBook = new PhoneBook();
            Person person = new Person() 
            {
                Name = "Joe Bloggs",
                PhoneNumber = "(245) 156 2365"
            };
            bool result = phoneBook.IsPersonValid(person);
            Assert.IsTrue(result);
        }
        [Test]
        public void AddPerson_NullPerson_ReturnsNull()
        {
            PhoneBook phoneBook = new PhoneBook();
            Person person = new Person();
            phoneBook.addPerson(person);
            Person emptyPerson = phoneBook.findPerson(null, null);
            Assert.IsNull(emptyPerson);
        }
        [Test]
        public void AddPerson_ValidPerson_ReturnsPerson()
        {
            PhoneBook phoneBook = new PhoneBook();
            Person person = new Person()
            {
                Name = "Joe Bloggs"
            };
            phoneBook.addPerson(person);
            Person emptyPerson = phoneBook.findPerson("Joe", "Bloggs");
            Assert.IsNotNull(emptyPerson);
        }

        [Test]
        public void findPerson()
        {
            PhoneBook phoneBook = new PhoneBook();
            Person person = new Person()
            {
                Name = "New Person"
            };
            phoneBook.addPerson(person);
            Person emptyPerson = phoneBook.findPerson("New", "Person");
            Assert.IsNotNull(emptyPerson);
        }
        ~PhoneBookTest()
        {
            DatabaseUtil.CleanUp();
        }
    }

    // ReSharper restore InconsistentNaming 
}