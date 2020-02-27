using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        private PhoneBook phonebook = new PhoneBook();
        static void Main(string[] args)
        {
            (new Program()).PerformActions();
        }

        private void PerformActions()
        {
            try
            {
                DatabaseUtil.initializeDatabase();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
                phonebook.addPerson(new Person()
                {
                    Name = "John Smith",
                    PhoneNumber = "(248) 123-4567",
                    Address = "1234 Sand Hill Dr, Royal Oak, MI"
                });
                phonebook.addPerson(new Person()
                {
                    Name = "Cynthia Smith",
                    PhoneNumber = "(824) 128-8758",
                    Address = "875 Main St, Ann Arbor, MI"
                });

                // TODO: print the phone book out to System.out
                List<Person> people = phonebook.GetPhoneBook();
                foreach (Person person in people)
                {
                    Console.WriteLine(person);
                    Console.WriteLine("--------------------------------------------------");
                }
                // TODO: find Cynthia Smith and print out just her entry
                Person cynthia = phonebook.findPerson("Cynthia", "Smith");
                if (null != cynthia)
                {
                    Console.WriteLine("-------Found - Cynthia Smith-------");
                    Console.WriteLine(cynthia);
                }else
                {
                    Console.WriteLine("'Cynthia Smith' can't be found");
                }
                // TODO: insert the new person objects into the database
                phonebook.addPerson(new Person()
                {
                    Name = "Donald Trump"
                });
                Console.ReadLine();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
