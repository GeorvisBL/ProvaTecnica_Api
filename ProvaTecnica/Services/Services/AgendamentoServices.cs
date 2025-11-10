using System.Globalization;
using ProvaTecnica.Models;
using ProvaTecnica.Models.Dto;
using ProvaTecnica.Models.InputModel;
using ProvaTecnica.Models.ViewModel;
using ProvaTecnica.Repositories.Interfaces;
using ProvaTecnica.Services.Interfaces;

namespace ProvaTecnica.Services.Services
{
    public class AgendamentoServices : IAgendamentoServices
    {

        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly ISalaRepository _salaRepository;
        public AgendamentoServices(IAgendamentoRepository agendamentoRepository, ISalaRepository salaRepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _salaRepository = salaRepository;
        }



        public async Task<ResponseViewModel<IEnumerable<AgendamentoDto>>> GetListaAgendamentos()
        {
            var agendamentos = await _agendamentoRepository.GetAgendamentosAsync();
            var sucesso = agendamentos.Any();

            return new ResponseViewModel<IEnumerable<AgendamentoDto>>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados de agendamentos retornados com sucesso!" : "Nenhum dado encontrado.",
                Data = sucesso ? agendamentos : null
            };
        }

        public async Task<ResponseViewModel<AgendamentoDto?>> GetAgendamentoById(int id)
        {
            var agendamento = await _agendamentoRepository.GetAgendamentoByIdAsync(id);
            var sucesso = agendamento != null;

            return new ResponseViewModel<AgendamentoDto?>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados do agendamento retornados com sucesso!" : "Nenhum dado encontrado.",
                Data = sucesso ? agendamento : null
            };
        }



        public async Task<ResponseViewModel<string>> PostAgendamento(AgendamentoInputModel agendamento)
        {
            if (agendamento == null)
            {
                return new ResponseViewModel<string>
                {
                    Status = false,
                    Msg = "Erro: Dados do agendamento não foram informados."
                };
            }

            var sala = await _salaRepository.GetSalaById(agendamento.SalaId);
            if (sala == null)
            {
                return new ResponseViewModel<string>
                {
                    Status = false,
                    Msg = "Erro: Nenhuma sala encontrada com o ID informado."
                };
            }

            DateOnly.TryParseExact(agendamento.DataAgendamento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataAgendamento);
            TimeOnly.TryParseExact(agendamento.HoraInicio, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horaInicio);
            TimeOnly.TryParseExact(agendamento.HoraFim, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horaFim);
            
            if (horaFim <= horaInicio)
            {
                return new ResponseViewModel<string>
                {
                    Status = false,
                    Msg = "A hora de término deve ser posterior à hora de início do agendamento."
                };
            }

            var agendamentoExistente = await _agendamentoRepository.GetAgendamentoExistente(
                agendamento.SalaId, dataAgendamento, horaInicio, horaFim);

            if (agendamentoExistente != null)
            {
                return new ResponseViewModel<string>
                {
                    Status = false,
                    Msg = "Já existe uma reserva para esta sala neste horário. Por favor, escolha outro horário ou verifique a agenda disponível."
                };
            }

            var novoAgendamento = new Agendamento
            {
                SalaId = agendamento.SalaId,
                DataAgendamento = dataAgendamento,
                HoraInicio = horaInicio,
                HoraFim = horaFim,
                Cafe = agendamento.Cafe,
                CafeQuantidade = agendamento.Cafe ? agendamento.CafeQuantidade : 0,
                CafeDescricao = agendamento.Cafe ? agendamento.CafeDescricao ?? string.Empty : string.Empty,
                Responsavel = agendamento.Responsavel,
                DataCriacao = DateTime.Now
            };

            _agendamentoRepository.AddAgendamento(novoAgendamento);
            var sucesso = await _agendamentoRepository.SaveChangesAsync();

            return new ResponseViewModel<string>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados do agendamento cadastrado com sucesso!" : "Erro ao cadastrar os dados do agendamento."
            };
        }


        public async Task<ResponseViewModel<string>> PutAgendamento(int id, AgendamentoInputModel agendamento)
        {
            var responseAgendamento = await _agendamentoRepository.GetAgendamentoById(id);
            if (responseAgendamento == null)
            {
                return new ResponseViewModel<string>
                {
                    Status = false,
                    Msg = "Erro: Não foi encontrado nenhum registro com esse ID"
                };
            }

            DateOnly.TryParseExact(agendamento.DataAgendamento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataAgendamento);
            TimeOnly.TryParseExact(agendamento.HoraInicio, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horaInicio);
            TimeOnly.TryParseExact(agendamento.HoraFim, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var horaFim);

            var responseAgendamentoExist = await _agendamentoRepository.GetAgendamentoExistente(agendamento.SalaId, dataAgendamento, horaInicio, horaFim);
            if (responseAgendamentoExist != null)
            {
                return new ResponseViewModel<string>
                {
                    Status = false,
                    Msg = "Já existe uma reserva para esta sala neste horário. Por favor, escolha outro horário ou verifique a agenda disponível."
                };
            }

            responseAgendamento.SalaId = agendamento.SalaId;
            responseAgendamento.DataAgendamento = dataAgendamento;
            responseAgendamento.HoraInicio = horaInicio;
            responseAgendamento.HoraFim = horaFim;
            responseAgendamento.Cafe = agendamento.Cafe;
            responseAgendamento.CafeQuantidade = agendamento.Cafe ? agendamento.CafeQuantidade : 0;
            responseAgendamento.CafeDescricao = agendamento.Cafe ? agendamento.CafeDescricao : string.Empty;
            responseAgendamento.Responsavel = agendamento.Responsavel;
            responseAgendamento.DataAtualizacao = DateTime.Now;

            _agendamentoRepository.UpdateAgendamento(responseAgendamento);
            var sucesso = await _agendamentoRepository.SaveChangesAsync();

            return new ResponseViewModel<string>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados do agendamento atualizados com sucesso!" : "Erro ao atualizar os dados do agendamento."
            };
        }

        public async Task<ResponseViewModel<string>> DeleteAgendamento(int id)
        {
            var responseAgendamento = await _agendamentoRepository.GetAgendamentoById(id);
            if (responseAgendamento == null)
            {
                return new ResponseViewModel<string>
                {
                    Status = false,
                    Msg = "Erro: Não foi encontrado nenhum registro com esse ID"
                };
            }

            _agendamentoRepository.DeleteAgendamento(responseAgendamento);
            var sucesso = await _agendamentoRepository.SaveChangesAsync();

            return new ResponseViewModel<string>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados do agendamento eliminados com sucesso!" : "Erro ao eliminar os dados da agendamento."
            };
        }
    }
}
