using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Context;
using ProvaTecnica.Models;
using ProvaTecnica.Models.Dto;
using ProvaTecnica.Repositories.Interfaces;

namespace ProvaTecnica.Repositories.Repository
{
    public class SalaRepository : ISalaRepository
    {

        private readonly DBContext _context;
        public SalaRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<SalaDto>> GetSalasAsinc()
        {
            var response = await _context.Salas
                .Select(s => new SalaDto
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Local = s.Local,
                    Ativo = s.Ativo,
                    DataCriacao = s.DataCriacao.ToString("dd/MM/yyyy")
                })
                .ToListAsync();

            return response;
        }

        public async Task<SalaDto?> GetSalaByIdAsync(int id)
        {
            var response = await _context.Salas
                .Where(s => s.Id == id)
                .Select(s => new SalaDto
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Local = s.Local,
                    Ativo = s.Ativo,
                    DataCriacao = s.DataCriacao.ToString("dd/MM/yyyy")
                })
                .FirstOrDefaultAsync();

            return response;
        }

        public async Task<Sala?> GetSalaById(int id)
        {
            return await _context.Salas
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Sala?> GetSalaByName(string name)
        {
            return await _context.Salas
                .Where(s => s.Nome.ToLower() == name.ToLower())
                .FirstOrDefaultAsync();
        }



        public void AddSala(Sala sala)
        {
            _context.Salas.Add(sala);
        }

        public void UpdateSala(Sala sala)
        {
            _context.Salas.Update(sala);
        }

           
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
