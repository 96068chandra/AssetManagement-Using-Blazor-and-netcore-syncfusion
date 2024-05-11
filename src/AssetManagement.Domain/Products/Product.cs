using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace AssetManagement.Products
{
    public class Product : AuditedEntity<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; private set; }

        [Required]
        [Range(0, float.MaxValue)]
        public float Price { get; private set; }

        [Required]
        public ProductType ProductType { get; private set; }

        public Product(Guid id, string name, string description, float price, ProductType productType)
            : base(id)
        {
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            SetProductType(productType);
        }

        public void SetName(string name)
        {
            if (name.Length > 100)
            {
                throw new ArgumentException("Name cannot be longer than 100 characters.");
            }

            Name = name;
        }

        public void SetDescription(string description)
        {
            if (description.Length > 500)
            {
                throw new ArgumentException("Description cannot be longer than 500 characters.");
            }

            Description = description;
        }

        public void SetPrice(float price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }

            Price = price;
        }

        public void SetProductType(ProductType productType)
        {
            ProductType = productType;
        }
    }

    public enum ProductType
    {
        Electronic,
        Mechanical,
        Other
    }
}
