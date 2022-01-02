using KariyerNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Core.Services
{
    public interface IJobService:IService<Job>
    {
        Task<Job> GetWithJobByIdAsync(int jobId);

        //Job ile ilgili iç method'lar(Db ile ilgili olmayan) tanımlanabilir.
    }
}
