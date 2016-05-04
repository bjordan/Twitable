using System;
using System.Configuration;

namespace Twitable.Utils
{
    public static class Config
    {
        public static string LoggingFolder
        {
            get
            {
                return ReadSetting("LoggingFolder");
            }
        }
        public static string SourceDirectory
        {
            get
            {
                return ReadSetting("SourceDirectory");
            }
        }

        public static string UserFile
        {
            get
            {
                return ReadSetting("UserFile");
            }
        }
        public static string Tweets
        {
            get
            {
                return ReadSetting("Tweets");
            }
        }

        public static string TweetRepositoryProvider
        {
            get
            {
                return ReadSetting("TweetRepositoryProvider");
            }
        }

        public static string UserRepositoryProvider
        {
            get
            {
                return ReadSetting("UserRepositoryProvider");
            }
        }
        private static string ReadSetting(string key)
        {
            string str;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                str = appSettings[key] ?? string.Format("The Key {0} was not found",key);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new Exception(string.Format("Error: Cannot find the setting '{0}' in the configuration file", key), ex);
            }
            return str;
        }

        private static string ReadConnectionString(string key)
        {
            string str;
            try
            {
                var conStrings = ConfigurationManager.ConnectionStrings;
                str = conStrings[key] != null ? conStrings[key].ConnectionString : string.Format("The Key {0} was not found", key);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new Exception(string.Format("Error: Cannot find the connection string '{0}' in the configuration file", key), ex);
            }
            return str;
        }
    }
}
