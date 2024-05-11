using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Bundling;
using Volo.Abp.Modularity;

namespace AssetManagement.Blazor
{
    [DependsOn(typeof(AbpBundlingModule))]
    public class AssetManagementBundleContributor : BundleContributorBase, ITransientDependency
    {
        public AssetManagementBundleContributor(IBundleRegistry bundleRegistry) : base(bundleRegistry)
        {
        }

        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("main.css", true);
            context.Files.Add("main.js", true);
        }

        protected override void OnConfigured(BundleConfigurationContext context)
        {
            if (context.BundleType == BundleType.Script)
            {
                context.Files.Add("vendor.js", true);
            }
        }

        protected override void OnContributed(BundleContributionContext context)
        {
            if (context.BundleType == BundleType.Style)
            {
                context.Files.Add("vendor.css", true);
            }
        }
    }
}
