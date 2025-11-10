using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Context;
using ProvaTecnica.Models;
using ProvaTecnica.Models.Dto;
using ProvaTecnica.Repositories.Interfaces;

namespace ProvaTecnica.Repositories.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {

        private readonly DBContext _context;
        public AgendamentoRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<AgendamentoDto>> GetAgendamentosAsync()
        {
            var response = await _context.Agendamentos
                .Select(a => new AgendamentoDto
                {
                    Id = a.Id,
                    SalaId = a.SalaId,
                    DataAgendamento = a.DataAgendamento.ToString("dd/MM/yyyy"),
                    HoraInicio = a.HoraInicio.ToString("HH:mm"),
                    HoraFim = a.HoraFim.ToString("HH:mm"),
                    Cafe = a.Cafe,
                    CafeQuantidade = a.CafeQuantidade,
                    CafeDescricao = a.CafeDescricao,
                    Responsavel = a.Responsavel,
                    DataCriacao = a.DataCriacao.ToString("dd/MM/yyyy"),

                })
                .ToListAsync();

            return response;
        }

        public async Task<AgendamentoDto?> GetAgendamentoByIdAsync(int id)
        {
            var response = await _context.Agendamentos
                .Where(a => a.Id == id)
                .Select(a => new AgendamentoDto
                {
                    Id = a.Id,
                    SalaId = a.SalaId,
                    DataAgendamento = a.DataAgendamento.ToString("dd/MM/yyyy"),
                    HoraInicio = a.HoraInicio.ToString("HH:mm"),
                    HoraFim = a.HoraFim.ToString("HH:mm"),
                    Cafe = a.Cafe,
                    CafeQuantidade = a.CafeQuantidade,
                    CafeDescricao = a.CafeDescricao,
                    Responsavel = a.Responsavel,
                    DataCriacao = a.DataCriacao.ToString("dd/MM/yyyy"),
                })
                .FirstOrDefaultAsync();

            return response;
        }

        public async Task<Agendamento?> GetAgendamentoById(int id)
        {
            return await _context.Agendamentos
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Agendamento?> GetAgendamentoExistente(int salaId, DateOnly dataAgendamento, TimeOnly horaInicio, TimeOnly horaFim)
        {
            var response = await _context.Agendamentos
                .Where(a => a.SalaId != salaId &&
                    a.DataAgendamento == dataAgendamento &&
                    a.HoraInicio < horaFim &&
                    a.HoraFim > horaInicio)
                .FirstOrDefaultAsync();

            return response;
        }



        public void AddAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
        }

        public void UpdateAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);
        }

        public void DeleteAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Remove(agendamento);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
