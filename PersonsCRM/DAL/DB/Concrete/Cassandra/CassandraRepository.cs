using DAL.DB.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Cassandraemon;
using Apache.Cassandra;
using Cassandra;

namespace DAL.DB.Concrete.Cassandra
{
    public class CassandraRepository : IRepository<Person>
    {
        private const string HOST = "localhost";
        private const int PORT = 8081;
        private const string KEYSPACE = "PersonsDB";
        private const string COLUMNFAMILY = "Persons";

        Cluster cluster = Cluster.Builder().AddContactPoint(HOST).Build();

        public Person Get(int id)
        {
            ISession session = cluster.Connect("PersonsDB");
            var row = session.Execute($"select * from Persons where Id = {id}").FirstOrDefault();
            var person = new Person
            {
                Id = (int)row["Id"],
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Age = (int)row["Age"]
            };

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            //IEnumerable<Person> persons;
            //using (var context = new CassandraContext(HOST, PORT, KEYSPACE))
            //{
            //    var records = (from x in context.ColumnList where x.ColumnFamily == COLUMNFAMILY select x.ToObject<Person>());
            //    persons = records.ToList().Where(x => x != null).AsEnumerable();
            //}
            ISession session = cluster.Connect("PersonsDB");
            var rows = session.Execute($"select * from Persons");


            return null;
        }

        public void Create(Person person)
        {
            ISession session = cluster.Connect("PersonsDB");

            session.Execute($"insert into Persons (Id, FirstName, LastName, Age) values ({person.Id}, {person.FirstName}, {person.LastName}, {person.Age})");
        }

        public void Update(Person person)
        {
            //using (var context = new CassandraContext(HOST, PORT, KEYSPACE))
            //{
            //    var records = new CassandraEntity<List<Column>>().SetColumnFamily(COLUMNFAMILY).SetKey(person.Id).SetData(person);
            //    context.ColumnList.InsertOnSubmit(records);
            //    context.SubmitChanges();
            //}

            ISession session = cluster.Connect("PersonsDB");

            session.Execute($"insert into Persons (Id, FirstName, LastName, Age) values ({person.Id}, {person.FirstName}, {person.LastName}, {person.Age})");
        }

        public void Delete(int id)
        {
            using (var context = new CassandraContext(HOST, PORT, KEYSPACE))
            {
                context.Column.DeleteOnSubmit(x => x.ColumnFamily == COLUMNFAMILY && x.Key == id);
                context.SubmitChanges();
            }
        }
    }
}
