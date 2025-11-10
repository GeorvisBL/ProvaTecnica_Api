using ProvaTecnica.Models.Dto;
using ProvaTecnica.Models.InputModel;
using ProvaTecnica.Models.ViewModel;

namespace ProvaTecnica.Services.Interfaces
{
    public interface ISalaServices
    {
        Task<ResponseViewModel<IEnumerable<SalaDto>>> GetListaSalas();
        Task<ResponseViewModel<SalaDto?>> GetSalaById(int id);

        Task<ResponseViewModel<string>> PostSala(SalaInputModel sala);
        Task<ResponseViewModel<string>> PutSala(int id, SalaInputModel sala);
        Task<ResponseViewModel<string>> DeleteSala(int id);
    }
}
