using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;

namespace DietifyConsult.Helper
{

    public static class WorkingWithSession
    {
        public static void SetObjectasJson(this ISession session, string Key, object value)
        {
            session.SetString(Key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string Key)
        {
            var value = session.GetString(Key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }

}
