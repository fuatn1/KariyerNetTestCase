using KariyerNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Core.Services
{
    public interface ICompanyService:IService<Company>
    {
        Task<Company> GetWithJobsByIdAsync(int companyId);

        //Company ile ilgili iç method'lar(Db ile ilgili olmayan) tanımlanabilir.
        bool ControlMaxJobAdvertisementCount(Company company);
    }
}
