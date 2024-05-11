using System;
using System.Net.Http;
using System.Reflection;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AssetManagement.Blazor.Menus;
using OpenIddict.Abstractions;
using Volo.Abp.AspNetCore.Components.WebAssembly.LeptonXLiteTheme;
using Volo.Abp.AspNetCore.Components.Web.LeptonXLiteTheme.Themes.LeptonXLite;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Identity.Blazor.WebAssembly;
using Volo.Abp.SettingManagement.Blazor.WebAssembly;
using Volo.Abp.TenantManagement.Blazor.WebAssembly;

namespace AssetManagement.Blazor;

[DependsOn(
    typeof(AbpAutofacWebAssemblyModule),
    typeof(AssetManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyLeptonXLiteThemeModule),
    typeof(AbpIdentityBlazorWebAssemblyModule),
    typeof(AbpTenantManagementBlazorWebAssemblyModule),
    typeof(AbpSettingManagementBlazorWebAssemblyModule)
)]
public class AssetManagementBlazorModule : AbpModule
{
    private readonly IWebAssemblyHostEnvironment _environment;
    private readonly WebAssemblyHostBuilder _builder;

    public AssetManagementBlazorModule(IWebAssemblyHostEnvironment environment, WebAssemblyHostBuilder builder)
    {
        _environment = environment;
        _builder = builder;
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureAuthentication();
        ConfigureHttpClient(context);
        ConfigureBlazorise(context);
        ConfigureRouter(context);
        ConfigureUI();
        ConfigureMenu(context);
        ConfigureAutoMapper(context);
    }

    private void ConfigureAuthentication()
    {
        _builder.Services.AddOidcAuthentication(options =>
        {
            _builder.Configuration.Bind("AuthServer", options.ProviderOptions);
            options.UserOptions.NameClaim = OpenIddictConstants.Claims.Name;
            options.UserOptions.RoleClaim = OpenIddictConstants.Claims.Role;

            options.ProviderOptions.DefaultScopes.Add("AssetManagement");
            options.ProviderOptions.DefaultScopes.Add("roles");
            options.ProviderOptions.DefaultScopes.Add("email");
            options.ProviderOptions.DefaultScopes.Add("phone");
        });
    }

    private void ConfigureHttpClient(ServiceConfigurationContext context)
    {
        context.Services.AddTransient<HttpClient>(sp =>
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_environment.BaseAddress);
            return client;
        });
    }

    private void ConfigureBlazorise(ServiceConfigurationContext context)
    {
        context.Services
            .AddBootstrap5Providers()
            .AddFontAwesomeIcons();
    }

    private void ConfigureRouter(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AppAssembly = typeof(AssetManagementBlazorModule).Assembly;
        });
    }

    private void ConfigureMenu(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new AssetManagementMenuContributor(context.Services.GetConfiguration()));
        });
    }

    private void ConfigureUI()
    {
        _builder.RootComponents.Add<App>("#ApplicationContainer");
    }

    private void ConfigureAutoMapper(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps(Assembly.GetAssembly(typeof(AssetManagementBlazorModule)));
        });
    }
}
