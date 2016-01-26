using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.ADO
{
    public class AdoRepository : IRepository<Person>
    {
        //string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Roman\Documents\Repository\Valtech_\PersonsCRM\WebUI\App_Data\PersonsDB.mdf;Integrated Security=True";


        public Person Get(int id)
        {
            Person person = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand {CommandText = $"SELECT * FROM People WHERE Id = {id}; SELECT * FROM Phones WHERE PersonId = {id}" };
                var dataReader = command.ExecuteReader();

                if (!dataReader.HasRows) return person;

                while (dataReader.Read())
                {
                    person = new Person
                    {
                        Id = dataReader.GetInt32(0),
                        FirstName = dataReader.GetString(1),
                        LastName = dataReader.GetString(2),
                        Age = dataReader.GetInt32(3),
                        Phones = new List<Phone>
                        {
                            new Phone
                            {
                                Number = dataReader.GetString(4),
                                Type = dataReader.GetString(5),
                                PersonId = dataReader.GetInt32(6)
                            }
                        }
                    };
                }
            }
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            var persons = new List<Person>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand {CommandText = "SELECT * FROM People"};
                command.Connection = connection;
                var dataReader = command.ExecuteReader();

                if (!dataReader.HasRows) return persons;

                while (dataReader.Read())
                {
                    var person = new Person
                    {
                        Id = dataReader.GetInt32(0),
                        FirstName = dataReader.GetString(1),
                        LastName = dataReader.GetString(2),
                        Age = dataReader.GetInt32(3)
                    };

                    persons.Add(person);
                }

                using (var phoneConnection = new SqlConnection(_connectionString))
                {
                    phoneConnection.Open();
                    var phoneCommand = new SqlCommand { CommandText = "SELECT * FROM People" };
                    phoneCommand.Connection = phoneConnection;
                    var phoneDataReader = phoneCommand.ExecuteReader();


                    foreach (var person in persons)
                    {
                        phoneCommand = new SqlCommand { CommandText = $"SELECT * FROM Phone WHERE PersonId = {person.Id}" };
                        phoneCommand.Connection = phoneConnection;

                        if (!phoneDataReader.HasRows) break;

                        while (phoneDataReader.Read())
                        {
                            var phone = new Phone
                            {
                                ///TODO: finish the query
                                Id = dataReader.GetInt32(0),
                                Number = dataReader.GetString(1),
                                Type = dataReader.GetString(2),
                                PersonId = dataReader.GetInt32(3)
                            };

                            person.Phones.Add(phone);
                        }
                    }
                }
            }

            return persons;
        }

        public void Create(Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = "INSERT INTO People (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)"
                };

                var firstNameParam = new SqlParameter("@FirstName", person.FirstName);
                command.Parameters.Add(firstNameParam);

                var lastNameParam = new SqlParameter("@LastName", person.LastName);
                command.Parameters.Add(lastNameParam);

                var ageParam = new SqlParameter("@Age", person.Age);
                command.Parameters.Add(ageParam);

                command.ExecuteNonQuery();

                foreach (var phone in person.Phones)
                {
                    var phoneCommand = new SqlCommand
                    {
                        CommandText = "INSERT INTO Phones (Number, Type, PersonId) VALUES (@Number, @Type, @PersonId)"
                    };
                    var numberParam = new SqlParameter("@Number", phone.Number);
                    phoneCommand.Parameters.Add(firstNameParam);

                    var typeParam = new SqlParameter("@Type", phone.Type);
                    phoneCommand.Parameters.Add(lastNameParam);

                    var personIdParam = new SqlParameter("@PersonId", phone.PersonId);
                    phoneCommand.Parameters.Add(ageParam);

                    phoneCommand.ExecuteNonQuery();
                }
            }
        }

        public void Update(Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = "UPDATE People SET FirstName = @FirstName, LastName = @LastName, Age = @Age"
                };

                var firstNameParam = new SqlParameter("@FirstName", person.FirstName);
                command.Parameters.Add(firstNameParam);

                var lastNameParam = new SqlParameter("@LastName", person.LastName);
                command.Parameters.Add(lastNameParam);

                var ageParam = new SqlParameter("@Age", person.Age);
                command.Parameters.Add(ageParam);

                command.ExecuteNonQuery();

                foreach (var phone in person.Phones)
                {
                    var phoneCommand = new SqlCommand
                    {
                        CommandText = "UPDATE Phones SET Number = @Number, Type = @Type, PersonId = @PersonId"
                    };
                    var numberParam = new SqlParameter("@Number", phone.Number);
                    phoneCommand.Parameters.Add(firstNameParam);

                    var typeParam = new SqlParameter("@Type", phone.Type);
                    phoneCommand.Parameters.Add(lastNameParam);

                    var personIdParam = new SqlParameter("@PersonId", phone.PersonId);
                    phoneCommand.Parameters.Add(ageParam);

                    phoneCommand.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand
                {
                    CommandText = $"DELETE FROM People WHERE Id = {id}; DELETE FROM Phones WHERE PhoneId = {id}"
                };

                command.ExecuteNonQuery();
            }
        }
    }
}