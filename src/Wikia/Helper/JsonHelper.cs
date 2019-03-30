using Newtonsoft.Json;

namespace wikia.Helper
{
    public class JsonHelper
    {
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}