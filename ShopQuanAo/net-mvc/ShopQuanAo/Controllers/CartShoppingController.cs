﻿using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class CartShoppingController : Controller
    {
        SHOPAOQUANEntities1 db = new SHOPAOQUANEntities1();
        // GET: CartShopping
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ActionResult AddToCart(string MASANPHAM, int quantity, string size, string type = "Normal")
        {
            string userName = Session["LoggedInUser"] as string;
            // Kiểm tra xem user đã đăng nhập
            if (Session["LoggedInUser"] != null)
            {
                using (var db = new SHOPAOQUANEntities1())
                {
                    var pro = db.product.SingleOrDefault(s => s.id_product == MASANPHAM);
                    var user = db.User.FirstOrDefault(u => u.name_user == userName);

                    // Kiểm tra xem sản phẩm và user có giá trị hay k
                    if (pro != null && user != null)
                    {
                        GetCart().Add(pro, quantity, size);
                        return RedirectToAction("ShowToCart", "CartShopping");
                    }
                }
            }

            // Nếu ch đăng nhập trả về trang đăng nhập
            return RedirectToAction("Index", "Login");
        }

        public ActionResult ShowToCart()
        {
            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "CartShopping");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            string[] id_pro = form.GetValues("id_product");
           string[] quantity = form.GetValues("quantity");
            string[] size = form.GetValues("size");
            for(int i = 0; i < id_pro.Length; i++)
            {
                cart.Update_Quantity(id_pro[i], int.Parse(quantity[i]), size[i]);

            }
            return RedirectToAction("ShowToCart", "CartShopping");
        }
        public ActionResult RemoveCart (string MASANPHAM)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(MASANPHAM);
            return RedirectToAction("ShowToCart", "CartShopping");
        }
    }

}