using ProvaTecnica.Models;
using ProvaTecnica.Models.Dto;
using ProvaTecnica.Models.InputModel;
using ProvaTecnica.Models.ViewModel;
using ProvaTecnica.Repositories.Interfaces;
using ProvaTecnica.Services.Interfaces;

namespace ProvaTecnica.Services.Services
{
    public class SalaServices : ISalaServices
    {

        private readonly ISalaRepository _salaRepository;
        public SalaServices(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }


        public async Task<ResponseViewModel<IEnumerable<SalaDto>>> GetListaSalas()
        {
            var salas = await _salaRepository.GetSalasAsinc();
            var sucesso = salas.Any();

            return new ResponseViewModel<IEnumerable<SalaDto>>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados das salas retornados com sucesso!" : "Nenhum dado encontrado.",
                Data = sucesso ? salas : null
            };
        }

        public async Task<ResponseViewModel<SalaDto?>> GetSalaById(int id)
        {
            var sala = await _salaRepository.GetSalaByIdAsync(id);
            var sucesso = sala != null;

            return new ResponseViewModel<SalaDto?>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados da sala retornados com sucesso!" : "Nenhum dado encontrado.",
                Data = sucesso ? sala : null
            };
        }        

        

        public async Task<ResponseViewModel<string>> PostSala(SalaInputModel sala)
        {
            var sucesso = sala != null;

            if (sucesso)
            {
                var responseSala = await _salaRepository.GetSalaByName(sala.Nome);

                if(responseSala != null)
                {
                    return new ResponseViewModel<string>
                    {
                        Status = false,
                        Msg = "Já existe uma sala cadastrada com esse nome."
                    };
                }

                var novaSala = new Sala
                {
                    Nome = sala.Nome,
                    Ativo = true,
                };

                _salaRepository.AddSala(novaSala);
                sucesso = await _salaRepository.SaveChangesAsync();                
            }

            return new ResponseViewModel<string>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados da sala cadastrado com sucesso!" : "Erro ao cadastrar os dados da sala."
            };
        }

        public async Task<ResponseViewModel<string>> PutSala(int id, SalaInputModel sala)
        {
            var responseSala = await _salaRepository.GetSalaById(id);
            if (responseSala == null)
            {
                return new ResponseViewModel<string>
                {
                    Status = false,
                    Msg = "Erro: Não foi encontrado nenhum registro com esse ID"
                };
            }

            responseSala.Nome = sala.Nome;
            responseSala.Ativo = sala.Ativo;
            responseSala.DataAtualizacao = DateTime.Now;

            _salaRepository.UpdateSala(responseSala);
            var sucesso = await _salaRepository.SaveChangesAsync();

            return new ResponseViewModel<string>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados da sala atualizados com sucesso!" : "Erro ao atualizar os dados da sala."
            };
        }

        public async Task<ResponseViewModel<string>> DeleteSala(int id)
        {
            var responseSala = await _salaRepository.GetSalaById(id);
            if (responseSala == null)
            {
                return new ResponseViewModel<string>
                {
                    Status = false,
                    Msg = "Erro: Não foi encontrado nenhum registro com esse ID"
                };
            }

            _salaRepository.DeleteSala(responseSala);
            var sucesso = await _salaRepository.SaveChangesAsync();

            return new ResponseViewModel<string>
            {
                Status = sucesso,
                Msg = sucesso ? "Dados da sala eliminados com sucesso!" : "Erro ao eliminar os dados da sala."
            };
        }

    }
}
