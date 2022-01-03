using KariyerNet.Data.Configurations;
using KariyerNet.Data.Entities;
using KariyerNet.Data.Repository.Abstract;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Data.Repositories
{
    public class JobRepository : IJobRepository
    {
        protected readonly IMongoCollection<Job> Collection;
        public JobRepository(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient("mongodb://root:1234@localhost:27017");
            var db = client.GetDatabase("KariyerDb");
            this.Collection = db.GetCollection<Job>(typeof(Job).Name.ToLowerInvariant());
        }
        public Job Add(Job entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            Collection.InsertOne(entity, options);
            return entity;
        }

        public void Remove(Job entity)
        {
            Collection.FindOneAndDelete(x => x.Id == entity.Id);
        }

        public IEnumerable<Job> Where(Expression<Func<Job, bool>> predicate = null)
        {
            return predicate == null
                ? Collection.AsQueryable()
                : Collection.AsQueryable().Where(predicate);
        }

        public IEnumerable<Job> GetAll()
        {
            return Collection.AsQueryable();
        }
        public Job GetById(string id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefault();
        }

        public Job Update(Job entity)
        {
            return Collection.FindOneAndReplace(x => x.Id == entity.Id, entity);
        }
    }
}
