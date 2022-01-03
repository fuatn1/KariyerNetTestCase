using KariyerNet.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Data.UnitOfWorks.Abstract
{
    public interface IUnitOfWork
    { 
        ICompanyRepository Companies { get; }
        ICompanyUserRepository CompanyUserRepository { get; }
        Task SaveChangesAsync(); 
        void SaveChanges();
    }
}
