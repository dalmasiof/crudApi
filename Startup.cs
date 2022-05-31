using System;
using System.Text;
using crudApi.A_Application.Configuration;
using crudApi.D_Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace crudApi
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
            //   services.AddCors(c =>
            //   {
            //       c.AddPolicy("AllowOrigin", options =>
            //       {
            //           options.AllowAnyOrigin().
            //           AllowAnyMethod().
            //           AllowAnyHeader();
            //       });
            //   });

            services.AddDbContext<DataContext>(x =>
             {
                 string connStr;
                 connStr = Configuration.GetConnectionString("sqlConnection");

                 x.UseMySql(connStr, new MySqlServerVersion(new Version(5, 0, 0)));

             });

            DependencyInjectionConfig.DependencyInjection(services);

            services.AddAutoMapper(typeof(Startup));

            // services.AddDbContext<DataContext>(options =>
            // services.AddDefaultIdentity<IdentityUser>()
            //     .AddEntityFrameworkStores<DataContext>()
            //     .AddDefaultTokenProviders());

            services.AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero
        });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "crudApi", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "crudApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
          
             app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
