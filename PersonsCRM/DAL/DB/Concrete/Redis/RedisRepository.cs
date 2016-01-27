using DAL.DB.Abstract;
using DAL.Entities;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System.Collections.Generic;

namespace DAL.DB.Concrete.Redis
{
    public class RedisRepository : IRepository<Person>
    {
        public Person Get(int id)
        {
            Person person;

            using (var redisClient = new RedisClient())
            {
                person = redisClient.As<Person>().GetById(id);
            }

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            IRedisTypedClient<Person> persons;

            using (var redisClient = new RedisClient())
            {
                persons = redisClient.As<Person>();
            }

            return persons as List<Person>;
        }

        public void Create(Person person)
        {
            using (var redisClient = new RedisClient())
            {
                redisClient.As<Person>().SetValue(person.Id.ToString(), person);
            }
        }

        public void Update(Person person)
        {
            Create(person);
        }

        public void Delete(int id)
        {
            using (var redisClient = new RedisClient())
            {
                var person = redisClient.As<Person>().GetById(id);
                redisClient.As<Person>().Delete(person);
            }
        }
    }
}
