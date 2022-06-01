using Asistec.API.Entities;

namespace Asistec.API.Repositories
{
    public interface IPersonalRepository
    {
        Task GetPersonal(int idPersonal);
        Task<bool> CreatePersonal(Personal personal);
        Task<bool> UpdatePersonal(Personal personal);
        Task<bool> DeletePersonal(int idPersonal);
    }
}
