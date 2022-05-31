using AutoMapper;
using crudApi.B_Service;
using crudApi.B_Service.Interfaces;
using crudApi.D_Repository;
using crudApi.D_Repository.Interface;
using crudApi.D_Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace crudApi.A_Application.Configuration
{
    public static class DependencyInjectionConfig
    {
         public static void DependencyInjection(IServiceCollection services)
         {
             //Services
             services.AddScoped<IProductService, ProductService>();
             services.AddScoped<IUserService, UserDataService>();


             //Repository
             services.AddScoped<IProductRepository, ProductRepository>();
             services.AddScoped<IUserRepository, UserRepository>();



         }   

         
    }
}