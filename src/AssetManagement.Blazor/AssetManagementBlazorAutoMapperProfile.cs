using AssetManagement.Products;
using AutoMapper;
using AssetManagement.Blazor.Models;

namespace AssetManagement.Blazor;

public class AssetManagementBlazorAutoMapperProfile : Profile
{
    public AssetManagementBlazorAutoMapperProfile()
    {
        CreateMap<ProductDto, CreateUpdateProductDto>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Version, opt => opt.Ignore());

        // Add other mapping configurations here.
    }
}

