using BookAuthorMvcCore_16052022.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Infrastructure.Repositories.Interfaces.IBaseRepo
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        void Create(T entity);

        void Update(T entity);
        void Delete(T entity);

        T GetDefault(Expression<Func<T,bool>> expression); // read

        List<T> GetDefaults(Expression<Func<T,bool>> expression);  // read - bizden aldığı sorgu ile list yapısı döner



    }
}
