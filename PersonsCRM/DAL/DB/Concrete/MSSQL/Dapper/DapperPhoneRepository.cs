using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.Dapper
{
    public class DapperPhoneRepository : IRepository<Phone>
    {
        private readonly string _connectionString;

        public DapperPhoneRepository(string connection)
        {
            _connectionString = connection;
        }
        public Phone Get(int id)
        {
            Phone phone;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                phone = db.Query<Phone>("SELECT * FROM Phones WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return phone;
        }

        public IEnumerable<Phone> GetAll()
        {
            List<Phone> phones;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                phones = db.Query<Phone>("SELECT * FROM Phones").ToList();
            }

            return phones;
        }

        public void Create(Phone item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Phones (Number, Type, PersonId) VALUES(@Number, @Type, @PersonId)";
                db.Execute(sqlQuery, item);
            }
        }

        public void Update(Phone item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Persons SET Number = @Number, Type = @Type, PersonId = @PersonId";
                db.Execute(sqlQuery, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"DELETE FROM Phones WHERE Id = {id}";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
