using BLL.DTO;

namespace BLL.Abstract
{
    public interface IBllUnitOfWork
    {
        IService<PersonDTO> Persons { get; }
        IService<AddressDTO> Addresses { get; }
    }
}
