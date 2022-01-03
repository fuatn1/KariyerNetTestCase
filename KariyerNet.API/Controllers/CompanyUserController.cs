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
            return Ok(companiesUser);
        }
        [ServiceFilter(typeof(NotFoundFilterForCompanyUser))]
        [ValidationFilter]
        [HttpGet("{Id}")]
        public IActionResult GetById(long Id)
        {
            var companyUser = _companyUserService.GetById(Id);
            return Ok(companyUser);
        }
        [ValidationFilter]
        [HttpPost]
        public IActionResult Insert(CompanyUserDto CompanyUserDto)
        {
            var Company = _companyUserService.Add(CompanyUserDto);
            return Ok(Company);
        }
        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(CompanyUserDto CompanyUserDto)
        {
            _companyUserService.Update(CompanyUserDto);
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilterForCompanyUser))]
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
