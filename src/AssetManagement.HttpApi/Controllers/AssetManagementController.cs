using AssetManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;

namespace AssetManagement.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AssetManagementController : AbpController, ITransientDependency
{
    protected AssetManagementController()
    {
        LocalizationResource = typeof(AssetManagementResource);
    }

    protected override void AddValidationRules(CustomValidationContext context)
    {
        base.AddValidationRules(context);

        context.AddRules(GetValidationRules());
    }

    protected virtual List<IValidationRule> GetValidationRules()
    {
        return new List<IValidationRule>();
    }
}
