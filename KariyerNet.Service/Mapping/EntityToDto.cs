using AutoMapper;
using KariyerNet.Data.Entities;
using KariyerNet.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.Business.Mapping
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<EntityToDto>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
    public class EntityToDto:Profile
    {
        public EntityToDto()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyDto, Company>();
            CreateMap<CompanyUser, CompanyUserDto>();
            CreateMap<CompanyUserDto, CompanyUser>();
            CreateMap<Job, JobDto>();
            CreateMap<JobDto, Job>();
        }
    }
}
