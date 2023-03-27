using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AssetManagement.Products
{
    public class ProductDto:AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public ProductType productType { get; set; }
    }
}
