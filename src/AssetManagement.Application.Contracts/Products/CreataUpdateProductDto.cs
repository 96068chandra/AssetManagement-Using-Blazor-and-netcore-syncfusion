using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Products
{
    public class CreataUpdateProductDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public ProductType productType { get; set; } = ProductType.Undefined;
    }
}
