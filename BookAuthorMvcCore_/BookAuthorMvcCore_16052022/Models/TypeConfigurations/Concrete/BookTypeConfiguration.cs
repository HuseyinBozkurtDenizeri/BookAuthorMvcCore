using BookAuthorMvcCore_16052022.Models.Entities.Concrete;
using BookAuthorMvcCore_16052022.Models.TypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Models.TypeConfigurations.Concrete
{
    public class BookTypeConfiguration :BaseEntityTypeConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(a => a.Name).IsRequired(true);
            builder.Property(a => a.Description).HasMaxLength(200).IsRequired(true);

            builder.HasOne(a => a.BooksDetail).WithOne(a => a.DetailsBook).HasForeignKey<Detail>(a => a.BookID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            // deleteBehavior(silinme davranışı). CASCADE olan ilişkide nesnelerden biri silindğinde diğeride silinir(1-1 ilişkililer). NOACTION => biri silindiğinde diğeri kalsın.

            builder.HasOne(a => a.BooksAuthor).WithMany(a => a.AuthorBooks).HasForeignKey(a => a.AuthorID);


            base.Configure(builder);
        }
    }
}
