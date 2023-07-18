using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviews.Models;

namespace Reviews.Data.Map
{
    public class DepoimentoMap : IEntityTypeConfiguration<Depoimento>
    {
        public void Configure(EntityTypeBuilder<Depoimento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DepoimentoTexto).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.FotoPessoa).IsRequired().HasColumnType("blob");
        }
    }
}
