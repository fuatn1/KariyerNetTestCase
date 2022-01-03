using AutoMapper;
using KariyerNet.API.Filters;
using KariyerNet.Busines.Abstract;
using KariyerNet.Data.Entities;
using KariyerNet.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserController : ControllerBase
    {
        private readonly ICompanyUserManager _companyUserService;
        private readonly IMapper _mapper;
        public CompanyUserController(ICompanyUserManager companyUserService, IMapper mapper)
        {
            _companyUserService = companyUserService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var companiesUser = _companyUserService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CompanyUserDto>>(companiesUser));
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [ValidationFilter]
        [HttpGet("{id}")]
        public IActionResult GetById(long Id)
        {
            var companyUser = _companyUserService.GetById(Id);
            return Ok(_mapper.Map<CompanyUserDto>(companyUser));
        }
        [ValidationFilter]
        [HttpPost]
        public IActionResult Insert(CompanyUserDto CompanyUserDto)
        {
            var Company = _companyUserService.Add(CompanyUserDto);
            return Ok(_mapper.Map<CompanyUserDto>(Company));
        }
        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(CompanyUserDto CompanyUserDto)
        {
            var updatedCompany = _companyUserService.Update(CompanyUserDto);
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [ValidationFilter]
        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            var companyUser = _companyUserService.GetById(id);
            _companyUserService.Remove(companyUser);

            return NoContent();
        }
    }
}
