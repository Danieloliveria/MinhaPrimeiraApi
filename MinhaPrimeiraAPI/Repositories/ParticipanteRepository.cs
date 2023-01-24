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

        public IEnumerable<Participante> GetAllAsync()
        {
            return applicationDbContext.Participantes.AsNoTracking().ToList();
        }

        public async Task<Participante> PostAsync(Participante participante)
        {
            applicationDbContext.Participantes.Add(participante);
            await applicationDbContext.SaveChangesAsync();
            return participante;
        }

        public async Task<Participante> PutAsync(Participante participante)
        {
            applicationDbContext.Participantes.Update(participante);
            await applicationDbContext.SaveChangesAsync();
            return participante;
        }

        public async Task<Participante> DeleteAsync(Guid id)
        {
            Participante consultaParticipante = await GetByIdAsync(id);

            if (consultaParticipante is not null)
            {
                applicationDbContext.Remove(consultaParticipante);
                await applicationDbContext.SaveChangesAsync();
            }

            return consultaParticipante;
        }

        public async Task<Participante> GetByIdAsync(Guid id)
        {
            // Task<Participante> consultaParticipante = applicationDbContext.Participantes.Where(participante => participante.Id == id).FirstOrDefaultAsync();

            Task<Participante> consultaParticipante = applicationDbContext.Participantes.FirstOrDefaultAsync(participante => participante.Id == id);
            return await consultaParticipante;
        }

        public async Task<IList<Participante>> GetByNomeAsync(string nome)
        {
            Task<List<Participante>> consultaNomeParticipante = applicationDbContext.Participantes.Where(participante => EF.Functions.Like(participante.Nome, $"%{nome}%")).ToListAsync();
            return await consultaNomeParticipante;
        }
    }
}