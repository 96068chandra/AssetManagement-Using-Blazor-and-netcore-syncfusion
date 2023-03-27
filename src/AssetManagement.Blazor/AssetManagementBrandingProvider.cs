using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AssetManagement.Blazor;

[Dependency(ReplaceServices = true)]
public class AssetManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AssetManagement";
}
