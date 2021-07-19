using MHP.Books.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MHP.Books.Data.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Price)
             .IsRequired()
             .HasColumnType("numeric(18,2)");

            // 1 : N => Book : Specifications
            builder.HasMany(f => f.Specifications)
                .WithOne(p => p.Book)
                .HasForeignKey(p => p.BookId);

            builder.ToTable("Books");
        }
    }
}