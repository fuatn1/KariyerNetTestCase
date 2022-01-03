using KariyerNet.Data.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Data.Repository.Abstract
{
    public interface IJobRepository
 
    {
        Job GetById(string id);
        IEnumerable<Job> GetAll();
        IEnumerable<Job> Where(Expression<Func<Job, bool>> expression);
        Job Add(Job entity);
        void Remove(Job entity);
        Job Update(Job entity);
    }
}
