using Microsoft.EntityFrameworkCore;
using ProjetoCadastroDeFamilias.Data.Map;
using ProjetoCadastroDeFamilias.Models;

namespace ProjetoCadastroDeFamilias.Data
{
    public class SistemaDeCadastroDBContext : DbContext
    {
        public SistemaDeCadastroDBContext(DbContextOptions<SistemaDeCadastroDBContext> options)
        : base(options)
        {
        }

        public DbSet<FamiliaModel> Familias { get; set; }
        public DbSet<PessoaModel> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FamiliaMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
