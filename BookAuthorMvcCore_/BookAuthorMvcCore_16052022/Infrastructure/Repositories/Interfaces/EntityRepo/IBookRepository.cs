using BookAuthorMvcCore_16052022.Infrastructure.Repositories.Interfaces.IBaseRepo;
using BookAuthorMvcCore_16052022.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Infrastructure.Repositories.Interfaces.EntityRepo
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        
       
    }
}
