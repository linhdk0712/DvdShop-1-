using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DvdShop.Models.Repositories;

namespace DvdShop.Controllers
{
    public class BaseController : Controller
    {
        private IUnitOfWork _unitOfWork;
        // GET: Base
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}