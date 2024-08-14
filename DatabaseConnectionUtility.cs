using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Honeywell.Tools.DBUtility
{
    public class DatabaseConnectionUtility
    {
        public static string GetConnectionString(string dataBaseFullPath)
        {
            string connectionString = string.Empty;
            if (string.IsNullOrEmpty(dataBaseFullPath))
            {
                throw new Exception("Invalid argument");
            }
            string accessVersion = GetAccessVersion();
            if (string.IsNullOrEmpty(accessVersion))
            {
                throw new Exception("could not get MS Access version");
            }
            connectionString = DataBaseConstants.ConnectionProviderWithOutAccessVersion 
                + accessVersion + DataBaseConstants.DataSource + dataBaseFullPath + DataBaseConstants.ConnectionEngine;
            return connectionString;
        }

        public static string GetAccessVersion()
        {
            string accessVersion = string.Empty;
            string officeRegKey = GetOfficeRegKey();
            if (string.IsNullOrEmpty(officeRegKey))
            {
                throw new Exception("Error occured while determining MS Access version");
            }
            List<string> OfficeVersions = new List<string> { "15.0", "12.0" };
            foreach (string version in OfficeVersions)
            {
                RegistryKey regAccessInstallKey = GetHKLMSubKey(officeRegKey + version + @"\Access\InstallRoot");
                if (null != regAccessInstallKey)
                {
                    regAccessInstallKey.Close();
                    regAccessInstallKey.Dispose();
                    regAccessInstallKey = null;
                    accessVersion = version;
                    break;
                }
            }
            return accessVersion;
        }

        private static string GetOfficeRegKey()
        {
            string officeRegKey = string.Empty;
            RegistryKey regEnvKey = GetHKLMSubKey(DataBaseConstants.RegKey_ENV);
            if (null == regEnvKey)
            {
                throw new Exception("Could not get Registry key Environment");
            }
            string machineBit = regEnvKey.GetValue("PROCESSOR_ARCHITECTURE").ToString();

            if (machineBit.Contains("64"))
            {
                officeRegKey = @"SOFTWARE\Wow6432Node\Microsoft\Office\";
            }
            else if (machineBit.Contains("86"))
            {
                officeRegKey = @"SOFTWARE\Microsoft\Office\";
            }
            regEnvKey.Close();
            regEnvKey.Dispose();
            regEnvKey = null;
            return officeRegKey;
        }

        private static RegistryKey GetHKLMSubKey(string key)
        {
            return Registry.LocalMachine.OpenSubKey(key);
        }
    }
}
