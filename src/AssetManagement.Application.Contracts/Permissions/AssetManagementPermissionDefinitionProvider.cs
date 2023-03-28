using AssetManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AssetManagement.Permissions;

public class AssetManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var AssetManagementGroup = context.AddGroup(AssetManagementPermissions.GroupName, L("Permission:AssetManagement"));
       
        var productPermission = AssetManagementGroup.AddPermission(AssetManagementPermissions.Products.Default, L("Permission:Products"));
        productPermission.AddChild(AssetManagementPermissions.Products.Create, L("Permission:Products.Create"));
        productPermission.AddChild(AssetManagementPermissions.Products.Edit, L("Permission:Products.Edit"));
        productPermission.AddChild(AssetManagementPermissions.Products.Delete, L("Permission:Products.Delete"));
    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AssetManagementResource>(name);
    }
}
