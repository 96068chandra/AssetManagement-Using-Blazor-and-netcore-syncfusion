using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AssetManagement;

[Dependency(ReplaceServices = true)]
public class AssetManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AssetManagement";
}
