using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IBllUnitOfWork
    {
        IService<PersonDTO> Persons { get; } 
        IService<StreetDTO> Streets { get; } 
    }
}
