using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DataCollector.Helpers
{
    public static class SetIE8KeyforWebBrowserControl
    {
        public static bool Init(string appName)
        {
            RegistryKey Regkey = null;
            try
            {
                if (Environment.Is64BitOperatingSystem)
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                else  
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);

                if (Regkey == null)
                {
                    return false;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                if (FindAppkey == "8000")
                {
                    Regkey.Close();
                    return true;
                }

                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)0x1F40), RegistryValueKind.DWord);

                FindAppkey = Convert.ToString(Regkey.GetValue(appName));
                return true; 
            }
            catch(Exception e)
            {
                return false;
            }
        }
         
    }
}
