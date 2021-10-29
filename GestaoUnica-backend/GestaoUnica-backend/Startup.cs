using GestaoUnica_backend.Business.Implementation;
using GestaoUnica_backend.Business.Interfaces;
using GestaoUnica_backend.Context;
using GestaoUnica_backend.Data.Repository.Implementations;
using GestaoUnica_backend.Data.Repository.Interfaces;
using GestaoUnica_backend.Interfaces;
using GestaoUnica_backend.Repository.Generic;
using GestaoUnica_backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GestaoUnica_backend
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestaoUnica_backend", Version = "v1" });
            });
            #region ConnectionString
            services.AddDbContext<SQLContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Connection")));
            #endregion
            #region Token e Active Directory
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("TokenConfig:Secret").Value.ToString());
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
                         
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IActiveDirectoryService, ActiveDirectoryService>();
            #endregion
            #region Repositorios
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
            #region Business - Regras de neg�cio
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IRoleBusiness, RoleBusiness>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestaoUnica_backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(); //Deve ficar apos UseHttpsRedirection e UseRouting e antes de UseEndpoints

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
