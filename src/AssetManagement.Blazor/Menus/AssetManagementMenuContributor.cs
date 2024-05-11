using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace AssetManagement.Blazor.Menus
{
    public class AssetManagementMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public AssetManagementMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private void AddAssetManagementMenuItem(MenuConfigurationContext context, string url)
        {
            var l = context.GetLocalizer<AssetManagementResource>();

            context.Menu.AddItem(
                new ApplicationMenuItem(
                    "AssetManagement",
                    l["Menu:AssetManagement"],
                    icon: "fa fa-book")
                    .AddItem(
                        new ApplicationMenuItem(
                            "AssetManagement.Products",
                            l["Menu:Products"],
                            url: url
                        )
                    )
            );
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<AssetManagementResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    AssetManagementMenus.Home,
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            AddAssetManagementMenuItem(context, "/products");

            var administration = context.Menu.GetAdministration();

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

            return Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            if (!_configuration.GetSection("AuthServer").Exists())
            {
                return Task.CompletedTask;
            }

            var accountStringLocalizer = context.GetLocalizer<AccountResource>();

            if (!_configuration.GetSection("AuthServer:Authority").Exists())
            {
                return Task.CompletedTask;
            }

            var authServerUrl = _configuration["AuthServer:Authority"] ?? "";

            context.Menu.AddItem(new ApplicationMenuItem(
                "Account.Manage",
                accountStringLocalizer["MyAccount"],
                $"{authServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}",
                icon: "fa fa-cog",
                order: 1000,
                null).RequireAuthenticated());

            return Task.CompletedTask;
        }
    }
}
