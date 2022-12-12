using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraAPI.Context;
using MinhaPrimeiraAPI.Models;
using MinhaPrimeiraAPI.Repositories.Interfaces;

namespace MinhaPrimeiraAPI.Repositories
{
    // "Repository" persistência para gravar e recuperar os dados necessários no banco de dados.
    public class ParticipanteRepository : IParticipanteRepository
    {
        private readonly AppDbContext applicationDbContext;

        public ParticipanteRepository(AppDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Participante> GetAll()
        {
            return applicationDbContext.Participantes.AsNoTracking().ToList();
        }
    }
}