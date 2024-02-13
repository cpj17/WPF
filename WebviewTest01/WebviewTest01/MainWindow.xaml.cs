using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WebviewTest01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Enable feature emulation for the WebBrowser control
            SetWebBrowserFeatureControl();

            // Navigate to the web page
            webBrowser.Navigate(new Uri("https://gsgate.gurusofttech.com/cloud51/PRDG11EOSV03WD/PRDG11EOSV03WB_TMS/WTR8503R1V1?ID=PEXPORTAL"));
        }

        private void SetWebBrowserFeatureControl()
        {
            const string appName = "YourAppName.exe";

            // Feature control settings are per-process
            var featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";

            // Set FEATURE_BROWSER_EMULATION
            Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
                appName, GetBrowserEmulationMode(), RegistryValueKind.DWord);
        }

        private int GetBrowserEmulationMode()
        {
            int browserEmulationMode = 11001; // IE11 edge mode

            switch (System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)
            {
                // Add more cases as needed for other applications
                case "YourAppName":
                    browserEmulationMode = 11001; // IE11 edge mode
                    break;
            }

            return browserEmulationMode;
        }
    }
}
