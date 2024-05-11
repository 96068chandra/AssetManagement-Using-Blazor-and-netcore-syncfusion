using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AssetManagement;

[Dependency(ReplaceServices = true)]
public class AssetManagementBrandingProvider : DefaultBrandingProvider
{
    public AssetManagementBrandingProvider()
    {
        AppName = "AssetManagement";
    }

    public override string AppName { get; }
}
