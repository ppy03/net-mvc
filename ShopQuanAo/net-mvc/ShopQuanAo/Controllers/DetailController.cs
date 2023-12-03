using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAo.Models;

namespace ShopQuanAo.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Detail(string MASANPHAM)
        {
            SHOPAOQUANEntities1 db = new SHOPAOQUANEntities1();
            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();
            List<product> allproduct = db.product.ToList();
            List<size> sizes = db.size.ToList();
            product detailproduct = db.product.SingleOrDefault(p => p.id_product == MASANPHAM);

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            ViewBag.detailproducts = detailproduct;
            ViewBag.allproducts = allproduct;
            ViewBag.sizes = sizes;

            return View();
        }
    }
}