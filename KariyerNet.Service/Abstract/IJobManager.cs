using KariyerNet.Data.Entities;
using KariyerNet.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Busines.Abstract
{
    public interface IJobManager:IManager<JobDto>
    {
        Task<Job> GetWithJobByIdAsync(int jobId);

        //Job ile ilgili iç method'lar(Db ile ilgili olmayan) tanımlanabilir.
    }
}
