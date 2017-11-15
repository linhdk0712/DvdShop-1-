using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using DvdShop.Models.Repositories;
using DvdShop.Models.Services;
using Microsoft.Owin;
using Owin;
using Unity;
using Unity.AspNet.Mvc;

[assembly: OwinStartup(typeof(DvdShop.App_Start.Startup))]

namespace DvdShop.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            
        }

        
    }
}
