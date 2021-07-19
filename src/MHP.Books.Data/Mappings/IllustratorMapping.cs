using MHP.Books.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MHP.Books.Data.Mappings
{
   
    public class IllustratorMapping : IEntityTypeConfiguration<Illustrator>
    {
        public void Configure(EntityTypeBuilder<Illustrator> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Illustrators");
        }
    }
}
