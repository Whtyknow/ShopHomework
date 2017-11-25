using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopHomework.Cart
{
    public class CartProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
    }
}