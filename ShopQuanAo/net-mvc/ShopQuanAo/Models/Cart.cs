using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Models
{
    public class CartItem
    {
        public product shopping_product { get; set; }
        public int shopping_quantity { get; set; }
        public string shopping_size { get; set; }
}
    // gio hang
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(product pro, int quantity, string size)
        {
            var item = items.FirstOrDefault(s => s.shopping_product.id_product == pro.id_product);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    shopping_product = pro,
                    shopping_quantity = quantity,
                    shopping_size = size
                }) ;
            }
            else
            {
                item.shopping_quantity += quantity;
            }        
        }
        public void Update_Quantity(string pro, int quantity ,string size )
        {
            var item = items.Find(s => s.shopping_product.id_product == pro);
            if(item != null)
            {
                item.shopping_quantity = quantity;
                item.shopping_size = size;
              
            }
        }
        public double Total_Money()
        {
            var total = items.Sum(s => s.shopping_product.price_new * s.shopping_quantity);
            return (double)total;
        }
        public void Remove_CartItem(string id)
        {
            items.RemoveAll(s => s.shopping_product.id_product == id);
        }
    }
}