using KariyerNet.Core.Models;
using KariyerNet.Core.Repositories;
using KariyerNet.Core.Services;
using KariyerNet.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Service.Services
{
    public class CompanyUserService : Service<CompanyUser>, ICompanyUserService
    {
        public CompanyUserService(IUnitOfWork unitOfWork, IRepository<CompanyUser> repository):base(unitOfWork,repository)
        {

        }
    }
}
