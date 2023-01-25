using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review
{
    public class DataLoader
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Person(string firstName, string lastName)
            {
                if (string.IsNullOrEmpty(firstName))
                    throw new ArgumentNullException("firstname");

                FirstName = firstName;
                LastName = lastName;
            }
        }

        public Person[] Load()
        {
            List<Person> a = new List<Person>();

            try
            {
                SqlConnection connection = new SqlConnection("Integrated Security=SSPI;Initial Catalog=PersonDatabase;Data Source=(local)");
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Person";
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    a.Add(new Person(sqlDataReader.GetString(0), sqlDataReader.GetString(1)));
                }
            }
            catch (Exception)
            {
            }

            return a.ToArray();
        }

        public void ChangeLastName(Person p, string n)
        {
            //Update person in database and change last name...
        }
    }
}
