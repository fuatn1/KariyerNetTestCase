using KariyerNet.Data.Entities;
using KariyerNet.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KariyerNet.Busines.Abstract
{
    public interface ICompanyUserManager
    {
        CompanyUserDto GetById(long id);
        IEnumerable<CompanyUserDto> GetAll();
        CompanyUserDto SingleOrDefault(Expression<Func<CompanyUserDto, bool>> expression);
        CompanyUserDto Add(CompanyUserDto entity);
        void Remove(long id);
        CompanyUserDto Update(CompanyUserDto entity);
    }
}
