using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Canifa_Clone.Models;

namespace Canifa_Clone.Controllers
{
    public class AccountController : Controller
    {
        private Canifa_Entities db = new Canifa_Entities();

        // GET: Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.KhachHang.FirstOrDefault(u => u.Email == model.Email && u.MatKhau == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, model.RememberMe);
                    
                    // Lưu thông tin vào Session
                    Session["UserId"] = user.MaKH;
                    Session["UserName"] = user.HoTen;
                    Session["UserEmail"] = user.Email;
                    Session["UserRole"] = (user.IsAdmin == true) ? "Admin" : "User";

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    // Chuyển hướng theo quyền
                    if (user.IsAdmin == true)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác.");
            }
            return View(model);
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                if (db.KhachHang.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email này đã được sử dụng.");
                    return View(model);
                }

                var newUser = new KhachHang
                {
                    HoTen = model.FullName,
                    Email = model.Email,
                    MatKhau = model.Password,
                    SoDienThoai = model.Phone,
                    DiaChi = model.Address,
                    IsAdmin = false
                };

                db.KhachHang.Add(newUser);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
