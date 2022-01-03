using KariyerNet.Busines.Abstract;
using KariyerNet.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.API.Filters
{
    public class NotFoundFilterForCompany : ActionFilterAttribute
    {
        private readonly ICompanyManager _companyManager;
        public NotFoundFilterForCompany(ICompanyManager companyService)
        {
            _companyManager = companyService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            long id = (long)context.ActionArguments.Values.FirstOrDefault();

            var company = _companyManager.GetById(id);
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
