using Volo.Abp.Settings;

namespace AssetManagement.Settings;

public class AssetManagementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AssetManagementSettings.MySetting1));
    }
}
