using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoCadastroDeFamilias.Models;

namespace ProjetoCadastroDeFamilias.Data.Map
{
    public class FamiliaMap : IEntityTypeConfiguration<FamiliaModel>
    {
        public void Configure(EntityTypeBuilder<FamiliaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeFamilia).IsRequired().HasMaxLength(255);
            builder.Property(x => x.QuantidadeDePessoas).IsRequired();
        }
    }
}
