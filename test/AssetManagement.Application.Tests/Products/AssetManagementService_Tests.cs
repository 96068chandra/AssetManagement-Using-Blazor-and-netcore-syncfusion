using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Products;
using Shouldly;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace AssetManagement.Tests.Products
{
    public class AssetManagementService_Tests : AbpApplicationTestBase
    {
        private readonly IProductAppService _productAppService;

        public AssetManagementService_Tests()
        {
            _productAppService = GetRequiredService<IProductAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Products()
        {
            // Arrange
            var request = new PagedAndSortedResultRequestDto();

            // Act
            var result = await _productAppService.GetListAsync(request);

            // Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(p => p.Name == "Realme");
        }

        [Fact]
        public async Task Should_create_a_valid_product()
        {
            // Arrange
            var productDto = new CreateUpdateProductDto
            {
                Name = "Oppo10A",
                ProductType = ProductType.Mobiles,
                Description = "Mobile Phone",
                Price = 20000
            };

            // Act
            var result = await _productAppService.CreateAsync(productDto);

            // Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe(productDto.Name);
        }

        [Fact]
        public async Task Should_Not_Create_A_Product_Without_Name()
        {
            // Arrange
            var productDto = new CreateUpdateProductDto
            {
                Name = "",
                ProductType = ProductType.Mobiles,
                Description = "Mobile Phone",
                Price = 35000
            };

            // Act & Assert
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _productAppService.CreateAsync(productDto);
            });

            // Assert
            using var assertionScope = ShouldlyShould.Should(this);
            assertionScope.ShouldSatisfyAllConditions(
                () => assertionScope.ShouldNotBeNull(),
                () => assertionScope.Items.ShouldContain(err => err.MemberNames.Any(mem => mem == "Name")));
        }
    }
}
