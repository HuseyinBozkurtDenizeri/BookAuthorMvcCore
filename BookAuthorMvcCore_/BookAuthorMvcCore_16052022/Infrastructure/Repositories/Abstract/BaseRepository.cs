using BookAuthorMvcCore_16052022.Infrastructure.Context;
using BookAuthorMvcCore_16052022.Infrastructure.Repositories.Interfaces.IBaseRepo;
using BookAuthorMvcCore_16052022.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookAuthorMvcCore_16052022.Models.Enums;

namespace BookAuthorMvcCore_16052022.Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ProjectContext _projectContext;
        private readonly DbSet<T> _table;

        public BaseRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
            _table = _projectContext.Set<T>();  // db.set gibi yani context sınıfınınn içinde dbsetlere ulaşmış olduk.
        }
        public void Create(T entity)
        {
            //db.öğreciler.add(öğrenci);
            //db.saveChangges();
            _table.Add(entity);
            _projectContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.Statu =Statu.Passive;
            _projectContext.SaveChanges();
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.FirstOrDefault(expression);
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }
        
        public void Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.Statu = Statu.Modified;
            _projectContext.SaveChanges();
        }
    }
}
