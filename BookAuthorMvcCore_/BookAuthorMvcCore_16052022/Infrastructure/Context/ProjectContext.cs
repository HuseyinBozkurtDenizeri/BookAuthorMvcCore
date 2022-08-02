using BookAuthorMvcCore_16052022.Models.Entities.Concrete;
using BookAuthorMvcCore_16052022.Models.TypeConfigurations.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Infrastructure.Context
{
    public class ProjectContext :DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) :base(options)
        {
            // asp.net te burada ConnectionStringimizi söylüyorduk fakat CORE da sabitleriizi AppSetting.json da yazıp startup da kullanıp çağıracağız.
            // parametreli kondtrukturda eğer başka veritabanı bağğlantımız seçeneklerimz olusa onları da sana parametr olarak verriz atana yani base gönder demiş olduk.
        }


        public DbSet<Book> Books { get; set; }

        public DbSet<Detail> Details { get; set; }

        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DetailTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
