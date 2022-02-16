﻿using Microsoft.AspNetCore.Http;
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

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }  //商品ID
        public int Amount { get; set; }     //數量
        public int SubTotal { get; set; }   //小計
    }

    public class CartItem : OrderItem
    {
        public ProductInSession Product { get; set; } //商品內容
        public string ImgSrc { get; set; } //商品圖片
    }

    public class ProductInSession
    {
        public string ProductId { get; set; }
        
    }
}
