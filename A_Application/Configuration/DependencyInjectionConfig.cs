using AutoMapper;
using crudApi.B_Service;
using crudApi.D_Repository;
using crudApi.D_Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace crudApi.A_Application.Configuration
{
    public static class DependencyInjectionConfig
    {
         public static void DependencyInjection(IServiceCollection services)
         {
             //Services
             services.AddScoped<IUserService, UserService>();

             //Repository
             services.AddScoped<IUserRepository, UserRepository>();

           

         }   

         
    }
}