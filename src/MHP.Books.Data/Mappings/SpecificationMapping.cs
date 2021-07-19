using MHP.Books.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MHP.Books.Data.Mappings
{
   
    public class SpecificationMapping : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.OriginallyPublished)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Author)
             .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.PageCount)
           .IsRequired()
             .HasColumnType("int");

            // 1 : N => Specification : Illustrators
            builder.HasMany(i => i.Illustrators)
                .WithOne(s => s.Specification)
                .HasForeignKey(s => s.SpecificationId);

            // 1 : N => Specification : Genres
            builder.HasMany(g => g.Genres)
                .WithOne(s => s.Specification)
                .HasForeignKey(s => s.SpecificationId);

            builder.ToTable("Specifications");
        }
    }
}