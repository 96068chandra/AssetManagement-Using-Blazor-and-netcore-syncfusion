using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssetManagement.Localization;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace AssetManagement
{
    /* Inherit your application services from this class.
     */
    public abstract class AssetManagementAppService : CrudAppService<AssetManagementItem, Guid>, IAssetManagementAppService
    {
        protected AssetManagementAppService()
            : base()
        {
            LocalizationResource = typeof(AssetManagementResource);
        }
    }

    public interface IAssetManagementAppService : ICrudAppService<AssetManagementItem, Guid>
    {
    }

    [RemoteService(false)]
    public class AssetManagementItemController : AssetManagementAppService, IAssetManagementItemAppService
    {
        public AssetManagementItemController()
        {
        }
    }

    public interface IAssetManagementItemAppService : ICrudAppService<AssetManagementItem, Guid>
    {
    }
}
