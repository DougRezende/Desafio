using Desafio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Context
{
    public class AnuncioContext : DbContext
    {
        public AnuncioContext(DbContextOptions<AnuncioContext> options) : base(options)
        {
        }

        public DbSet<Anuncio> Anuncios { get; set; }
    }
}
