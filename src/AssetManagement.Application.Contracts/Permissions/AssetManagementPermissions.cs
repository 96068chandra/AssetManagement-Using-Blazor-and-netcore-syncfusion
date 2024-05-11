// Namespace for all permission-related classes and constants in the Asset Management system.
namespace AssetManagement.Permissions
{
    // A static class containing permission names for the Asset Management system.
    // Permission names are defined as constants using a hierarchical naming convention.
    // The hierarchy is based on a group name, followed by a category name and a permission name,
    // separated by dots. This convention makes it easy to organize and manage permissions.
    public static class Names
    {
        // The name of the permission group for the Asset Management system.
        public const string GroupName = "AssetManagement";

        // The name of the category for product-related permissions.
        public const string ProductsCategory = "Products";

        // The name of the default permission for the Products category.
        public static readonly string ProductsDefault = $"{GroupName}.{ProductsCategory}.Default";

        // The name of the create permission for the Products category.
        public static readonly string ProductsCreate = $"{GroupName}.{ProductsCategory}.Create";

        // The name of the edit permission for the Products category.
        public static readonly string ProductsEdit = $"{GroupName}.{ProductsCategory}.Edit";

        // The name of the delete permission for the Products category.
        public static readonly string ProductsDelete = $"{GroupName}.{ProductsCategory}.Delete";

        // Add your own permission names here, following the same naming convention.
        // For example:
        // public static readonly string MyPermission1 = $"{GroupName}.MyPermission1";
    }
}
