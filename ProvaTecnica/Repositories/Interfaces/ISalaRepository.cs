using ProvaTecnica.Models;
using ProvaTecnica.Models.Dto;

namespace ProvaTecnica.Repositories.Interfaces
{
    public interface ISalaRepository
    {
        public Task<IEnumerable<SalaDto>> GetSalasAsinc();
        public Task<SalaDto?> GetSalaByIdAsync(int id);
        public Task<Sala?> GetSalaById(int id);
        public Task<Sala?> GetSalaByName(string name);
        public Task<Sala?> GetSalaAgendamentoById(int id);

        public void AddSala(Sala sala);
        public void UpdateSala(Sala sala);
        public void DeleteSala(Sala sala);
        Task<bool> SaveChangesAsync();
    }
}
