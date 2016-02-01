using DAL.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB.Concrete.MSSQL.NHibernate
{
    public class PhoneMap : ClassMap<Phone>
    {
        public PhoneMap()
        {
            Id(x => x.Id);
            Map(x => x.Number);
            Map(x => x.Type);
            References(x => x.Person);

            Table("NPhones");
        }
    }
}
