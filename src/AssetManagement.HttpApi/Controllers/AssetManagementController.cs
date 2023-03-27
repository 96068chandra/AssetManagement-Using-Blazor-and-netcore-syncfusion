using AssetManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AssetManagement.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AssetManagementController : AbpControllerBase
{
    protected AssetManagementController()
    {
        LocalizationResource = typeof(AssetManagementResource);
    }
}
