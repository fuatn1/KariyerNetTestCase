using KariyerNet.Data.Entities;
using KariyerNet.Dto;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Busines.Abstract
{
    public interface IJobManager
    {
        JobDto GetById(string id);
        IEnumerable<JobDto> GetAll();
        IEnumerable<JobDto> Where(Expression<Func<JobDto, bool>> expression);
        JobDto Add(JobDto entity);
        void Remove(JobDto entity);
        JobDto Update(JobDto entity);

        //JobDto ile ilgili iç method'lar(Db ile ilgili olmayan) tanımlanabilir.
    }
}
