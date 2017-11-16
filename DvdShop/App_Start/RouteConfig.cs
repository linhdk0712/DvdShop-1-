using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DvdShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name:"gioithieu",
                url:"trang-chu/gioi-thieu",
                defaults:new { controller = "Home", action = "About" }
            );
            routes.MapRoute(
               name: "lienhe",
               url: "trang-chu/lien-he",
               defaults: new { controller = "Home", action = "Contact" }
           );
            routes.MapRoute(
              name: "anhvien",
              url: "trang-chu/danh-sach-anh-vien",
              defaults: new { controller = "Studios", action = "Index" }

          );
            routes.MapRoute(
             name: "sanpham",
             url: "trang-chu/danh-sach-san-pham",
             defaults: new { controller = "Products", action = "Index" }

         );
            routes.MapRoute(
             name: "trangchu",
             url: "trang-chu",
             defaults: new { controller = "Home", action = "Index" }

         );
            routes.MapRoute(
             name: "dangnhap",
             url: "trang-chu/dang-nhap",
             defaults: new { controller = "Home", action = "Login" }

         );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
