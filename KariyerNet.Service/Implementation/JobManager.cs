using KariyerNet.Busines.Abstract;
using KariyerNet.Busines.Implementation;
using KariyerNet.Data.Entities;
using KariyerNet.Data.Repository.Abstract;
using KariyerNet.Dto;
using Mapster;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace KariyerNet.Business.Implementation
{
    public class JobManager : IJobManager
    {
        private IJobRepository _jobRepository;
        private ICompanyRepository _companyRepository;
        private ICompanyUserRepository _companyUserRepository;
        public JobManager(IJobRepository jobRepository, ICompanyRepository companyRepository, ICompanyUserRepository companyUserRepository)
        {
            _jobRepository = jobRepository;
            _companyRepository = companyRepository;
            _companyUserRepository = companyUserRepository;
        }
        public JobDto Add(JobDto entity)
        {
            IsCompanyExist(entity.CompanyId);
            IsCompanyUserExist(entity.CompanyUserId);
            ControlMaxJobAdvertisementCount(entity.CompanyId);
            int score = CalculateJobAdvertisemenScore(entity);

            entity.CreateDate = DateTime.Now;
            entity.Score = score;
            entity.ExpirationTime = entity.CreateDate.AddDays(15);
            entity.Id = ObjectId.GenerateNewId().ToString();
            var response = _jobRepository.Add(entity.Adapt<Job>());
            DecreaseJobAdvertisementCount(entity.CompanyId);
            return response.Adapt<JobDto>();
        }

        public IEnumerable<JobDto> GetAll()
        {
            return _jobRepository.GetAll().Adapt<IEnumerable<JobDto>>();
        }

        public JobDto GetById(string id)
        {
            return _jobRepository.GetById(id).Adapt<JobDto>();
        }

        public void Remove(JobDto entity)
        {
            _jobRepository.Remove(entity.Adapt<Job>());
        }

        public JobDto Update(JobDto entity)
        {
            entity.UpdateDate = DateTime.Now;
            var Response = _jobRepository.Update(entity.Adapt<Job>());
            return Response.Adapt<JobDto>();
        }

        public IEnumerable<JobDto> Where(Expression<Func<JobDto, bool>> expression)
        {
            var response = _jobRepository.Where(expression.Adapt<Expression<Func<Job, bool>>>());
            return response.Adapt<IEnumerable<JobDto>>();
        }
        public void IsCompanyExist(long Id)
        {
            var result = _companyRepository.GetById(Id);
            if (result == null) throw new Exception("Bu CompanyId'ye sahip bir company bilgisi bulunmamaktadır..");
        }
        private void IsCompanyUserExist(long Id)
        {
            var result = _companyUserRepository.GetById(Id);
            if (result == null) throw new Exception("Bu CompanyUserId'ye sahip bir user bilgisi bulunmamaktadır..");
        }
        private void ControlMaxJobAdvertisementCount(long Id)
        {
            var result = _companyRepository.GetById(Id);
            if (result.MaxJobAdvertisementCount == 0) throw new Exception("Bu Company için ilan hakkı tükenmiştir..");

        }
        private void DecreaseJobAdvertisementCount(long Id)
        {
            var result = _companyRepository.GetById(Id);
            result.MaxJobAdvertisementCount -= 1; 
            _companyRepository.Update(result);
        }
        private int CalculateJobAdvertisemenScore(JobDto entity)
        {
            int score = 0;
            if (entity.Type != null) score++;
            if (entity.Salary > 0) score++;
            if (entity.Benefit != null) score++;
            if (!HasBadWords(entity.Description))
            {
                score += 2;
            }
            return score;
        }
        public bool HasBadWords(string inputWords)
        {
            Regex wordFilter = new Regex("(kötü|kelimeler|lanet)");
            return wordFilter.IsMatch(inputWords);
        }
    }
}
