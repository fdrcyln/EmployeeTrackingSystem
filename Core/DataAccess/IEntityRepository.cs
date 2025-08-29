using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity , new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // expressiopn to filter the results sanırsam LINQ ??

        T Get(Expression<Func<T, bool>> filter);
        public void Add(T entity);
       
        public void Update(T entity);

        public void Delete(T entity);
     
    }
}
