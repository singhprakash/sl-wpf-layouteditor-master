using System.Web.UI;

namespace LayoutEditor.Web
{
    public partial class LayoutEditorTestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string config = Page.Request["config"];
            if (string.IsNullOrEmpty(config))
            {
                ConfigNum = 0;
            }
            else
            {
                ConfigNum = int.Parse(config);
            }
        }


        public string GetLayoutId()
        {
            string id = Page.Request["id"];
            return id == null ? string.Empty : id;
        }

        public string GetUserId()
        {
            return "userid";
        }

        public string GetServiceAddress()
        {
            return "/ServiceLayouts.svc";
        }

        public string GetAssociatedAssayId()
        {
            return "1";
        }

        private string GetOptionalRequestParameterString(string id)
        {
            string value = Page.Request[id];
            return value == null ? "0" : value;
        }

        private string ConvertRequestParameterToBoolString(string id)
        {
            string value = Page.Request[id];
            if (string.IsNullOrEmpty(value))
            {
                return "false";
            }
            return bool.Parse(value).ToString().ToLower(); // Ensure it is "true" or "false"
        }

        public string GetIsPreviousRunEdit()
        {
            return ConvertRequestParameterToBoolString("prevRunEdit");
        }

        public string GetIsFlagMode()
        {
            return ConvertRequestParameterToBoolString("flagMode");
        }

        public string GetPreviousRunId()
        {
            return GetOptionalRequestParameterString("prevRunId");
        }

        public string GetPreviousRunOriginator()
        {
            return GetOptionalRequestParameterString("prevRunOriginator");
        }

        public int ConfigNum { get; private set; }
    }
}