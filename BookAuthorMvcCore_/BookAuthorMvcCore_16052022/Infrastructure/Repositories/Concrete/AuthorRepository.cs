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
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
    }
}
