using Asistec.API.Entities;

namespace Asistec.API.Repositories
{
    public interface IPersonalRepository
    {
        Task<Personal> GetPersonal(string idPersonal);
        Task<bool> CreatePersonal(Personal personal);
        Task<bool> UpdatePersonal(Personal personal);
        Task<bool> DeletePersonal(string idPersonal);
    }
}
