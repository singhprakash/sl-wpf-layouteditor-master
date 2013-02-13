using System.Linq;
using System.Reflection;

namespace LayoutEditor.Common.Helpers
{
    public static class FieldsHelper
    {
        public static void CopyProperties<T1, T2>(T1 destinationObject, T2 sourceObject)
            where T1 : class
            where T2 : class
        {
            PropertyInfo[] srcFields = sourceObject.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);

            PropertyInfo[] destFields = destinationObject.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            foreach (var property in destFields)
            {
                var source = srcFields.FirstOrDefault(x => x.Name == property.Name);
                if (source != null)
                {
                    property.SetValue(destinationObject, source.GetValue(sourceObject, null), null);
                }
                else
                {
                    var message = string.Format(
                        "Could not map property '{0}' on type '{1}' to type '{2}'",
                        property.Name,
                        destinationObject.GetType(),
                        sourceObject.GetType());
                    //throw new PropertyNotFoundException(message);
                }
            }
        }
    }
}