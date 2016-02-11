using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IBllUnitOfWork
    {
        IService<PersonDTO> PersonsService { get; }
    }
}
