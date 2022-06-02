using AutoMapper;
using crudApi.A_Application.ViewModels;
using crudApi.C_Domain;

namespace crudApi.A_Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductVM,Product>().ReverseMap();
            CreateMap<UserDataVM,UserData>().ReverseMap();
            CreateMap<PurchaseOrderVM,PurchaseOrder>().ReverseMap();
        
        }

        
    }
}