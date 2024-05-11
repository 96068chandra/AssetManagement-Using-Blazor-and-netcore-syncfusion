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
    public class ProductAppService :
        CrudAppService<Product, ProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProductDto>,
        IProductAppService
    {
        public ProductAppService(IRepository<Product, Guid> repository) : base(repository)
        {
        }

        protected override IQueryable<Product> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return Repository.GetQueryable().Where(product => !product.IsDeleted);
        }

        // Add any additional methods or functionality here
    }
}
