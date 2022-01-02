using AutoMapper;
using KariyerNet.API.Filters;
using KariyerNet.Core.Models;
using KariyerNet.Core.Services;
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
        private readonly ICompanyUserService _companyUserService;
        private readonly IMapper _mapper;
        public CompanyUserController(ICompanyUserService companyUserService, IMapper mapper)
        {
            _companyUserService = companyUserService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companiesUser = await _companyUserService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CompanyUserDto>>(companiesUser));
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [ValidationFilter]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var companyUser = await _companyUserService.GetByIdAsync(Id);
            return Ok(_mapper.Map<CompanyUserDto>(companyUser));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Insert(CompanyUserDto CompanyUserDto)
        {
            var Company = await _companyUserService.AddAsync(_mapper.Map<CompanyUser>(CompanyUserDto));
            return Created("", _mapper.Map<CompanyUserDto>(Company));
        }
        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(CompanyUserDto CompanyUserDto)
        {
            var updatedCompany = _companyUserService.Update(_mapper.Map<CompanyUser>(CompanyUserDto));
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [ValidationFilter]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var companyUser = _companyUserService.GetByIdAsync(id).Result;
            _companyUserService.Remove(companyUser);

            return NoContent();
        }
    }
}
