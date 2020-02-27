using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    public class DatabaseUtil
    {
        public static void initializeDatabase()
        {
            CleanUp();
            var dbConnection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "create table PHONEBOOK (NAME varchar(255), PHONENUMBER varchar(255), ADDRESS varchar(255))",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Chris Johnson','(321) 231-7876', '452 Freeman Drive, Algonac, MI')",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Dave Williams','(231) 502-1236', '285 Huron St, Port Austin, MI')",
                        dbConnection);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        internal static Person FindPerson(string name)
        {
            Person person = null;
            using (SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();
                var insertString = "SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK WHERE NAME=@NAME";
                var command = new SQLiteCommand(insertString, con);
                command.Parameters.AddWithValue("@Name", name);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    person = new Person()
                    {
                        Name = reader.GetString(0),
                        PhoneNumber = (!reader.IsDBNull(1) ? reader.GetString(1) : String.Empty),
                        Address = (!reader.IsDBNull(2) ? reader.GetString(2) : String.Empty)
                    };
                }
                reader.Close();
                command.Dispose();
            }
            return person;
        }

        public static List<Person> GetPhoneBook()
        {
            List<Person> people = new List<Person>();
            using (SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();
                var insertString = "SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK";
                var command = new SQLiteCommand(insertString, con);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    people.Add(new Person()
                    {
                        Name = reader.GetString(0),
                        PhoneNumber = (!reader.IsDBNull(1) ? reader.GetString(1) : String.Empty),
                        Address = (!reader.IsDBNull(2) ? reader.GetString(2) : String.Empty)
                    });
                }
                reader.Close();
                command.Dispose();
            }
            return people;
        }

        public static void AddPerson(Person person)
        {
            using(SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                con.Open();
                var insertString = "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES(@Name,@PhoneNumber, @Address)";
                var command = new SQLiteCommand(insertString, con);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                command.Parameters.AddWithValue("@Address", person.Address);
                command.ExecuteNonQuery();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            var dbConnection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbConnection.Open();

            return dbConnection;
        }

        public static void CleanUp()
        {
            var dbConnection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "drop table IF EXISTS PHONEBOOK",
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}