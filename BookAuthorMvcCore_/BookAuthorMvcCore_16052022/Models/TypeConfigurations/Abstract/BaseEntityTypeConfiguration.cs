using BookAuthorMvcCore_16052022.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Models.TypeConfigurations.Abstract
{
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        // IEntityTypeConfiguration  bu arayüzü bze teslim edecek olan yapı EFCORE dur. Bu uygulamada veritabanı kullanacağımız için mic.efcore.sqlServer paketini indirmeyi tercih ettik ve EFCORE zaten içeriisnde gömülü geldi.

        // Paketleri indirirken kendi içlerinde uyumlu olmalırına ve paketlein prooje sürümüyle uyumlu olmalarına dikkat edilmelidir.
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            // asp.net projelerinde yapılan konfigurasyonlar conctructor içinde yapılır fakat burada ise configure metotunun içinde yapılacaktır.


            builder.HasKey(a => a.ID);

            builder.Property(a => a.CreatedDate).HasColumnType("datetime2").IsRequired(true);
            builder.Property(a => a.UpdateDate).HasColumnType("datetime2").IsRequired(false);
            builder.Property(a => a.DeletedDate).HasColumnType("datetime2").IsRequired(false);
            builder.Property(a => a.Statu).IsRequired(true);

            // burada isOptional bulunmamakta. isRequired(false) => nullable , isRequired(true) => not null,boş bırakılamz alan.
        }


    }
}
