using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IBllUnitOfWork
    {
        IService<PersonDTO> PersonsService { get; }
        IService<StreetDTO> StreetsService { get; }
        IService<CityDTO> CitiesService { get; }
        IService<CountryDTO> CountriesService { get; }
    }
}
