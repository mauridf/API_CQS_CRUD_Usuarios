using API_CQS_CRUD_Usuarios.Domain.CommandHandlers;
using API_CQS_CRUD_Usuarios.Domain.Command;
using API_CQS_CRUD_Usuarios.Domain.Notification;
using API_CQS_CRUD_Usuarios.Domain.Queries;
using API_CQS_CRUD_Usuarios.Domain.Queries.Results;
using API_CQS_CRUD_Usuarios.Domain.QueryHandlers;
using API_CQS_CRUD_Usuarios.Domain.Validations;
using API_CQS_CRUD_Usuarios.Infra.BehaviorMediatR;
using API_CQS_CRUD_Usuarios.Infra.Data;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace API_CQS_CRUD_Usuarios
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUsuarioCommandValidation>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API_CQS_CRUD_Usuarios", Version = "v1" });
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IDomainNotificationContext, DomainNotificationContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<AsyncRequestHandler<CreateUsuarioCommand>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<GetPagedUsuariosQuery, IEnumerable<GetPagedUsersQueryResult>>, UsuarioQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger(); app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_CQS_CRUD_Usuarios v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
