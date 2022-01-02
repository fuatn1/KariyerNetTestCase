using KariyerNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Core.Repositories
{
    public interface IJobRepository:IRepository<Job>
    {
        Task<Job> GetWithJobByIdAsync(int CompanyId);
    }
}
