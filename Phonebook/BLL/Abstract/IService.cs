using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IService
    {
        PersonDTO GetPerson(int? id);
        IEnumerable<PersonDTO> GetAllPersons();
        void SavePerson(PersonDTO person);
        void DeletePerson(int? id);
    }
}
