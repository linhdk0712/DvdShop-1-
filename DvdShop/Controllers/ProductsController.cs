using System;
using System.Linq;
using System.Web.Mvc;
using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;
using DvdShop.Models.Services;
using DvdShop.Models.ViewModel;
using PagedList;

namespace DvdShop.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IStudioService _studioService;
        public ProductsController(IUnitOfWork unitOfWork,IProductService productService,IStudioService studioService ) : base(unitOfWork)
        {
            _productService = productService;
            _studioService = studioService;
        }

        // GET: Products
        public ActionResult Index(int? page)
        {
            var products = _productService.GetAllProducts();
            var studios = _studioService.GetAllStudios();
            var result = (from a in products
                          join b in studios on a.StudioId equals b.Id
                          select new ProductViewModel()
                          {
                              Id = a.Id,
                              Name = a.Name,
                              StudioName = b.Name,
                              Price = a.Price,
                              IsFullBox = a.IsFullBox,
                              DateCreate = a.CreatedDate,
                              ReceivedDate = a.ReceivedDate,
                              Comment = a.Comment
                          }).ToPagedList(page ?? 1,10); 
            if (products == null || studios == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        public ActionResult GetProductByStudio(string studios)
        {
            var products = _productService.GetAllProductsByStudio(studios);
            var studio = _studioService.GetAllStudios();
            var result = (from a in products
                          join b in studio on a.StudioId equals b.Id
                          select new ProductViewModel()
                          {
                              Id = a.Id,
                              Name = a.Name,
                              StudioName = b.Name,
                              DateCreate = a.CreatedDate,
                              ReceivedDate = a.ReceivedDate
                          });
            if (products == null || studio == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index",result);
        }
        public ActionResult GetProductByDateTime(DateTime date)
        {
            var products = _productService.GetAllProductsByDate(date);
            var studio = _studioService.GetAllStudios();
            var result = (from a in products
                          join b in studio on a.StudioId equals b.Id
                          select new ProductViewModel()
                          {
                              Id = a.Id,
                              Name = a.Name,
                              StudioName = b.Name,
                              DateCreate = a.CreatedDate,
                              ReceivedDate = a.ReceivedDate
                          });
            if (products == null || studio == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", result);
        }
        public ActionResult GetProductByManyCondition(DateTime date,int studioId)
        {
            var products = _productService.GetAllProductsWithCondition(date,studioId);
            var studio = _studioService.GetAllStudios();
            var result = (from a in products
                          join b in studio on a.StudioId equals b.Id
                          select new ProductViewModel()
                          {
                              Id = a.Id,
                              Name = a.Name,
                              StudioName = b.Name,
                              DateCreate = a.CreatedDate,
                              ReceivedDate = a.ReceivedDate
                          });
            if (products == null || studio == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", result);
        }


        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
           
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var studios = _studioService.GetAllStudios();
            ViewBag.studio = studios;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewProductViewModel product)
        {
            var studios = _studioService.GetAllStudios();
            ViewBag.studio = studios;
            ViewBag.success = null;
            if (!ModelState.IsValid)
            {
                return View();
            }
            var p = new Product()
            {
                ReceivedDate = product.ReceivedDate,
                Name = product.Name,
                CreatedDate = DateTime.Now,
                //CreatedBy = Session["user"].ToString(),
                Status = product.Status,
                StudioId = product.StudioId,
                IsFullBox = product.IsFullBox,
                Price = product.Price,
                Comment = product.Comment
            };
            if (product.Price == 0)
            {
                p.Price = studios.Where(x => x.Id == p.StudioId).Select(x => x.Price).FirstOrDefault();
            }
            if (!product.IsFullBox)
            {
                p.IsFullBox = studios.Where(x => x.Id == p.StudioId).Select(x => x.IsFullBox).FirstOrDefault();
            }
            _productService.Add(p);
            var statusId = p.Id ;
            if (statusId > 0)
            {
                ViewBag.success = "Created Successfully";
                //return RedirectToAction("Index");
                return View();
            }
            else
            {
                ViewBag.success = "Created Unsuccessfully";
                return View();

            }

        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
           
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReceivedDate,Name,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status")] Product product)
        {
            if (!ModelState.IsValid)
                return View(product);
            _productService.Update(product);
            return RedirectToAction("Index");
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
           
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productService.GetProductById(id);
           _productService.Delete(product);
            return RedirectToAction("Index");
        }

        

        
    }
}
