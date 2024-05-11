using AssetManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AssetManagement.Permissions;

public class AssetManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var assetManagementGroup = context.AddGroup(AssetManagementPermissions.GroupName, L("Permission:AssetManagement"));

        var productPermission = AddPermission(assetManagementGroup, AssetManagementPermissions.Products.Default, L("Permission:Products"));
        AddChildPermissions(productPermission, AssetManagementPermissions.Products.Create, L("Permission:Products.Create"),
            AssetManagementPermissions.Products.Edit, L("Permission:Products.Edit"), AssetManagementPermissions.Products.Delete, L("Permission:Products.Delete"));
    }

    private static PermissionDefinition AddPermission(IPermissionGroupDefinition group, string name, LocalizableString displayName)
    {
        return group.AddPermission(name, displayName);
    }

    private static void AddChildPermissions(PermissionDefinition parent, params (string name, LocalizableString displayName)[] children)
    {
        foreach (var child in children)
        {
            parent.AddChild(child.name, child.displayName);
        }
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AssetManagementResource>(name);
    }
}
