using LocadoraFilmes.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFilmes.Data
{
    public class BancoContext : DbContext
    {

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<FilmeModel> Filmes { get; set; }
        public DbSet<AluguelModel> Alugueis { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }


    }
}
