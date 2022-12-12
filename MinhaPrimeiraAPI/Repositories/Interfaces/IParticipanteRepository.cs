using MinhaPrimeiraAPI.Models;

namespace MinhaPrimeiraAPI.Repositories.Interfaces
{
    // "Interface" contém apenas as assinaturas de métodos.
    public interface IParticipanteRepository
    {
        IEnumerable<Participante> GetAll();
    }
}