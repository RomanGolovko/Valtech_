using System.Collections.Generic;
using System.Linq;
using BLL.Concrete;
using BLL.DTO;
using Cross_Cutting.Security;
using DAL.DB.Abstract;
using DAL.Entities;
using Moq;
using NUnit.Framework;

namespace PersonCRM.Tests.BLL.Tests
{
    [TestFixture]
    public class PersonServiceTests
    {
        #region Init
        private readonly PersonDTO _persDto1 = new PersonDTO
        {
            Id = 1,
            FirstName = "test1",
            LastName = "test1",
            Age = 10,
            Phones = new List<PhoneDTO>
                {
                    new PhoneDTO {Id = 1, Number = "111-111", Type = "test1", PersonId = 1},
                    new PhoneDTO {Id = 2, Number = "111-222", Type = "test2", PersonId = 1}
                }
        };

        private readonly PersonDTO _persDto2 = new PersonDTO
        {
            Id = 2,
            FirstName = "test2",
            LastName = "test2",
            Age = 20,
            Phones = new List<PhoneDTO>
                {
                    new PhoneDTO {Id = 3, Number = "222-222", Type = "test3", PersonId = 2}
                }
        };

        private readonly PersonDTO _persDto3 = new PersonDTO
        {
            Id = 3,
            FirstName = "test3",
            LastName = "test3",
            Age = 30,
            Phones = new List<PhoneDTO>
                {
                    new PhoneDTO {Id = 4, Number = "333-333", Type = "test4", PersonId = 3}
                }
        };

        private readonly PersonDTO _persDto4 = new PersonDTO
        {
            Id = 4,
            FirstName = "test4",
            LastName = "test4",
            Age = 40,
            Phones = new List<PhoneDTO>
                {
                    new PhoneDTO {Id = 5, Number = "444-444", Type = "test5", PersonId = 4}
                }
        };

        private readonly PersonDTO _persDto5 = new PersonDTO
        {
            Id = 5,
            FirstName = "test5",
            LastName = "test5",
            Age = 50,
            Phones = null
        };

        private readonly Person _pers1 = new Person
        {
            Id = 1,
            FirstName = "test1",
            LastName = "test1",
            Age = 10,
            Phones = new List<Phone>
                {
                    new Phone {Id = 1, Number = "111-111", Type = "test1", Person = null, PersonId = 1},
                    new Phone {Id = 2, Number = "111-222", Type = "test2", Person = null, PersonId = 1}
                }
        };

        private readonly Person _pers2 = new Person
        {
            Id = 2,
            FirstName = "test2",
            LastName = "test2",
            Age = 20,
            Phones = new List<Phone>
                {
                    new Phone {Id = 3, Number = "222-222", Type = "test3", Person = null, PersonId = 2},
                }
        };

        private readonly Person _pers3 = new Person
        {
            Id = 3,
            FirstName = "test3",
            LastName = "test3",
            Age = 30,
            Phones = new List<Phone>
                {
                    new Phone {Id = 4, Number = "333-333", Type = "test4", Person = null, PersonId = 3},
                }
        };

        private readonly Person _pers4 = new Person
        {
            Id = 4,
            FirstName = "test4",
            LastName = "test4",
            Age = 40,
            Phones = new List<Phone>
                {
                    new Phone {Id = 5, Number = "444-444", Type = "test5", Person = null, PersonId = 4},
                }
        };

        private readonly Person _pers5 = new Person
        {
            Id = 5,
            FirstName = "test5",
            LastName = "test5",
            Age = 50,
            Phones = null
        };
        #endregion

        #region GetAllPersons
        [Test]
        public void Get_All_Persons_From_Db_With_Many_Persons()
        {
            var expected = new List<PersonDTO> { _persDto1, _persDto2, _persDto3, _persDto4, _persDto5 };

            _pers1.Phones[0].Person = _pers1;
            _pers1.Phones[1].Person = _pers1;
            _pers2.Phones[0].Person = _pers2;
            _pers3.Phones[0].Person = _pers3;
            _pers4.Phones[0].Person = _pers4;

            var persons = new List<Person> { _pers1, _pers2, _pers3, _pers4, _pers5 };

            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Persons.GetAll()).Returns(persons);
            var personService = new PersonService(mock.Object);

            var result = personService.GetAllPersons().ToList();

            Assert.IsInstanceOf<IEnumerable<PersonDTO>>(result);
            CollectionAssert.AreEqual("$" + expected, "$" + result);
        }

        [Test]
        public void Get_All_Persons_From_Db_With_2_Persons()
        {
            var expected = new List<PersonDTO> { _persDto1, _persDto2 };

            _pers1.Phones[0].Person = _pers1;
            _pers1.Phones[1].Person = _pers1;
            _pers2.Phones[0].Person = _pers2;

            var persons = new List<Person> { _pers1, _pers2 };

            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Persons.GetAll()).Returns(persons);
            var personService = new PersonService(mock.Object);

            var result = personService.GetAllPersons().ToList();

            Assert.IsInstanceOf<IEnumerable<PersonDTO>>(result);
            CollectionAssert.AreEqual("$" + expected, "$" + result);
        }

        [Test]
        public void Get_All_Persons_From_Db_With_1_Person()
        {
            var expected = new List<PersonDTO> { _persDto1 };
            _pers1.Phones[0].Person = _pers1;

            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Phones.GetAll())
                .Returns(new List<Phone>
                {
                    new Phone {Id = 1, Number = "111-111", Type = "test", PersonId = 1, Person = _pers1}
                });
            mock.Setup(p => p.Persons.GetAll()).Returns(new List<Person> { _pers1 });
            var personService = new PersonService(mock.Object);

            var result = personService.GetAllPersons().ToList();
            Assert.IsInstanceOf<IEnumerable<PersonDTO>>(result);
            CollectionAssert.AreEqual("$" + expected, "$" + result);
        }

        [Test]
        public void Get_All_Persons_From_Empty_Db()
        {
            var expected = new List<PersonDTO>();
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(p => p.Persons.GetAll()).Returns(new List<Person>());
            var personService = new PersonService(mock.Object);

            var result = personService.GetAllPersons();
            Assert.IsInstanceOf<IEnumerable<PersonDTO>>(result);
            CollectionAssert.AreEqual("$" + expected, "$" + result);
        }
        #endregion

        #region GetPerson
        [Test]
        public void Get_Existing_Person()
        {
            _pers1.Phones[0].Person = _pers1;
            _pers1.Phones[1].Person = _pers1;
            _pers2.Phones[0].Person = _pers2;
            _pers3.Phones[0].Person = _pers3;
            _pers4.Phones[0].Person = _pers4;

            var persons = new List<Person> { _pers1, _pers2, _pers3, _pers4, _pers5 };
            var id = 3;
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Persons.Get(id)).Returns(persons.Find(x => x.Id == id));
            var personService = new PersonService(mock.Object);

            var result = personService.GetPerson(id);

            Assert.AreEqual("$" + _persDto3, "$" + result);
        }

        [Test]
        public void Get_Person_With_OutOfRange_Id()
        {
            _pers1.Phones[0].Person = _pers1;
            _pers1.Phones[1].Person = _pers1;
            _pers2.Phones[0].Person = _pers2;
            _pers3.Phones[0].Person = _pers3;
            _pers4.Phones[0].Person = _pers4;

            var persons = new List<Person> { _pers1, _pers2, _pers3, _pers4, _pers5 };
            var id = 8;
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Persons.Get(id)).Returns(persons.Find(x => x.Id == id));
            var personService = new PersonService(mock.Object);

            Assert.Throws<ValidationException>(() => personService.GetPerson(id));
        }

        [Test]
        public void Get_Person_With_Null_Id_Parameter()
        {
            var mock = new Mock<IUnitOfWork>();
            var personService = new PersonService(mock.Object);

            Assert.Throws<ValidationException>(() => personService.GetPerson(null));
        }
        #endregion

        #region SavePerson
        [Test]
        public void Save_Person()
        {
            var persons = new List<Person> { _pers1 };
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Persons.Create(_pers1)).Verifiable();
            mock.Setup(x => x.Persons.Update(_pers1)).Verifiable();
            mock.Setup(x => x.Phones.Update(_pers1.Phones[0])).Verifiable();
            mock.Setup(x => x.Phones.Update(_pers1.Phones[1])).Verifiable();
            mock.Setup(x => x.Persons.Get(_pers1.Id)).Returns(persons.Find(x => x.Id == _pers1.Id));
            var personService = new PersonService(mock.Object);

            personService.SavePerson(_persDto1);
        }
        #endregion

        #region DeletePerson
        [Test]
        public void Delete_Person_From_Db_With_Many_Persons()
        {
            var persons = new List<Person> { _pers1, _pers2, _pers3, _pers4, _pers5 };
            var phones = new List<Phone>
            {
                _pers1.Phones[0],
                _pers1.Phones[1],
                _pers2.Phones[0],
                _pers3.Phones[0],
                _pers4.Phones[0]
            };
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Persons.Delete(_pers1.Phones[1].Id)).Verifiable();
            mock.Setup(x => x.Persons.Get(_pers1.Id)).Returns(persons.Find(x => x.Id == _pers1.Id));
            mock.Setup(x => x.Phones.Get(_pers1.Phones[1].Id)).Returns(phones.Find(x => x.Id == _pers1.Phones[1].Id));
            var personService = new PersonService(mock.Object);

            personService.DeletePerson(_persDto1.Id);
        }

        [Test]
        public void Delete_Person_From_Db_With_0_Persons()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(x => x.Persons.Get(2));
            var personService = new PersonService(mock.Object);

           Assert.Throws<ValidationException>(() => personService.DeletePerson(2));
        }
        #endregion
    }
}
