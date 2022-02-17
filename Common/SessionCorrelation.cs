using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AliveStoreTemplate.Common
{
    public static class CommonUtil
    {
        //session擴展，利用Newtonsoft.Json
        public static void SessionSetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T SessionGetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void Remove(this ISession session, string key)
        {
            session.Remove(key);
        }
    }

    public class CartItem
    {
        //商品ID
        public string ProductId { get; set; }
        //商品SpecId
        public string ProductSpecId { get; set; }
        //數量
        public int Amount { get; set; }
        //單價
        public int Price { get; set; }
        //小計
        public int SubTotal { get; set; }
    }

    public class ProductInSession
    {
        public string ProductId { get; set; }
        
    }
}
