using BookAuthorMvcCore_16052022.Models.Entities.Concrete;
using BookAuthorMvcCore_16052022.Models.TypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Models.TypeConfigurations.Concrete
{
    public class AuthorTypeConfiguration : BaseEntityTypeConfiguration<Author>
    {

        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            //klaıtım alınan sınıftaki CONFIGURE metot VIRTUAL olarak işaretlendiği için istendiği takdirde ezilebilir haldedir.
            // AuthorConfire ederken hem atamızdan gelenleri görürüz hem ezip içini doldurduğumuz metotu hörüp kullanmış oluruz.

            builder.Property(a => a.LastName).IsRequired(true);
            builder.Property(a => a.FirstName).IsRequired(true);




            base.Configure(builder);
            // bu kod bloğu en sonda kalacak şekilde bırakılır ki öncesimde söylenenler atasına gönderisin (aynı onModelCreatingde olduğu gibi)
        }
    }
}
