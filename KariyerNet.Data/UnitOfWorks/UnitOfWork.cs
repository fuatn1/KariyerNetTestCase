using KariyerNet.Data.Repositories;
using KariyerNet.Data.Repository.Abstract;
using KariyerNet.Data.UnitOfWorks.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private CompanyRepository _companyRepository;
        private CompanyUserRepository _CompanyUserRepository;
        public ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);
        public ICompanyUserRepository CompanyUserRepository => _CompanyUserRepository = _CompanyUserRepository ?? new CompanyUserRepository(_context);
        private readonly KariyerDbContext _context;
        public UnitOfWork(KariyerDbContext kariyerDbContext)
        {
            _context = kariyerDbContext;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
