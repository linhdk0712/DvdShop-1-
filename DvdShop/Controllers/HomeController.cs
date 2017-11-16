using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DvdShop.Commons;
using DvdShop.Models.Services;
using DvdShop.Models.ViewModel;

namespace DvdShop.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string user,string pass)
        {
            var pas = Md5.Md5Hash(pass);
                var result = _userService.GetInfoUser(user, pas);
                if (result != null)
                {
                    Session["user"] = result.UserName;
                    Session["fullname"] = result.FullName;
                    return View("Index");
                }
                else
                {
                    ViewBag.login = "Đăng nhập không thành công";
                    return View();
                }
           
            
        }
    }
}