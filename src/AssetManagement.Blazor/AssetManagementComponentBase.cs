using AssetManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AssetManagement.Blazor;

public abstract class AssetManagementComponentBase : AbpComponentBase
{
    protected AssetManagementComponentBase()
    {
        LocalizationResource = typeof(AssetManagementResource);
    }
}
