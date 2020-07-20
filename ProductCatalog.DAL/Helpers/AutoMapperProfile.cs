using AutoMapper;
using ProductCatalog.DAL.Entities;
using ProductCatalog.DAL.Models.Categories;
using ProductCatalog.DAL.Models.Products;
using ProductCatalog.DAL.Models.ProductSpecFields;
using ProductCatalog.DAL.Models.SpecialFields;
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

            CreateMap<Category, CategoryModel>();
            CreateMap<UpdateCategoryModel, Category>();

            CreateMap<SpecField, SpecFieldModel>();
            CreateMap<AddSpecFieldModel, SpecField>();

            CreateMap<ProductSpecField, ProductSpecFieldModel>()
            .ForMember(d => d.Name, opt => opt.MapFrom((s, d, destMember, res) => s.SpecField?.Name));
            CreateMap<AddSpecFieldToProductModel, ProductSpecField>();

            CreateMap<Product, ProductModel>();
            CreateMap<UpdateProductModel, Product>();
        }
    }
}