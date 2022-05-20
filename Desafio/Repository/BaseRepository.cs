using Desafio.Context;
using Desafio.Repository.Interfaces;

namespace Desafio.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AnuncioContext _context;

        public BaseRepository(AnuncioContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
