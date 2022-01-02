using KariyerNet.Core.Models;
using KariyerNet.Core.Repositories;
using KariyerNet.Core.Services;
using KariyerNet.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Service.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork, IRepository<Company> repository ):base(unitOfWork,repository)
        {

        }
        public bool ControlMaxJobAdvertisementCount(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetWithJobsByIdAsync(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
