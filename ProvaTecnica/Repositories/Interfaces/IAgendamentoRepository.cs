using ProvaTecnica.Models.Dto;
using ProvaTecnica.Models;

namespace ProvaTecnica.Repositories.Interfaces
{
    public interface IAgendamentoRepository
    {
        public Task<IEnumerable<AgendamentoDto>> GetAgendamentosAsync();
        public Task<AgendamentoDto?> GetAgendamentoByIdAsync(int id);
        public Task<Agendamento?> GetAgendamentoById(int id);
        public Task<Agendamento?> GetAgendamentoExistente(int salaId, DateOnly dataAgendamento, TimeOnly horaInicio, TimeOnly horaFim);

        public void AddAgendamento(Agendamento agendamento);
        public void UpdateAgendamento(Agendamento agendamento);
        public void DeleteAgendamento(Agendamento agendamento);
        Task<bool> SaveChangesAsync();
    }
}
