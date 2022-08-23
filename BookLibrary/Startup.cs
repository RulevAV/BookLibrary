using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;
using ICSSoft.Services;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Security;
//using IIS.Caseberry.Logging.Objects;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewPlatform.Flexberry.ORM.ODataService.Extensions;
using NewPlatform.Flexberry.ORM.ODataService.Files;
using NewPlatform.Flexberry.ORM.ODataService.Model;
using NewPlatform.Flexberry.ORM.ODataService.WebApi.Extensions;
using NewPlatform.Flexberry.ORM.ODataServiceCore.Common.Exceptions;
using NewPlatform.Flexberry.Services;
using Unity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BookLibrary.Service;
using BookLibrary.Domain.Repositories.Abstract;
using BookLibrary.Domain.Repositories.FlexberryMethod;

namespace BookLibrary
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            var authOptionsConfiguration = Configuration.GetSection("Auth");
            var authOptions = authOptionsConfiguration.Get<AuthOptions>();
            Configuration.Bind("OptionProject", new OptionProject());
            
            services.Configure<AuthOptions>(authOptionsConfiguration);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
         {
             options.RequireHttpsMetadata = false;
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = true,
                 ValidIssuer = authOptions.Issuer,

                 ValidateAudience = true,
                 ValidAudience = authOptions.Audience,

                 ValidateLifetime = true,

                 IssuerSigningKey = authOptions.GetSymetricSecurityKey(),
                 ValidateIssuerSigningKey = true,
             };
         });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookLibrary", Version = "v1" });
            });

            services.AddCors(options => options.AddDefaultPolicy(
                builder=> builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

            services
                .AddHealthChecks()
                .AddNpgSql(OptionProject.ConectionString);

            services.AddTransient<IUser, User>();
            services.AddTransient<ISpeaker, Speaker>();
            services.AddTransient<IReport, Report>();
            services.AddTransient<IError, Error>();
            services.AddTransient<IBook, Book>();
            services.AddTransient<IMeeting, Meeting>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookLibrary v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            // FYI: сервисы, в т.ч. контроллеры, создаются из дочернего контейнера.
            while (container.Parent != null)
            {
                container = container.Parent;
            }

            // FYI: сервис данных ходит в контейнер UnityFactory.
            container.RegisterInstance(Configuration);

            //RegisterDataObjectFileAccessor(container);
            RegisterORM(container);
        }

        /// <summary>
        /// Register ORM implementations.
        /// </summary>
        /// <param name="container">Container to register at.</param>
        private void RegisterORM(IUnityContainer container)
        {
            if (string.IsNullOrEmpty(OptionProject.ConectionString))
            {
                throw new System.Configuration.ConfigurationErrorsException("DefConnStr is not specified in Configuration or enviromnent variables.");
            }

            container.RegisterSingleton<ISecurityManager, EmptySecurityManager>();
            container.RegisterSingleton<IDataService, PostgresDataService>(
                Inject.Property(nameof(PostgresDataService.CustomizationString), OptionProject.ConectionString));
        }
    }
}
