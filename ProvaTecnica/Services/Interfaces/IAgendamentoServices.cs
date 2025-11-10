using ProvaTecnica.Models.Dto;
using ProvaTecnica.Models.InputModel;
using ProvaTecnica.Models.ViewModel;

namespace ProvaTecnica.Services.Interfaces
{
    public interface IAgendamentoServices
    {
        Task<ResponseViewModel<IEnumerable<AgendamentoDto>>> GetListaAgendamentos();
        Task<ResponseViewModel<AgendamentoDto?>> GetAgendamentoById(int id);

        Task<ResponseViewModel<string>> PostAgendamento(AgendamentoInputModel agendamento);
        Task<ResponseViewModel<string>> PutAgendamento(int id, AgendamentoInputModel agendamento);
        Task<ResponseViewModel<string>> DeleteAgendamento(int id);
    }
}
