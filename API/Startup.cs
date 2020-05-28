using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using API.Helper;
using AutoMapper;
using API.Middlware;
using API.Errors;
using Microsoft.OpenApi.Models;
using API.Extensions;

namespace API {
    public class Startup {
        private readonly IConfiguration _config;
        public Startup (IConfiguration config) {
            _config = config;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            
            #region Injetando dependencias  
          
            services.AddAutoMapper(typeof(MappingProfiles));
            #endregion

                services.AddControllers ();
                services.AddDbContext<StroreContext> (x =>
                    x.UseSqlite (_config.GetConnectionString ("minhaconnection")));
                services.AddControllers ();
               services.AddApplicationServices();
               services.AddSwaggerDocumentation();
          
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseStatusCodePagesWithReExecute("/erros/{0}");
        app.UseHttpsRedirection ();

        app.UseRouting ();
        app.UseStaticFiles(); // config   para  para aparecer   as imagens  no meus  request 
        app.UseSwaggerDocumention();
        app.UseAuthorization ();
  
        app.UseEndpoints (endpoints => {
            endpoints.MapControllers ();
        });
    }
}
}