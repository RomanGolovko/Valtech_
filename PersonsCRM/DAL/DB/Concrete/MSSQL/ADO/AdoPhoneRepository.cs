using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.ADO
{
    public class AdoPhoneRepository : IRepository<Phone>
    {
        private string _connectionString;

        public AdoPhoneRepository(string connection)
        {
            _connectionString = connection;
        }

        public Phone Get(int id)
        {
            Phone phone = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand { CommandText = $"SELECT * FROM Phones WHERE Id = {id}" };
                var dataReader = command.ExecuteReader();

                if (!dataReader.HasRows) return phone;

                while (dataReader.Read())
                {
                    phone = new Phone()
                    {
                        Id = dataReader.GetInt32(0),
                        Number = dataReader.GetString(1),
                        Type = dataReader.GetString(2),
                        PersonId = dataReader.GetInt32(3)
                    };
                }
            }

            return phone;
        }

        public IEnumerable<Phone> GetAll()
        {
            var phones = new List<Phone>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand { CommandText = "SELECT * FROM Phones" };
                var dataReader = command.ExecuteReader();

                if (!dataReader.HasRows) return phones;

                while (dataReader.Read())
                {
                    var phone = new Phone()
                    {
                        Id = dataReader.GetInt32(0),
                        Number = dataReader.GetString(1),
                        Type = dataReader.GetString(2),
                        PersonId = dataReader.GetInt32(3)
                    };

                    phones.Add(phone);
                }
            }
            return phones;
        }

        public void Create(Phone phone)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = "INSERT INTO Phones (Number, Type, PersonId) VALUES (@Number, @Type, @PersonId)"
                };

                var firstNameParam = new SqlParameter("@FirstName", phone.Number);
                command.Parameters.Add(firstNameParam);

                var lastNameParam = new SqlParameter("@LastName", phone.Type);
                command.Parameters.Add(lastNameParam);

                var ageParam = new SqlParameter("@Age", phone.PersonId);
                command.Parameters.Add(ageParam);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Phone phone)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = "UPDATE Phones SET Number = @Number, Type = @Type, PersonId = @PersonId"
                };

                var firstNameParam = new SqlParameter("@FirstName", phone.Number);
                command.Parameters.Add(firstNameParam);

                var lastNameParam = new SqlParameter("@LastName", phone.Type);
                command.Parameters.Add(lastNameParam);

                var ageParam = new SqlParameter("@Age", phone.PersonId);
                command.Parameters.Add(ageParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand
                {
                    CommandText = $"DELETE FROM Phones WHERE Id = {id}"
                };

                command.ExecuteNonQuery();
            }
        }
    }
}
