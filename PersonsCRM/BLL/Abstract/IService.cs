using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Abstract
{
    public interface IService
    {
        PersonDTO GetPerson(int? id);
        IEnumerable<PersonDTO> GetAllPersons();
        void SavePerson(PersonDTO person);
        //void SavePhone(int? personId, PhoneDTO phone);
        void DeletePerson(int? id);
        //void DeletePhone(int? personId, int? id);
    }
}
