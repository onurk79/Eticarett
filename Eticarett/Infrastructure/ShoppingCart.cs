using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticarett.Infrastructure
{
    public class ShoppingCart
    {
        private Entitie db = new Entitie();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            return null;
           
        }
        public static  ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddCart()
        {
            //Session
        }
    }
}