using AssetManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AssetManagement.Blazor;

public abstract class AssetManagementComponentBase : AbpComponentBase
{
    protected AssetManagementComponentBase()
    {
        // Set the localization resource for this component base
        LocalizationResource = typeof(AssetManagementResource);
    }

    // Override the OnParametersSet method to ensure that the localization resource is set properly
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        LocalizationResource = typeof(AssetManagementResource);
    }
}
