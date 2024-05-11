using AssetManagement.Products;
using AutoMapper;

namespace AssetManagement;

public class AssetManagementApplicationAutoMapperProfile : Profile
{
    public AssetManagementApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForAllOtherMembers(opt => opt.Ignore());

        CreateMap<CreataUpdateProductDto, Product>()
            .ForAllOtherMembers(opt => opt.Ignore());

        CreateMap<ProductDto, Product>()
            .ForAllOtherMembers(opt => opt.Ignore())
            .ReverseMap();
    }
}

