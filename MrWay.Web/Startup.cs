using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using AspNet.Security.OAuth.Validation;
//using AspNet.Security.OpenIdConnect.Primitives;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using MrWay.Data.Infrastructure.Context;
using MrWay.Domain.DomainModels.Identity;
using MrWay.Services;
using MrWay.Web.Filters;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;
using MrWay.Domain.Interfaces.UnitOfWork;
using MrWay.Data.Infrastructure.UnitOfWork;

namespace MrWay.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                //options.UseOpenIddict();
            });

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddUserManager<AppUserManager>()
                .AddDefaultTokenProviders();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.User.RequireUniqueEmail = true;
            //    options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
            //    options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
            //    options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            //});

            services.AddAuthentication();
            //services.AddAuthentication(options =>
            //    {
            //        options.DefaultScheme = OAuthValidationDefaults.AuthenticationScheme;
            //        options.DefaultAuthenticateScheme = OAuthValidationDefaults.AuthenticationScheme;
            //    })
            //    .AddOAuthValidation();

            //services.AddOpenIddict()
            //    .AddEntityFrameworkCoreStores<AppDbContext>()
            //    .AddMvcBinders()
            //    .DisableHttpsRequirement()
            //    .EnableTokenEndpoint("/connect/token")
            //    .AllowPasswordFlow()
            //    .AllowRefreshTokenFlow();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfiles(new[] { "MrWay.Services" });
            });

            services
                .AddMvc(setup => { setup.Filters.Add(typeof(UnitOfWorkAttribute)); })
                .AddJsonOptions(setup => { setup.SerializerSettings.Converters.Add(new StringEnumConverter(true)); });

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new Info { Title = "Mr. Way API", Version = "v1" });

                setup.AddSecurityDefinition("OAuth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "password",
                    TokenUrl = "/connect/token"
                });

                setup.DescribeAllEnumsAsStrings();
                setup.DescribeStringEnumsInCamelCase();
            });

            services.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mr. Way API");
            });

            app.UseMvc();
        }
    }
}