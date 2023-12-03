using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class SanphamController : Controller
    {
        // GET: Sanpham
        public ActionResult Sanpham()
        {
            SHOPAOQUANEntities1 db = new SHOPAOQUANEntities1();

            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            List<product> spbatki = GetRandomProductsByLowQuantity(db, 15);
            var productGroupsspbki = new List<List<product>>();
            for (int i = 0; i < 15; i += 3)
            {
                productGroupsspbki.Add(spbatki.Skip(i).Take(3).ToList());
            }

            List<product> spmax = GetTopProductsByQuantity(db, 15);
            var productGroupmax = new List<List<product>>();
            for (int i = 0; i < 15; i += 3)
            {
                productGroupmax.Add(spmax.Skip(i).Take(3).ToList());
            }

            List<product> spgiamax = GetTopProductsByPrice(db, 25);
            List<product> allproducts = GetRandomProduct(db, 40);
            List<product> product = GetProducts(db);



            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            ViewBag.productsspbki = productGroupsspbki;
            ViewBag.productsmax = productGroupmax;
            ViewBag.productsgiamax = spgiamax;
            ViewBag.productalls = allproducts;
            ViewBag.productall = product;

            return View();
        }
       
        private List<product> GetTopProductsByQuantity(SHOPAOQUANEntities1 db, int count)
        {
            return db.product.OrderByDescending(p => p.quantity).Take(count).ToList();
        }

        // random sanpham với số lượng ít nhất(15sp)
        private List<product> GetRandomProductsByLowQuantity(SHOPAOQUANEntities1 db, int count)
        {
            List<product> productsWithLowQuantity = db.product.OrderBy(p => p.quantity).Take(count).ToList();
            if (count >= productsWithLowQuantity.Count)
            {
                return productsWithLowQuantity.OrderBy(x => Guid.NewGuid()).ToList();
            }
            else
            {
                List<product> randomProducts = new List<product>();
                Random random = new Random();
                while (randomProducts.Count < count)
                {
                    int randomIndex = random.Next(productsWithLowQuantity.Count);
                    product selectedProduct = productsWithLowQuantity[randomIndex];

                    if (!randomProducts.Contains(selectedProduct))
                    {
                        randomProducts.Add(selectedProduct);
                    }
                }
                return randomProducts;
            }
        }

        // random san pham bat ki(40sp)
        private List<product> GetRandomProduct(SHOPAOQUANEntities1 db, int count)
        {
            List<product> allProducts = db.product.ToList();

            if (count >= allProducts.Count)
            {
                return allProducts.OrderBy(x => Guid.NewGuid()).ToList();
            }
            else
            {
                List<product> randomProducts = new List<product>();
                Random random = new Random();

                while (randomProducts.Count < count)
                {
                    int randomIndex = random.Next(allProducts.Count);
                    product selectedProduct = allProducts[randomIndex];

                    if (!randomProducts.Contains(selectedProduct))
                    {
                        randomProducts.Add(selectedProduct);
                    }
                }
                return randomProducts;
            }
        }

        // lấy ra sản phẩm có giá cao nhất (25sp)
        private List<product> GetTopProductsByPrice(SHOPAOQUANEntities1 db, int count)
        {
            return db.product.OrderByDescending(p => p.price_new).Take(count).ToList();
        }

        private List<product> GetProducts(SHOPAOQUANEntities1 db)
        {
            return db.product.ToList();
        }

        // sản phẩm nữ
        public ActionResult sanphamnu()

        {
            SHOPAOQUANEntities1 db = new SHOPAOQUANEntities1();

            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            List<product> spbatki = GetRandomProductsByLowQuantity(db, 15);
            var productGroupsspbki = new List<List<product>>();
            for (int i = 0; i < 15; i += 3)
            {
                productGroupsspbki.Add(spbatki.Skip(i).Take(3).ToList());
            }

            List<product> spmax = GetTopProductsByQuantity(db, 15);
            var productGroupmax = new List<List<product>>();
            for (int i = 0; i < 15; i += 3)
            {
                productGroupmax.Add(spmax.Skip(i).Take(3).ToList());
            }

            List<product> spgiamax = GetTopProductsByPrice(db, 25);
            List<product> allproducts = GetRandomProduct(db, 40);
            List<product> product = GetProducts(db);



            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            ViewBag.productsspbki = productGroupsspbki;
            ViewBag.productsmax = productGroupmax;
            ViewBag.productsgiamax = spgiamax;
            ViewBag.productalls = allproducts;
            ViewBag.productall = product;
            return View();
        }

        //thời trang trẻ em
        public ActionResult treem()

        {
            SHOPAOQUANEntities1 db = new SHOPAOQUANEntities1();

            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            List<product> spbatki = GetRandomProductsByLowQuantity(db, 15);
            var productGroupsspbki = new List<List<product>>();
            for (int i = 0; i < 15; i += 3)
            {
                productGroupsspbki.Add(spbatki.Skip(i).Take(3).ToList());
            }

            List<product> spmax = GetTopProductsByQuantity(db, 15);
            var productGroupmax = new List<List<product>>();
            for (int i = 0; i < 15; i += 3)
            {
                productGroupmax.Add(spmax.Skip(i).Take(3).ToList());
            }

            List<product> spgiamax = GetTopProductsByPrice(db, 25);
            List<product> allproducts = GetRandomProduct(db, 40);
            List<product> product = GetProducts(db);



            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            ViewBag.productsspbki = productGroupsspbki;
            ViewBag.productsmax = productGroupmax;
            ViewBag.productsgiamax = spgiamax;
            ViewBag.productalls = allproducts;
            ViewBag.productall = product;
            return View();
        }

        //thể thao
        public ActionResult thethao()

        {
            SHOPAOQUANEntities1 db = new SHOPAOQUANEntities1();

            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            List<product> spbatki = GetRandomProductsByLowQuantity(db, 15);
            var productGroupsspbki = new List<List<product>>();
            for (int i = 0; i < 15; i += 3)
            {
                productGroupsspbki.Add(spbatki.Skip(i).Take(3).ToList());
            }

            List<product> spmax = GetTopProductsByQuantity(db, 15);
            var productGroupmax = new List<List<product>>();
            for (int i = 0; i < 15; i += 3)
            {
                productGroupmax.Add(spmax.Skip(i).Take(3).ToList());
            }

            List<product> spgiamax = GetTopProductsByPrice(db, 25);
            List<product> allproducts = GetRandomProduct(db, 40);
            List<product> product = GetProducts(db);




            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            ViewBag.productsspbki = productGroupsspbki;
            ViewBag.productsmax = productGroupmax;
            ViewBag.productsgiamax = spgiamax;
            ViewBag.productalls = allproducts;
            ViewBag.productall = product;
            return View();
        }
        
       
      
    }
}
