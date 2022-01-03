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
        public CompanyController(ICompanyManager companyService)
        {
            _companyManager = companyService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Companies =   _companyManager.GetAll ();
            return Ok(Companies);
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [HttpGet("{Id}")]
        public IActionResult GetById(long Id)
        {
            var company = _companyManager.GetById (Id);
            return Ok(company);
        }
        [ValidationFilter]
        [HttpPost]
        public IActionResult Insert(CompanyDto companyDto)
        {
            var company =  _companyManager.Add(companyDto);
            return Created(string.Empty,company);
        }
        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(CompanyDto companyDto)
        {
            _companyManager.Update(companyDto);
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilterForCompany))]
        [ValidationFilter]
        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            _companyManager.Remove(id);

            return NoContent();
        }
    }
}
