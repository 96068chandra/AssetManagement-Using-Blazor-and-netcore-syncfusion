using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace AssetManagement;

[DependsOn(
    typeof(AbpSettingsModule)
)]
public class AssetManagementSettingsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpSettingDefinitionProviderOptions>(options =>
        {
            options.Providers.Add<AssetManagementSettingDefinitionProvider>();
        });
    }
}

namespace AssetManagement.Settings;

public class AssetManagementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AssetManagementSettings.MySetting1));
        context.Add(new SettingDefinition(AssetManagementSettings.MySetting1, "Default value", scoped: true));
    }
}

public static class AssetManagementSettings
{
    public const string MySetting1 = "AssetManagement:MySetting1";
}
