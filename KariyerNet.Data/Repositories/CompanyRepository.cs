using KariyerNet.Data.Entities;
using KariyerNet.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private KariyerDbContext _kariyerDbContext { get => _context as KariyerDbContext; }
        public CompanyRepository(KariyerDbContext context) : base(context)
        {

        }
    }
}
