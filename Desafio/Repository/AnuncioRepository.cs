using Desafio.Context;
using Desafio.Models.Entities;
using Desafio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository
{
    public class AnuncioRepository : BaseRepository, IAnuncioRepository
    {
        private readonly AnuncioContext _context;

        public AnuncioRepository(AnuncioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anuncio>> GetAnunciosAsync()
        {
            return await _context.Anuncios.AsNoTracking().ToListAsync();
        }

        public async Task<Anuncio> GetByIdAsync(int id)
        {
            return await _context.Anuncios
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Anuncio> PutAsync(int id)
        {
            return await _context.Anuncios
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Anuncio> DeleteAsync(int id)
        {
            return await _context.Anuncios
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}
