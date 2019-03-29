using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Z.Base.Utils
{
    /// <summary>
    /// config配置管理类
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
        /// <param name="config">config配置文件，默认null</param>
        /// <returns>文本</returns>
        public static string StringVal(string key, string config = null)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;
            if (string.IsNullOrEmpty(config))//提供为空的情况
                return ConfigurationManager.AppSettings[key];

            Configuration configuration = ConfigManager.Configuration(config);
            if (configuration == null)
                return string.Empty;
            return configuration.AppSettings.Settings[key].Value;
        }
        #endregion

        #region 按键获取应用程序设置的布尔值
        /// <summary>
        /// 按键获取应用程序设置的布尔值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="config">config配置文件，默认null</param>
        /// <returns>布尔值</returns>
        public static bool BoolVal(string key, string config = null)
        {
            string val = StringVal(key, config);
            if (string.IsNullOrEmpty(val))
                return false;

            bool temp = false;
            bool result = bool.TryParse(val,out temp);
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
        /// <param name="config">config配置文件，默认null</param>
        /// <returns>整数</returns>
        public static int IntVal(string key, string config = null)
        {
            string val = StringVal(key, config);
            if (string.IsNullOrEmpty(val))
                return 0;

            int temp = 0;
            bool result = int.TryParse(val, out temp);
            if (result)
                return temp;

            return 0;
        }
        #endregion

        #region 按键获取应用程序设置的单精度浮点数值
        /// <summary>
        /// 按键获取应用程序设置的单精度浮点数值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="config">config配置文件，默认null</param>
        /// <returns>单精度浮点数值</returns>
        public static float FloatVal(string key, string config = null)
        {
            string val = StringVal(key, config);
            if (string.IsNullOrEmpty(val))
                return 0f;

            float temp = 0f;
            bool result = float.TryParse(val, out temp);
            if (result)
                return temp;

            return 0f;
        }
        #endregion

        #endregion

        #region private static function

        #region 适用于特定计算机、应用程序或资源的配置文件
        /// <summary>
        /// 适用于特定计算机、应用程序或资源的配置文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="dir">路径，默认""</param>
        /// <returns>Configuration对象</returns>
        private static Configuration Configuration(string fileName, string dir = "")
        {
            if (string.IsNullOrEmpty(fileName) || dir == null)
                return null;
            string path = Path.Combine(FileManager.BaseDirectory(), dir);

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = Path.Combine(path, fileName);

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            return config;
        }
        #endregion

        #endregion
    }
}
