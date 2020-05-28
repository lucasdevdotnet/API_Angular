using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public  static class ApplicationServicesExtensions
    {
        public  static IServiceCollection  AddApplicationServices(this IServiceCollection  services) 
        {
              services.AddScoped<IProductRepository, ProductRepository> ();
              services.AddScoped(typeof(IGenericRepository<>), (typeof (GenericRepository<>))); // injectando as dependencias      
              services.Configure<ApiBehaviorOptions>(oprions=>
                {

                    oprions.InvalidModelStateResponseFactory =  actionContext =>
                    {
                        var errors = actionContext.ModelState
                        .Where(x=>x.Value.Errors.Count > 0)
                        .SelectMany(d=>d.Value.Errors)
                        .Select(d=>d.ErrorMessage).ToArray();
                        var  errorResponse = new ApiValidationErrorResponse
                        {
                            Errors = errors
                        };
                        return   new BadRequestObjectResult(errorResponse);
                    };
                });
                return  services;

        }
        
    }
}