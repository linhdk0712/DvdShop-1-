using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return HttpNotFound();
        }

        public ActionResult Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.GetInfoUser(model.UserName, model.Password);
                if (result != null)
                {
                    return View();
                }
                else
                {
                    RedirectToAction("Error");
                }
            }
            ModelState.AddModelError("",@"Sai thông tin đăng nhập");
            return View("Error");
        }
    }
}