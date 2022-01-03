using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Data.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression);
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}
