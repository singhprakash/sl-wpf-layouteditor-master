using System;
using System.Windows;
using System.Windows.Browser;
using LayoutEditor.Common.Helpers;
using LayoutEditor.Common.Services;
using Microsoft.Practices.ServiceLocation;

namespace LayoutEditor
{
    public partial class App : Application
    {
        public App()
        {
            // Safari running on Windows with Silverlight 5 installed causes a problem
            if ((HtmlPage.BrowserInformation.ProductName == "Safari") &&
                 (Environment.Version.Major == 5) &&
                    (
                        (Environment.OSVersion.Platform == PlatformID.Win32NT) ||
                        (Environment.OSVersion.Platform == PlatformID.Win32Windows) ||
                        (Environment.OSVersion.Platform == PlatformID.Win32S)
                    )
                )
            {
                MessageBox.Show("Safari for Windows is not a platform supported by Microsoft Silverlight 5.  Please install Silverlight 4 or use a different browser.  Contact support@myassays.com for more information.", "Warning", MessageBoxButton.OK);
                JavaScriptBridge.InvokeJavaScriptOnCancel();
                throw new InvalidOperationException("Platform not supported by Silverlight");
            }

            this.Startup += this.Application_Startup;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();

            var userSettingsService = ServiceLocator.Current.GetInstance<IUserSettingsService>();
            userSettingsService.FillSettings(e);
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}