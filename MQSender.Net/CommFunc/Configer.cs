using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MQSender.Net
{
    class Configer
    {
        private static Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public static Configuration AppConfig { get { return appConfig; } }

        public static KeyValueConfigurationCollection Settings { get { return appConfig.AppSettings.Settings; } }

        public static string GetSettingsValue(string key, string defaultValue = "")
        {
            return Settings[key] == null ? defaultValue : Settings[key].Value;
        }

        public static void SetSettingsValue(string key, string value)
        {
            if (Settings[key] == null)
            {
                Settings.Add(key, value);
            }
            else
            {
                Settings[key].Value = value;
            }

            AppConfig.Save();
        }
    }
}