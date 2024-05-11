using AssetManagement.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AssetManagement.Data
{
    public class ProductDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Product, Guid> _repository;

        public ProductDataSeederContributor(IRepository<Product, Guid> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (_repository == null)
            {
                throw new InvalidOperationException("Product repository is null.");
            }

            if (await _repository.GetCountAsync() <= 0)
            {
                try
                {
                    await _repository.InsertAsync(new Product
                    {
                        Name = "Realme",
                        ProductType = ProductType.Mobiles,
                        Description = "Mobile Phone",
                        Price = 10000
                    }, autoSave: true);

                    await _repository.InsertAsync(new Product
                    {
                        Name = "Realme10x",
                        ProductType = ProductType.Mobiles,
                        Description = "Mobile Phone",
                        Price = 20000
                    }, autoSave: true);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during the insertion process.
                    Console.WriteLine($"Error inserting product: {ex.Message}");
                }
            }
        }
    }
}
