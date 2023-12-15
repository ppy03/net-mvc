using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShopQuanAo.Models;
namespace ShopQuanAo.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            SHOPAOQUANEntities1 db = new SHOPAOQUANEntities1();

            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<User> users = db.User.ToList();

            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.Users = users;

            return View();
        }
        public ActionResult Login()
        {
            SHOPAOQUANEntities1 db = new SHOPAOQUANEntities1();

            List<Category> danhmuccha = db.Category.ToList();
            List<subCategory> danhmuccon = db.subCategory.ToList();
            List<User> users = db.User.ToList();
            ViewBag.Categories = danhmuccha;
            ViewBag.subCategories = danhmuccon;
            ViewBag.Users = users;

            return View();
        }
        //đăng ký
        private ApplicationDbContext db = new ApplicationDbContext(); // Khởi tạo Database Context

        // GET: Hiển thị form đăng ký
        public ActionResult DangKy()
        {
            return View();
        }

        // POST: Xử lý dữ liệu từ form đăng ký
        [HttpPost]
        public ActionResult DangKy(User user)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem email đã được sử dụng chưa
                var existingUser = db.Users.FirstOrDefault(u => u.email == user.email);
                if (existingUser != null)
                {
                    TempData["errorr"] = "Email đã tồn tại!";
                    return RedirectToAction("Login", "Login");
                }

                // Lưu thông tin người dùng vào cơ sở dữ liệu
                db.Users.Add(user);
                db.SaveChanges();                
                // Chuyển hướng đến trang thành công sau khi đăng ký
                return RedirectToAction("Index", "Login");
                
            }
            return View(user);
            // Nếu dữ liệu không hợp lệ, hiển thị lại form với thông báo lỗi
           
        }

        // GET: Thông báo đăng ký thành công

        //Đăng nhập



        [HttpPost]
        public ActionResult Login(string email, string PassWord)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.email == email && u.pass == PassWord);

                if (user != null && user.roles != "2")
                {

                    // Người dùng hợp lệ, thực hiện các thao tác cần thiết
                    // Ví dụ: lưu thông tin người dùng vào Session và chuyển hướng
                    Session["LoggedInUser"] = user.name_user;
                    return RedirectToAction("Home", "Home");
                }  
                    
                if(user != null && user.roles == "2")
                {
                    // Người dùng hợp lệ, thực hiện các thao tác cần thiết
                    // Ví dụ: lưu thông tin người dùng vào Session và chuyển hướng
                    Session["LoggedInUser"] = user.name_user;
                    return RedirectToAction("Index", "products", new { Area = "admin" });
                }               
                else
                {
                    // Người dùng không hợp lệ, hiển thị thông báo lỗi
                    ViewBag.ErrorMessage = "Invalid email or password";
                    TempData["error"] = "Tài khoản đăng nhập không đúng";
                    return RedirectToAction("Index", "Login");
                }
                
            }

        }
        public ActionResult LogOut()
        {
            Session.Remove("user");
            Session["LoggedInUser"] = null;
            //xoa session trong au
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Home");  
        }

    }
}