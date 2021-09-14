using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using forumAspMVC.Dao;
using forumAspMVC.Models;

namespace forumAspMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        UserDao userD = new UserDao();
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            var email = form["email"];
            var password = form["password"];
            var rePassword = form["rePassword"];
            int status = 1;
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(rePassword))
            {
                ViewBag.message = "Cần điền đầy đủ thông tin";
                return View();
            }
            else if (password != rePassword)
            {
                ViewBag.message = "Hai mật khẩu không trùng khớp";
                return View();
            }else
            {
                bool checkEmail = userD.checkEmailExist(email);
                if (checkEmail)
                {
                    ViewBag.message = "Email đã tồn tại";
                    return View();
                }
                else
                {
                    string passwordMd5 = userD.md5(password);
                    User user = new User();
                    user.email = email;
                    user.password = passwordMd5;
                    user.status = status;
                    userD.register(user);
                    return RedirectToAction("Login");
                }
            }
           
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var email = form["email"];
            var password = form["password"];
            string passwordMd5 = userD.md5(password);
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.message = "Cần điền đầy đủ thông tin";
                return View();
            }
            else
            {
                bool checkLogin = userD.checkLogin(email, passwordMd5);
                if (checkLogin)
                {
                    var userInformation = userD.getUserByEmail(email);
                    Session.Add("User", userInformation);
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ViewBag.message = "Tài khoản hoặc mật khẩu không chính xác";
                    return View();
                }
            }
           
        }
        public ActionResult Logout()
        {
            Session.Remove("User");
            return Redirect("/");
        }
    }
}