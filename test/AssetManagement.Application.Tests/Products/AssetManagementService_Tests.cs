using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Volo.Abp.Application.Dtos;
using Shouldly;
using Volo.Abp.Validation;

namespace AssetManagement.Products
{
    public class AssetManagementService_Tests:AssetManagementApplicationTestBase
    {
        private readonly IProductAppService _productAppService;
        public AssetManagementService_Tests()
        {
              _productAppService=GetRequiredService<IProductAppService>();
            
        }
        [Fact]

        public async Task Should_Get_List_Of_Products()
        {
            var result = await _productAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
                ) ;

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(p => p.Name == "Realme");
        }


        [Fact]
        public async Task Should_create_a_valid_product()
        {
            var result = await _productAppService.CreateAsync(
                new CreataUpdateProductDto
                {
                    Name = "Oppo10A",
                    productType = ProductType.Mobiles,
                    Description = "Mobile Phone",
                    Price = 20000



                });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("Oppo10A");
        }

        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _productAppService.CreateAsync(
                    new CreataUpdateProductDto
                    {
                        Name="",
                        productType = ProductType.Mobiles,
                        Description="Mobile Phone",
                        Price=35000
                    });
            });
            exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }
    }
}
