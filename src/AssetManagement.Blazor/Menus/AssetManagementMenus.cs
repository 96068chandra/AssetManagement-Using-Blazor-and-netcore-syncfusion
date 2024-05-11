using System.Collections.Immutable;

namespace AssetManagement.Blazor.Menus
{
    public class AssetManagementMenus
    {
        // Use readonly fields to ensure the prefix is only set once and cannot be changed later
        private readonly string _prefix = "AssetManagement";

        // Use a read-only collection to store the menu items
        private readonly IReadOnlyCollection<string> _menuItems;

        // Constructor to initialize the menu items
        public AssetManagementMenus()
        {
            // Use an array to define the menu items and then convert it to an immutable collection
            var menuItems = new[]
            {
                $"{_prefix}.Home",
                $"{_prefix}.Assets",
                $"{_prefix}.AssetTypes",
                $"{_prefix}.Reports",
            };

            _menuItems = menuItems.ToImmutableArray();
        }

        // Property to access the prefix
        public string Prefix => _prefix;

        // Property to access the menu items
        public IReadOnlyCollection<string> MenuItems => _menuItems;
    }
}
