
using Newtonsoft.Json;
using System.Text.Json;

namespace Planner.UI.Extensions
{
    public static class JsonConvertExtension
    {
        public static string ToJson<T>(this T source) where T : class
        {
            var result = JsonConvert.SerializeObject(source);
            return result;
        }

        public static T ConvertTo<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
