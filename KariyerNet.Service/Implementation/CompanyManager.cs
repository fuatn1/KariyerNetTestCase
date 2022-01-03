using KariyerNet.Busines.Abstract;
using KariyerNet.Data.Entities;
using KariyerNet.Data.Repository.Abstract;
using KariyerNet.Dto;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Busines.Implementation
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyManager(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public CompanyDto Add (CompanyDto entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.MaxJobAdvertisementCount = 2;
            var response = _companyRepository.Add(entity.Adapt<Company>());

            return response.Adapt<CompanyDto>();
        }

        public static bool ControlMaxJobAdvertisementCount(CompanyDto company)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyDto> GetAll ()
        {
            var result = _companyRepository.GetAll();
            return result.Adapt<IEnumerable<CompanyDto>>();
        }

        public CompanyDto GetById(long id)
        {
            var result = _companyRepository.GetById(id);
            return result.Adapt<CompanyDto>();
        }

        public CompanyDto GetWithJobsById(int companyId)
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            var company = _companyRepository.GetById(id);
            _companyRepository.Remove(company.Adapt<Company>());
        }

        public void RemoveRange(IEnumerable<CompanyDto> entities)
        {
            _companyRepository.RemoveRange(entities.Adapt<IEnumerable<Company>>());
        }

        public CompanyDto SingleOrDefault (Expression<Func<CompanyDto, bool>> expression)
        {
            var result = _companyRepository.SingleOrDefault(expression.Adapt<Expression<Func<Company, bool>>>());
            return result.Adapt<CompanyDto>();
        }

        public CompanyDto Update(CompanyDto entity)
        {
            entity.UpdateDate = DateTime.Now;
            var result = _companyRepository.Update(entity.Adapt<Company>());
            return result.Adapt<CompanyDto>();
        }
    }
}
