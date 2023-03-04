using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace AnadoluParamApi.Base.Extensions
{
    public static class SessionHelper
    {
        //Set
        public static void SetProductJson(this ISession session, string key, object value) //Users will use this session when creating carts.
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //Get
        public static T GetProductJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
