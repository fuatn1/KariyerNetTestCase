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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyManager _companyManager;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyManager companyService, IMapper mapper)
        {
            _companyManager = companyService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Companies =   _companyManager.GetAll ();
            return Ok(Companies);
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [HttpGet("{id}")]
        public IActionResult GetById(long Id)
        {
            var company =   _companyManager.GetById (Id);
            return Ok(_mapper.Map<CompanyDto>(company));
        }
        [ValidationFilter]
        [HttpPost]
        public IActionResult Insert(CompanyDto companyDto)
        {
            var Company =  _companyManager.Add(companyDto);
            return Created(string.Empty,Company);
        }
        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(CompanyDto companyDto)
        {
            var updatedCompany = _companyManager.Update(companyDto);
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [ValidationFilter]
        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            var company = _companyManager.GetById(id);
            _companyManager.Remove(company);

            return NoContent();
        }
    }
}
