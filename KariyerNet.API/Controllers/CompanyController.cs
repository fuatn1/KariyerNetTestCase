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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Companies = await _companyService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CompanyDto>>(Companies));
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long Id)
        {
            var company = await _companyService.GetByIdAsync(Id);
            return Ok(_mapper.Map<CompanyDto>(company));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Insert(CompanyDto companyDto)
        {
            var Company = await _companyService.AddAsync(_mapper.Map<Company>(companyDto));
            return Created("", _mapper.Map<CompanyDto>(Company));
        }
        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(CompanyDto companyDto)
        {
            var updatedCompany = _companyService.Update(_mapper.Map<Company>(companyDto));
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [ValidationFilter]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var company = _companyService.GetByIdAsync(id).Result;
            _companyService.Remove(company);

            return NoContent();
        }
    }
}
