using AliveStoreTemplate.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Collections.Generic;
using AliveStoreTemplate.Model.DTOModel;

namespace AliveStoreTemplate.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class SessionController : ControllerBase
    {

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddProductToCarBySession([FromBody]AddToCarReqModel Req)
        {
            try 
            {
                //帶個大概
                //建立下訂商品
                CartItem item = new CartItem
                {
                    //商品ID
                    ProductId = Req.ProductId,
                    //商品款式ID
                    ProductSpecId = Req.ProductSpecId,
                    //下訂數量
                    Amount = Req.OrderNum,
                    //小計
                    SubTotal = Req.Price * Req.OrderNum
                };

                //判斷是否有購物車
                if (Common.CommonUtil.SessionGetObject<List<CartItem>>(HttpContext.Session, "cart") == null)
                {
                    //沒有就新增
                    List<CartItem> cart = new List<CartItem>();
                    cart.Add(item);
                    Common.CommonUtil.SessionSetObject(HttpContext.Session, "cart", cart);
                }
                else
                {
                    //如果購物車存在
                    List<CartItem> cart = Common.CommonUtil.SessionGetObject<List<CartItem>>(HttpContext.Session, "cart");
                    //檢查購物車中是否包含同樣商品
                    int index = cart.FindIndex(x => x.ProductId.Equals(Req.ProductId) && x.ProductSpecId.Equals(Req.ProductSpecId));
                    if (index != -1)
                    {
                        cart[index].Amount += item.Amount;
                        cart[index].SubTotal += item.SubTotal;
                    }
                    else
                    {
                        cart.Add(item);
                    }
                    Common.CommonUtil.SessionSetObject(HttpContext.Session, "cart", cart);
                }
                
                //Test
                List<CartItem> testObj = Common.CommonUtil.SessionGetObject<List<CartItem>>(HttpContext.Session, "cart");
                return Ok(testObj);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetProductFromCarBySession()
        {
            try
            {
                List<CartItem> cart = Common.CommonUtil.SessionGetObject<List<CartItem>>(HttpContext.Session, "cart");
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
