using System.Windows.Browser;

namespace LayoutEditor.Common.Helpers
{
    public static class JavaScriptBridge
    {
        // Passes info from the SilverLight control to JavaScript (avoids the need for WebMethods)
        // JavaScript function is currently in SilverlightLayoutEditor.aspx
        public static void InvokeJavaScriptOnOk(string pathToPreviewPng, string layoutId, string typeGroupInfoCSV, string numUsedWellsFirstPlate)
        {
            // Call JavaScript OnOk function and send PNG preview filename and layout id, etc. as parameters
            ScriptObject sFunc1 = (ScriptObject)HtmlPage.Window.GetProperty("onok");
            sFunc1.InvokeSelf(pathToPreviewPng, layoutId, typeGroupInfoCSV, numUsedWellsFirstPlate);
        }

        public static void InvokeJavaScriptOnCancel()
        {
            // Send Cancel back to JavaScript
            ScriptObject sFunc = (ScriptObject)HtmlPage.Window.GetProperty("oncancel");
            sFunc.InvokeSelf();
        }

        // Call the GetJsonLPE JavaScript function to get the JSON for LayoutPopulationEditor
        public static string InvokeJavaScriptGetJsonLPE()
        {
            ScriptObject sFunc = (ScriptObject)HtmlPage.Window.GetProperty("GetJsonLPE");
            return sFunc.InvokeSelf() as string;    // If this line fails then check the idprefix in SilverlightLayoutEditor.aspx.cs
            // Because the id may have changed if the container has been moved (roll on ASP.NET 4.0!)
        }

        public static void InvokeJavaScriptHelp(string address)
        {
            // Send Cancel back to JavaScript
            ScriptObject sFunc = (ScriptObject)HtmlPage.Window.GetProperty("Help");
            sFunc.InvokeSelf(address);
        }

        public static void InvokeJavaScriptOnOkFlagMode(string flaggedPositionHtml)
        {
            ScriptObject sFunc1 = (ScriptObject)HtmlPage.Window.GetProperty("onflagok");
            sFunc1.InvokeSelf(flaggedPositionHtml);
        }
    }
}