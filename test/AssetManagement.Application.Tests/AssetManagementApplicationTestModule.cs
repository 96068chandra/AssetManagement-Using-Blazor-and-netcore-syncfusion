using Volo.Abp.Modularity;
using AssetManagement.Application.Contracts;
using AssetManagement.Application.Services;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Repositories;
using Moq;

namespace AssetManagement.Application.Tests;

[DependsOn(
    typeof(AssetManagementApplicationModule),
    typeof(AssetManagementDomainTestModule)
)]
public class AssetManagementApplicationTestModule : AbpModule
{
    public override void Initialize()
    {
        IocManager.Register<IMock<IAssetAppService>, Mock<IAssetAppService>>();
        IocManager.Register<IMock<IDeviceRepository>, Mock<IDeviceRepository>>();
    }
}
