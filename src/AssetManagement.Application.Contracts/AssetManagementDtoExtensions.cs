using System;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace AssetManagement
{
    public static class AssetManagementDtoExtensions
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        /// <summary>
        /// Configures extension properties for DTOs defined in the depended modules.
        /// </summary>
        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                /* You can add extension properties to DTOs
                 * defined in the depended modules.
                 *
                 * Example:
                 *
                 * ObjectExtensionManager.Instance
                 *   .AddOrUpdateProperty<IdentityRoleDto, string>("Title");
                 *
                 * See the documentation for more:
                 * https://docs.abp.io/en/abp/latest/Object-Extensions
                 */
            });
        }
    }
}
