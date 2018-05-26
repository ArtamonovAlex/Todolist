using System;
using System.Web.Script.Serialization;

namespace TodoListLib
{
    public class JsonConverter
    {
        public static T GetObject<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(json);
        }
        public static string ToJson(object item)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(item);
        }
    }
}
