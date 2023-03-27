using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Localization;
using Volo.Abp.Application.Services;

namespace AssetManagement;

/* Inherit your application services from this class.
 */
public abstract class AssetManagementAppService : ApplicationService
{
    protected AssetManagementAppService()
    {
        LocalizationResource = typeof(AssetManagementResource);
    }
}
