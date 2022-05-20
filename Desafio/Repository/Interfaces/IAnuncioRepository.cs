using Desafio.Models.Entities;

namespace Desafio.Repository.Interfaces
{
    public interface IAnuncioRepository : IBaseRepository
    {
        Task<IEnumerable<Anuncio>> GetAnunciosAsync();
        Task<Anuncio> GetByIdAsync(int id);
        Task<Anuncio> PutAsync(int id);
        Task<Anuncio> DeleteAsync(int id);
    }
}
