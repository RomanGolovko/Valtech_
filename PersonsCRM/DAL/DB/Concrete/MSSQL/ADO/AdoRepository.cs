using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.ADO
{
    public class AdoRepository : IRepository<Person>
    {
        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename='D:\GitHub Repository\Valtech_\PersonsCRM\WebUI\App_Data\PersonsDB.mdf';Integrated Security=True";

        public Person Get(int id)
        {
            Person person = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand
                {
                    CommandText = "SELECT * FROM People, Phones WHERE People.Id = @id AND Phones.PersonId = @id",
                    Connection = connection
                };

                var idParameter = new SqlParameter(@"id", id);
                command.Parameters.Add(idParameter);

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
                                Number = dataReader.GetString(5),
                                Type = dataReader.GetString(6),
                                PersonId = dataReader.GetInt32(7)
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
                var command = new SqlCommand
                {
                    CommandText = "SELECT * FROM People JOIN Phones ON Phones.PersonId = People.Id",
                    Connection = connection
                };

                var dataReader = command.ExecuteReader();

                if (!dataReader.HasRows) return persons;

                while (dataReader.Read())
                {
                    var person = new Person
                    {
                        Id = dataReader.GetInt32(0),
                        FirstName = dataReader.GetString(1),
                        LastName = dataReader.GetString(2),
                        Age = dataReader.GetInt32(3),
                        Phones = new List<Phone>
                        {
                            new Phone
                            {
                                Number = dataReader.GetString(5),
                                Type = dataReader.GetString(6),
                                PersonId = dataReader.GetInt32(7)
                            }
                        }
                    };

                    persons.Add(person);
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
                    CommandText = "INSERT INTO People (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age); " +
                                  @"SELECT @ID = SCOPE_IDENTITY()",
                    Connection = connection
                };

                var firstNameParam = new SqlParameter("@FirstName", person.FirstName);
                command.Parameters.Add(firstNameParam);

                var lastNameParam = new SqlParameter("@LastName", person.LastName);
                command.Parameters.Add(lastNameParam);

                var ageParam = new SqlParameter("@Age", person.Age);
                command.Parameters.Add(ageParam);

                var output = new SqlParameter(@"ID", SqlDbType.Int);
                command.Parameters.Add(output);
                output.Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                foreach (var phone in person.Phones)
                {
                    var phoneCommand = new SqlCommand
                    {
                        CommandText = "INSERT INTO Phones (Number, Type, PersonId) VALUES (@Number, @Type, @PersonId)",
                        Connection = connection
                    };

                    var numberParam = new SqlParameter("@Number", phone.Number);
                    phoneCommand.Parameters.Add(numberParam);

                    var typeParam = new SqlParameter("@Type", phone.Type);
                    phoneCommand.Parameters.Add(typeParam);

                    var personIdParam = new SqlParameter("@PersonId", Convert.ToInt32(output.Value));
                    phoneCommand.Parameters.Add(personIdParam);

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
                    CommandText = "UPDATE People SET FirstName = @FirstName, LastName = @LastName, Age = @Age",
                    Connection = connection
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
                        CommandText = "UPDATE Phones SET Number = @Number, Type = @Type, PersonId = @PersonId",
                        Connection = connection
                    };
                    var numberParam = new SqlParameter("@Number", phone.Number);
                    phoneCommand.Parameters.Add(numberParam);

                    var typeParam = new SqlParameter("@Type", phone.Type);
                    phoneCommand.Parameters.Add(typeParam);

                    var personIdParam = new SqlParameter("@PersonId", person.Id);
                    phoneCommand.Parameters.Add(personIdParam);

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
                    CommandText = "DELETE FROM Phones WHERE PersonId = @id; DELETE FROM People WHERE Id = @id",
                    Connection = connection
                };

                var idParameter = new SqlParameter(@"id", id);
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
        }
    }
}