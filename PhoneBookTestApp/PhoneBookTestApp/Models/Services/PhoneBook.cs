using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        public PhoneBook()
        {
        }
        public void addPerson(Person newPerson)
        {
            //Validate data inserted
            if (IsPersonValid(newPerson))
            {
                DatabaseUtil.AddPerson(newPerson);
            }//Ignore if not valid
        }
        /// <summary>
        /// Validates the person object
        /// </summary>
        /// <param name="person"></param>
        /// <returns>True if person object is valid</returns>
        public bool IsPersonValid(Person person)
        {
            var context = new ValidationContext(person, serviceProvider: null, items: null);
            return Validator.TryValidateObject(person, context, null);
        }
        /// <summary>
        /// In this method we have assumed that names are saved as
        /// FirstName LastName
        /// Would have been better if we saved both FirstName and LastName separately
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>An object of Person class</returns>
        public Person findPerson(string firstName, string lastName)
        {
            string Name = firstName + " " + lastName; // Assuming this is how Persons are saved
            Person person = DatabaseUtil.FindPerson(Name);
            return person;
        }

        public List<Person> GetPhoneBook()
        {
            return DatabaseUtil.GetPhoneBook();
        }
    }
}