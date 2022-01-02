using KariyerNet.Core.Services;
using KariyerNet.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.API.Filters
{
    public class NotFoundFilterForCompanyUser:ActionFilterAttribute
    {
        private readonly ICompanyUserService _companyUserService;
        public NotFoundFilterForCompanyUser(ICompanyUserService companyUserService)
        {
            _companyUserService = companyUserService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            long id = (long)context.ActionArguments.Values.FirstOrDefault();

            var company = await _companyUserService.GetByIdAsync(id);
            if (company != null)
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
