using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ShopQuanAo.Models;

namespace ShopQuanAo.Areas.admin.Controllers
{

    public class productsController : Controller
    {
        private SHOPAOQUANEntities1 db = new SHOPAOQUANEntities1();

        // GET: products
        public ActionResult Index()
        {
            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;

            var product = db.product.Include(p => p.Brand).Include(p => p.subCategory);
            return View(product.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(string id)
        {
            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            ViewBag.id_brand = new SelectList(db.Brand, "id_brand", "brand_name");
            ViewBag.id_subcate = new SelectList(db.subCategory, "id_subcate", "name_subcate");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stt,id_product,name_product,price_new,price_old,describe,quantity,id_subcate,id_brand")] product product, HttpPostedFileBase imageInput)
        {
            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            if (ModelState.IsValid)
            {
                // Xử lý file ảnh
                if (imageInput != null && imageInput.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(imageInput.FileName);
                    string path = Path.Combine(Server.MapPath("~/assets/images/products/"), fileName);
                    imageInput.SaveAs(path);

                    // Lưu tên file vào thuộc tính 'images' của sản phẩm
                    product.images = fileName;
                }

                // Lưu sản phẩm vào cơ sở dữ liệu
                db.product.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.id_brand = new SelectList(db.Brand, "id_brand", "brand_name", product.id_brand);
            ViewBag.id_subcate = new SelectList(db.subCategory, "id_subcate", "name_subcate", product.id_subcate);
            return View(product);
        }


        // GET: products/Edit/5
        public ActionResult Edit(string id)
        {
            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_brand = new SelectList(db.Brand, "id_brand", "brand_name", product.id_brand);
            ViewBag.id_subcate = new SelectList(db.subCategory, "id_subcate", "name_subcate", product.id_subcate);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stt,id_product,name_product,images,price_new,price_old,describe,quantity,id_subcate,id_brand")] product product)
        {
            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_brand = new SelectList(db.Brand, "id_brand", "brand_name", product.id_brand);
            ViewBag.id_subcate = new SelectList(db.subCategory, "id_subcate", "name_subcate", product.id_subcate);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(string id)
        {
            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<sale> sale = db.sale.ToList();
            List<Brand> brand = db.Brand.ToList();

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.sales = sale;
            ViewBag.brands = brand;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            product product = db.product.Find(id);
            db.product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
