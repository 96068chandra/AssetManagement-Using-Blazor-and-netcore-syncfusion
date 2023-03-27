using AssetManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AssetManagement.Permissions;

public class AssetManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AssetManagementPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AssetManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AssetManagementResource>(name);
    }
}
