using BookAuthorMvcCore_16052022.Infrastructure.Context;
using BookAuthorMvcCore_16052022.Infrastructure.Repositories.Abstract;
using BookAuthorMvcCore_16052022.Infrastructure.Repositories.Interfaces.EntityRepo;
using BookAuthorMvcCore_16052022.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Infrastructure.Repositories.Concrete
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        //  interfaceteki imzasını oluşturmadan gövdesini oluşturduğmuz bir metotun imzasını interface göndermek isteersek 
        // CTRL + . => pull  xrepository diyerek seçtiğimiz interfacete imza halini elde ediyoruz.
        //public string MesajGonder()
        //{
        //    return "fsrfsfs";
        //}

        //Constructure Chaining - Zincirleme Cons. -Enazından  Atanın beklediği parametreli atana göndermelisin.
        public BookRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
    }
}
