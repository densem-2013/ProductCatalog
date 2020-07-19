using AutoMapper;
using ProductCatalog.DAL.Entities;
using ProductCatalog.DAL.Models.Users;

namespace ProductCatalog.DAL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}