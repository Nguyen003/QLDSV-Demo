using QLDSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDSV.Controllers
{
    public class AccountController : Controller
    {
        private DbSinhVienContext db = new DbSinhVienContext();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var email = collection["email"];
            var password = collection["password"];
            if(String.IsNullOrEmpty(email))
            {
                ViewData["Loi1"] = "Nhập email";
            }
            if(String.IsNullOrEmpty(password))
            {
                ViewData["Loi2"] = "Nhập password";
            } else
            {
                User user = db.Users.SingleOrDefault(n => n.Email == email && n.Password == password);
                if(user != null)
                {
                    Session["userLogin"] = user;
                    return RedirectToAction("Index", "SinhVien");
                } else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng.";
                }
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection, User user, SinhVien sinhVien)
        {
            if(ModelState.IsValid)
            {
                var sv = db.SinhViens.FirstOrDefault(s => s.MaSinhVien == user.MaSV);
                var masv = db.Users.FirstOrDefault(s => s.MaSV == user.MaSV);
                var fullname = db.Users.FirstOrDefault(s => s.Fullname == user.Fullname);
                var email = db.Users.FirstOrDefault(s => s.Email == user.Email);
                if(masv == null && fullname == null && email == null && sv != null && sv.HoTen == user.Fullname)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    if (masv != null) ViewBag.error = "MaSV đã tồn tại";
                    if (sv == null) ViewBag.error = "MaSV không tồn tại";
                    if (sv.HoTen != user.Fullname) ViewBag.error = "MaSV, Tên Sv không khớp hoặc không tồn tại";
                    else if (fullname != null) ViewBag.error = "Tên đã tồn tại";
                    else if (email != null) ViewBag.error = "Email đã tồn tại";
                    return View();
                }
            }
            return View();
        }



        
    }
}