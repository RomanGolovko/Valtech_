using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.ADO
{
    public class AdoUnitOfWork : IUnitOfWork
    {
        private AdoPersonRepository _personRepository;
        private AdoPhoneRepository _phoneRepository;

        private string _connectionString = @"Data Source=(LocalDB)\mssqllocaldb;" +
            @"Initial Catalog='D:\GitHub Repository\Valtech_\PersonsCRM\WebUI\App_Data\DAL.DB.Concrete.MSSQL.EF.EfDbContext.mdf';" +
            @"Integrated Security=True";


        public IRepository<Person> Persons => _personRepository ?? (_personRepository = new AdoPersonRepository(_connectionString));

        public IRepository<Phone> Phones => _phoneRepository ?? (_phoneRepository = new AdoPhoneRepository(_connectionString));
    }
}
