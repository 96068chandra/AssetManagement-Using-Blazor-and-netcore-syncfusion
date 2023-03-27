using AssetManagement.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AssetManagement
{
    public class ProductAppService:CrudAppService<Product,ProductDto,Guid,PagedAndSortedResultRequestDto,CreataUpdateProductDto>,IProductAppService
    {
        public ProductAppService(IRepository<Product,Guid> repository) : base(repository) 
        { 
        }

    }
}
