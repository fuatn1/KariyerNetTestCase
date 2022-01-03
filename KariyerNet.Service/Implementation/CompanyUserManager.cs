using KariyerNet.Busines.Abstract;
using KariyerNet.Data.Entities;
using KariyerNet.Data.Repository.Abstract;
using KariyerNet.Dto;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Busines.Implementation
{
    public class CompanyUserManager : ICompanyUserManager
    {
        private readonly ICompanyUserRepository _companyUserRepository;
        public CompanyUserManager(ICompanyUserRepository companyUserRepository)
        {
            _companyUserRepository = companyUserRepository;
        }
        public CompanyUserDto Add(CompanyUserDto entity)
        {
            PhoneNumberIsExist(entity);
            var company = entity.Adapt<CompanyUser>();
            company.CreateDate = DateTime.Now;
            _companyUserRepository.Add(company);
            return company.Adapt<CompanyUserDto>();
        }

        private void PhoneNumberIsExist(CompanyUserDto company)
        {
            var companyUser = company.Adapt<CompanyUser>();
            var data = _companyUserRepository.Where(x => x.PhoneNumber == companyUser.PhoneNumber).ToList();

            if (data.Count < 1) throw new Exception("Telefon numarası kayıtlı. Aynı telefon numarası ile tekrar kayıt yapılamaz..");

        }

        public IEnumerable<CompanyUserDto> GetAll()
        {
            var result = _companyUserRepository.GetAll();
            return result.Adapt<IEnumerable<CompanyUserDto>>();
        }

        public CompanyUserDto GetById(long id)
        {
            var result = _companyUserRepository.GetById(id);
            return result.Adapt<CompanyUserDto>();
        }

        public Task<CompanyUserDto> GetWithJobsById(int companyId)
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            var companyUser = _companyUserRepository.GetById(id);
            _companyUserRepository.Remove(companyUser.Adapt<CompanyUser>());
        }

        public void RemoveRange(IEnumerable<CompanyUserDto> entities)
        {
            _companyUserRepository.RemoveRange(entities.Adapt<IEnumerable<CompanyUser>>());
        }

        public CompanyUserDto SingleOrDefault(Expression<Func<CompanyUserDto, bool>> expression)
        {
            var result = _companyUserRepository.SingleOrDefault(expression.Adapt<Expression<Func<CompanyUser, bool>>>());

            return result.Adapt<CompanyUserDto>();
        }

        public CompanyUserDto Update(CompanyUserDto entity)
        {
            entity.UpdateDate = DateTime.Now;
            var result = _companyUserRepository.Update(entity.Adapt<CompanyUser>());
            return result.Adapt<CompanyUserDto>();
        }
    }
}
