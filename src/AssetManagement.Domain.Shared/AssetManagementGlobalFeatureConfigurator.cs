using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace AssetManagement;

[DependsOn(
    typeof(AbpFeatureManagementModule)
)]
public class AssetManagementGlobalFeatureConfigurator : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpFeatureManagementOptions>(options =>
        {
            options.Features.Add(
                new FeatureDescription(
                    AssetManagementGlobalFeatureNames.MyGlobalFeature,
                    "My sample global feature's description",
                    isEnabled: true // You can enable/disable the feature here
                )
            );
        });

        base.ConfigureServices(context);
    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(() =>
        {
            /* You can configure (enable/disable) global features of the used modules here.
             *
             * Please refer to the documentation to lear more about the Global Features System:
             * https://docs.abp.io/en/abp/latest/Global-Features
             */

            FeatureManager.SetFeatureEnabled(AssetManagementGlobalFeatureNames.MyGlobalFeature, true);
        });

        base.PostConfigureServices(context);
    }
}

public static class AssetManagementGlobalFeatureNames
{
    public const string MyGlobalFeature = "AssetManagement.MyGlobalFeature";
}
