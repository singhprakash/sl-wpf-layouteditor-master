
namespace LayoutEditor
{
    public static class ErrorHelper
    {
        public const string UserIdErrorMessage = "The UserId must be specified in InitParams";
        public const string LayoutPopulationEditorErrorMessage = "The LayoutPopulationEditor information was not found, the control cannot be used.  Note this problem can also occur if the user is not a premium user.";
        public const string SaveLayoutErrorMessage = "Your layout cannot be saved at the moment (the server is busy), please try again later.";
        public const string SaveFlagsErrorMessage = "Your settings cannot be saved at the moment (the server is busy), please try again later.";
    }
}