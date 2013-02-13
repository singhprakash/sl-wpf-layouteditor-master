using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace LayoutEditor.Common.Helpers
{
    internal static class JsonHelpers
    {
        static public object Deserialize(string json, Type type)
        {
            Debug.Assert(json != null);

            //  Add a reference to: System.Runtime.Serialization   and
            //                      System.ServiceModel.Web
            byte[] parmsBytes = Encoding.UTF8.GetBytes(json);
            using (var ms = new MemoryStream())
            {
                ms.Write(parmsBytes, 0, parmsBytes.Length);
                var ser = new DataContractJsonSerializer(type);
                return ser.ReadObject(ms);
            }
        }
    }
}