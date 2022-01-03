using AutoMapper;
using KariyerNet.Data.Entities;
using KariyerNet.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.API.Mapping
{
    public class EntityToDto:Profile
    {
        public EntityToDto()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<CompanyUser, CompanyUserDto>();
            CreateMap<CompanyUserDto, CompanyUser>();
            CreateMap<Job, JobDto>();
            CreateMap<JobDto, Job>();
        }
    }
}
