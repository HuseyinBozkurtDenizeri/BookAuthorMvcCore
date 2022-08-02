using BookAuthorMvcCore_16052022.Models.Entities.Concrete;
using BookAuthorMvcCore_16052022.Models.TypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Models.TypeConfigurations.Concrete
{
    public class DetailTypeConfiguration : BaseEntityTypeConfiguration<Detail>
    {
        public override void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.Property(a => a.Summary).HasMaxLength(100).IsRequired(true);
            builder.Property(a => a.Description).IsRequired(true);

            // 1 detayın 1 kitabı vardır
            builder.HasOne(a => a.DetailsBook).WithOne(a => a.BooksDetail).HasForeignKey<Book>(a => a.DetailID);

            base.Configure(builder);
        }
    }
}
