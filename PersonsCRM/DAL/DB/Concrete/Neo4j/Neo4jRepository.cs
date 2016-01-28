using DAL.DB.Abstract;
using DAL.Entities;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL.DB.Concrete.Neo4j
{
    public class Neo4jRepository : IRepository<Person>
    {
        IGraphClient _graphClient;

        public Neo4jRepository()
        {
            _graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "", "");
        }

        public Person Get(int id)
        {
            Person currentPerson;

            using (var _graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "", ""))
            {
                _graphClient.Connect();
                currentPerson = _graphClient.Cypher.Match("(person:Person)")
                .Where((Person person) => person.Id == id)
                .Return(person => person.As<Person>())
                .Results.FirstOrDefault();
            }

            return currentPerson;
        }

        public IEnumerable<Person> GetAll()
        {
            List<Person> persons;

            using (var _graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "", ""))
            {
                _graphClient.Connect();
                persons = _graphClient.Cypher.Match("(person:Person)")
                .Return(person => person.As<Person>())
                .Results.ToList() ;
            }

            return persons;
        }

        public void Create(Person person)
        {
            using (var _graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "", ""))
            {
                _graphClient.Connect();
                _graphClient.Cypher.Create("(person:Person {person})")
                .WithParam("person", person)
                .ExecuteWithoutResults();
            }
        }

        public void Update(Person person)
        {
            using (var _graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "", ""))
            {
                _graphClient.Connect();
                _graphClient.Cypher.Match("(person:Person)")
                    .Where((Person updPerson) => person.Id == person.Id)
                    .Set("person = {updPerson}")
                    .WithParam("updPerson", new Person { Id = person.Id, FirstName = person.FirstName, LastName = person.LastName, Age = person.Age, Phones = person.Phones })
                    .ExecuteWithoutResults();
            }
        }

        public void Delete(int id)
        {
            using (var _graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "", ""))
            {
                _graphClient.Connect();
                _graphClient.Cypher.Match("(person:Person)")
                    .Where((Person person) => person.Id == id)
                    .Delete("person")
                    .ExecuteWithoutResults();
            }
        }
    }
}
