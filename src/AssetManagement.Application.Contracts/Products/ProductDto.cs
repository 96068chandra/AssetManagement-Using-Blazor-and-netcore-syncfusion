using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace AssetManagement.Products
{
    public class ProductDto : AuditedEntityDto<Guid>, IEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }
    }

    public enum ProductType
    {
        Electronic,
        Mechanical,
        Other
    }
}
