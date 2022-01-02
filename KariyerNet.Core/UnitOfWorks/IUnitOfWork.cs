using KariyerNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Core.UnitOfWorks
{
    public interface IUnitOfWork
    { 
        ICompanyRepository Companies { get; }
        ICompanyUserRepository CompanyUserRepository { get; }
        Task SaveChangesAsync(); 
        void SaveChanges();
    }
}
