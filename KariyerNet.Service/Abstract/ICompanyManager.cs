using KariyerNet.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Busines.Abstract
{
    public interface ICompanyManager
    {
        CompanyDto GetById(long id);
        IEnumerable<CompanyDto> GetAll();
        CompanyDto SingleOrDefault(Expression<Func<CompanyDto, bool>> expression);
        CompanyDto Add(CompanyDto entity);
        void Remove(long id);
        CompanyDto Update(CompanyDto entity);
    }
}
