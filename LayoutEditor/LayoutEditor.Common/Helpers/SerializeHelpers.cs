using System.IO;
using System.Runtime.Serialization;

namespace LayoutEditor.Common.Helpers
{
    public static class SerializeHelpers
    {
        public static T DeepCopy<T>(this T objectTocopy)
        {
            T copy;
            var serializer = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, objectTocopy);
                ms.Position = 0;
                copy = (T)serializer.ReadObject(ms);
            }
            return copy;
        }
    }
}