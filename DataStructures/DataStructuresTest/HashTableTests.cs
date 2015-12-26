using System;
using DataStructures.Abstract;
using DataStructures.Concrete.HashTables;
using NUnit.Framework;

namespace DataStructuresTest
{
    [TestFixture(typeof(AHashTable))]
    [TestFixture(typeof(LHashTable<int, Person>))]
    public class HashTableTests<T> where T : IHashTable, new()
    {
        IHashTable MakeHashTable()
        {
            return new T();
        }

        #region Size
        [Test]
        public void Can_Get_Size_Of_Many()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 5; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            Assert.AreEqual(5, hashTable.Size);
        }

        [Test]
        public void Can_Get_Size_Of_2()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 2; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            Assert.AreEqual(2, hashTable.Size);
        }

        [Test]
        public void Can_Get_Size_Of_1()
        {
            var hashTable = MakeHashTable();
            var person = new Person { Id = 1, FirstName = $"Test{1}", LastName = $"Test{1}", Age = 25 };
            hashTable.Add(person.Id, person);
            Assert.AreEqual(1, hashTable.Size);
        }

        [Test]
        public void Can_Get_Size_Of_0()
        {
            var hashTable = MakeHashTable();
            Assert.AreEqual(0, hashTable.Size);
        }

        [Test]
        public void Can_Get_Size_Of_Null()
        {
            var person = MakeHashTable();
            person = null;
            Assert.Throws<NullReferenceException>(() => person.Size.ToString());
        }
        #endregion

        #region Clear
        [Test]
        public void Can_Cleare_Many()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 5; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            hashTable.Clear();
            Assert.AreEqual(0, hashTable.Size);
        }

        [Test]
        public void Can_Cleare_2()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 2; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            hashTable.Clear();
            Assert.AreEqual(0, hashTable.Size);
        }

        [Test]
        public void Can_Cleare_1()
        {
            var hashTable = MakeHashTable();
            var person = new Person { Id = 1, FirstName = $"Test{1}", LastName = $"Test{1}", Age = 25 };
            hashTable.Add(person.Id, person);
            hashTable.Clear();
            Assert.AreEqual(0, hashTable.Size);
        }

        [Test]
        public void Can_Cleare_0()
        {
            var hashTable = MakeHashTable();
            hashTable.Clear();
            Assert.AreEqual(0, hashTable.Size);
        }

        [Test]
        public void Can_Cleare_Null()
        {
            var person = MakeHashTable();
            person = null;
            Assert.Throws<NullReferenceException>(() => person.Clear());
        }
        #endregion

        #region Add
        [Test]
        public void Can_Add_To_Many()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 5; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            var personToAdd = new Person { Id = 15, FirstName = $"Added person", LastName = $"Added person", Age = 25 };
            hashTable.Add(personToAdd.Id, personToAdd);
            Assert.AreEqual(6, hashTable.Size);
            Assert.AreSame(personToAdd, hashTable.Get(personToAdd.Id));
        }

        [Test]
        public void Can_Add_To_2()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 2; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            var personToAdd = new Person { Id = 15, FirstName = $"Added person", LastName = $"Added person", Age = 25 };
            hashTable.Add(personToAdd.Id, personToAdd);
            Assert.AreEqual(3, hashTable.Size);
            Assert.AreSame(personToAdd, hashTable.Get(personToAdd.Id));
        }

        [Test]
        public void Can_Add_To_1()
        {
            var hashTable = MakeHashTable();
            var person = new Person { Id = 1, FirstName = $"Test{1}", LastName = $"Test{1}", Age = 25 };
            hashTable.Add(person.Id, person);
            var personToAdd = new Person { Id = 15, FirstName = $"Added person", LastName = $"Added person", Age = 25 };
            hashTable.Add(personToAdd.Id, personToAdd);
            Assert.AreEqual(2, hashTable.Size);
            Assert.AreSame(personToAdd, hashTable.Get(personToAdd.Id));
        }

        [Test]
        public void Can_Add_To_0()
        {
            var hashTable = MakeHashTable();
            var personToAdd = new Person { Id = 15, FirstName = $"Added person", LastName = $"Added person", Age = 25 };
            hashTable.Add(personToAdd.Id, personToAdd);
            Assert.AreEqual(1, hashTable.Size);
            Assert.AreSame(personToAdd, hashTable.Get(personToAdd.Id));
        }

        [Test]
        public void Can_Add_To_Null()
        {
            var person = MakeHashTable();
            person = null;
            Assert.Throws<NullReferenceException>(() => person.Add(8, new Person()));
        }
        #endregion

        #region Del
        [Test]
        public void Can_Del_From_Many()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 5; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            var personToAdd = new Person { Id = 15, FirstName = $"Added person", LastName = $"Added person", Age = 25 };
            hashTable.Add(personToAdd.Id, personToAdd);
            var result = hashTable.Del(personToAdd.Id);
            Assert.IsTrue(result);
            Assert.AreEqual(5, hashTable.Size);
        }

        [Test]
        public void Can_Del_From_2()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 2; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            var personToAdd = new Person { Id = 15, FirstName = $"Added person", LastName = $"Added person", Age = 25 };
            hashTable.Add(personToAdd.Id, personToAdd);
            var result = hashTable.Del(personToAdd.Id);
            Assert.IsTrue(result);
            Assert.AreEqual(2, hashTable.Size);
        }

        [Test]
        public void Can_Del_From_1()
        {
            var hashTable = MakeHashTable();
            var person = new Person { Id = 1, FirstName = $"Test{1}", LastName = $"Test{1}", Age = 25 };
            hashTable.Add(person.Id, person);
            var result = hashTable.Del(person.Id);
            Assert.IsTrue(result);
            Assert.AreEqual(0, hashTable.Size);
        }

        [Test]
        public void Can_Del_From_0()
        {
            var hashTable = MakeHashTable();
            Assert.Throws<ArgumentNullException>(() => hashTable.Del(8));
        }

        [Test]
        public void Can_Del_From_Null()
        {
            var person = MakeHashTable();
            person = null;
            Assert.Throws<NullReferenceException>(() => person.Del(8));
        }
        #endregion

        #region Get
        [Test]
        public void Can_Get_Of_Many()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 5; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            var personToAdd = new Person { Id = 15, FirstName = $"Added person", LastName = $"Added person", Age = 25 };
            hashTable.Add(personToAdd.Id, personToAdd);
            Assert.AreSame(personToAdd, hashTable.Get(personToAdd.Id));
        }

        [Test]
        public void Can_Get_Of_2()
        {
            var hashTable = MakeHashTable();
            var person = new Person { Id = 1, FirstName = $"Test{1}", LastName = $"Test{1}", Age = 25 };
            hashTable.Add(person.Id, person);
            var personToAdd = new Person { Id = 15, FirstName = $"Added person", LastName = $"Added person", Age = 25 };
            hashTable.Add(personToAdd.Id, personToAdd);
            Assert.AreSame(personToAdd, hashTable.Get(personToAdd.Id));
        }

        [Test]
        public void Can_Get_Of_1()
        {
            var hashTable = MakeHashTable();
            var person = new Person { Id = 1, FirstName = $"Test{1}", LastName = $"Test{1}", Age = 25 };
            hashTable.Add(person.Id, person);
            Assert.AreSame(person, hashTable.Get(person.Id));
        }

        [Test]
        public void Can_Get_Of_0()
        {
            var hashTable = MakeHashTable();
            Assert.Throws<ArgumentNullException>(() => hashTable.Get(0));
        }

        [Test]
        public void Can_Get_Null()
        {
            var person = MakeHashTable();
            person = null;
            Assert.Throws<NullReferenceException>(() => person.Get(0));
        }
        #endregion

        #region ToArray
        [Test]
        public void Can_Call_ToArray_Of_Many()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 5; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            var result = hashTable.ToArray();
            Assert.AreEqual(5, result.Length);
            Assert.AreEqual(2, result[2].Id);

        }

        [Test]
        public void Can_Call_ToArray_Of_2()
        {
            var hashTable = MakeHashTable();
            for (var i = 0; i < 2; i++)
            {
                var person = new Person { Id = i, FirstName = $"Test{i}", LastName = $"Test{i}", Age = 25 + i };
                hashTable.Add(person.Id, person);
            }
            var result = hashTable.ToArray();
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(1, result[1].Id);
        }

        [Test]
        public void Can_Call_ToArray_Of_1()
        {
            var hashTable = MakeHashTable();
            var person = new Person { Id = 1, FirstName = $"Test{1}", LastName = $"Test{1}", Age = 25 };
            hashTable.Add(person.Id, person);
            var result = hashTable.ToArray();
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(1, result[0].Id);
        }

        [Test]
        public void Can_Call_ToArray_Of_0()
        {
            var hashTable = MakeHashTable();
            Assert.Throws<ArgumentNullException>(() => hashTable.ToArray());
        }

        [Test]
        public void Can_Call_ToArray_Of_Null()
        {
            var person = MakeHashTable();
            person = null;
            Assert.Throws<NullReferenceException>(() => person.ToArray());
        }
        #endregion
    }
}
