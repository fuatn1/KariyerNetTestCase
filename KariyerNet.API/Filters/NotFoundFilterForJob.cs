using KariyerNet.Busines.Abstract;
using KariyerNet.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.API.Filters
{
    public class NotFoundFilterForJob: ActionFilterAttribute
    {
        private readonly IJobManager _jobManager;
        public NotFoundFilterForJob(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (string)context.ActionArguments.Values.FirstOrDefault();

            var job = _jobManager.GetById(id);
            if (job != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"Id: {id} not found");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}

