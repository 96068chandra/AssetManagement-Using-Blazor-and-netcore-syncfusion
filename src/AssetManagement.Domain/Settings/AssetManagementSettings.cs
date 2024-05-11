using System;

namespace AssetManagement.Settings
{
    public static class AssetManagementSettings
    {
        private const string Prefix = "AssetManagement.";

        public static string GetSetting(string name)
        {
            return GetSetting(Prefix + name);
        }

        public static void SetSetting(string name, string value)
        {
            SetSetting(Prefix + name, value);
        }

        public static string GetSetting(string name, string defaultValue)
        {
            return ConfigurationManager.AppSettings.Get(name) ?? defaultValue;
        }

        public static void SetSetting(string name, string value)
        {
            ConfigurationManager.AppSettings[name] = value;
            ConfigurationManager.Save();
        }
    }
}
