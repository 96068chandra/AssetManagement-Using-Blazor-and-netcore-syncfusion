using AssetManagement.Products;
using AutoMapper;

namespace AssetManagement;

public class AssetManagementApplicationAutoMapperProfile : Profile
{
    public AssetManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Product, ProductDto>();
        CreateMap<CreataUpdateProductDto, Product>();
    }
}
