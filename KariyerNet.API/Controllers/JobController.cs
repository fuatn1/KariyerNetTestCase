using KariyerNet.API.Filters;
using KariyerNet.Busines.Abstract;
using KariyerNet.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private IJobManager _jobManager;
        public JobController(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }
        [ValidationFilter]
        [HttpPost]
        public IActionResult Insert(JobDto companyDto)
        {
            var job = _jobManager.Add(companyDto);
            return Created(string.Empty, job);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobs = _jobManager.GetAll();
            return Ok(jobs);
        }
        [ServiceFilter(typeof(NotFoundFilterForJob))]
        [HttpGet("{Id}")]
        public IActionResult GetById(string Id)
        {
            var job = _jobManager.GetById(Id);
            return Ok(job);
        }
        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(JobDto company)
        {
            _jobManager.Update(company);
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilterForJob))]
        [ValidationFilter]
        [HttpDelete("{Id}")]
        public IActionResult Remove(string Id)
        {
            var job = _jobManager.GetById(Id);
            _jobManager.Remove(job);

            return NoContent();
        }
    }
}
