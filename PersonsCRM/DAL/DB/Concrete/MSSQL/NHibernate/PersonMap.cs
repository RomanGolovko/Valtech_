using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.DB.Concrete.MSSQL.NHibernate
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Age);
            HasMany(x => x.Phones).Cascade.All().Not.LazyLoad();

            Table("Persons");
        }
    }
}
