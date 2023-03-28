using AssetManagement.Products;
using AutoMapper;

namespace AssetManagement.Blazor;

public class AssetManagementBlazorAutoMapperProfile : Profile
{
    public AssetManagementBlazorAutoMapperProfile()
    {
        CreateMap<ProductDto, CreataUpdateProductDto>();
        //Define your AutoMapper configuration here for the Blazor project.
    }
}
