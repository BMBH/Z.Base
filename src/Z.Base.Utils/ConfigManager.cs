using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Z.Base.Utils
{
    /// <summary>
    /// 提供对客户端应用程序配置文件的访问
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// </remarks>
    public static class ConfigManager
    {
        #region public static function

        #region 按键获取应用程序设置的文本
        /// <summary>
        /// 按键获取应用程序设置的文本
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="configName">config配置文件，默认null</param>
        /// <returns>文本</returns>
        public static string StringVal(string key, string configName = null)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;

            Configuration configuration = Configuration(configName);
            if (configuration == null || configuration.AppSettings.Settings.Count <= 0)
                return string.Empty;
            if (configuration.AppSettings.Settings.AllKeys.Contains(key))
                return configuration.AppSettings.Settings[key].Value;
            return string.Empty;
        }
        #endregion

        #region 按键获取应用程序设置的布尔值
        /// <summary>
        /// 按键获取应用程序设置的布尔值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="configName">config配置文件，默认null</param>
        /// <returns>布尔值</returns>
        public static bool BoolVal(string key, string configName = null)
        {
            string val = StringVal(key, configName);
            if (string.IsNullOrEmpty(val))
                return false;

            bool temp = false;
            bool result = bool.TryParse(val, out temp);
            if (result)
                return temp;

            return false;
        }
        #endregion

        #region 按键获取应用程序设置的整数
        /// <summary>
        /// 按键获取应用程序设置的整数
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="configName">config配置文件，默认null</param>
        /// <returns>整数</returns>
        public static int IntVal(string key, string configName = null)
        {
            string val = StringVal(key, configName);
            if (string.IsNullOrEmpty(val))
                return -1;

            int temp = -1;
            bool result = int.TryParse(val, out temp);
            if (result)
                return temp;

            return -1;
        }
        #endregion

        #region 按键获取应用程序设置的单精度浮点数值
        /// <summary>
        /// 按键获取应用程序设置的单精度浮点数值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="configName">config配置文件，默认null</param>
        /// <returns>单精度浮点数值</returns>
        public static float FloatVal(string key, string configName = null)
        {
            string val = StringVal(key, configName);
            if (string.IsNullOrEmpty(val))
                return -1f;

            float temp = -1f;
            bool result = float.TryParse(val, out temp);
            if (result)
                return temp;

            return -1f;
        }
        #endregion

        #region 按键移除应用程序设置
        /// <summary>
        /// 按键移除应用程序设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="configName"></param>
        public static bool RemoveKey(string key, string configName = null)
        {
            if (key.IsEmpty())
                return false;

            Configuration configuration = Configuration(configName);
            if (configuration == null || configuration.AppSettings.Settings.Count <= 0)
                return false;

            if (configuration.AppSettings.Settings.AllKeys.Contains(key))
            {
                configuration.AppSettings.Settings.Remove(key);
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            return false;
        }
        #endregion

        #region 按键值设置应用程序配置
        /// <summary>
        /// 按键值设置应用程序配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="configName"></param>
        public static void SetValue(string key, string value, string configName = null)
        {
            if (key.IsEmpty() || value.IsEmpty()) return;

            Configuration configuration = Configuration(configName);
            if (configuration == null || configuration.AppSettings.Settings.Count <= 0)
                return;
            PerformSet(key, value, configuration);
        }
        #endregion

        #endregion

        #region private static function

        #region 按 fileName 和 dir 生成适用于特定计算机、应用程序或资源的配置文件操作的对象
        /// <summary>
        /// 按 fileName 和 dir 生成适用于特定计算机、应用程序或资源的配置文件操作的对象
        /// </summary>
        /// <param name="configName">文件名称</param>
        /// <param name="dir">路径，默认""</param>
        /// <returns>表示适用于特定计算机、应用程序或资源的配置文件的对象实例</returns>
        private static Configuration Configuration(string configName, string dir = "")
        {
            if (configName.IsEmpty() || dir == null)//路径不满足条件则返回默认App.Config
                return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir);//组合路径

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();//组合对象
            configFileMap.ExeConfigFilename = Path.Combine(path, configName);

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            return config;
        }
        #endregion

        #region 执行应用程序配置设置
        /// <summary>
        /// 执行应用程序配置设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="configuration"></param>
        private static void PerformSet(string key, string value, Configuration configuration)
        {
            if (configuration.AppSettings.Settings.AllKeys.Contains(key))
            {
                configuration.AppSettings.Settings[key].Value = value;
            }
            else
            {
                configuration.AppSettings.Settings.Add(key, value);
            }
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion

        #endregion
    }
}
