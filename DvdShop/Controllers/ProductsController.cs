using System;
using System.Linq;
using System.Web.Mvc;
using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;
using DvdShop.Models.Services;
using DvdShop.Models.ViewModel;

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
        public ActionResult Index()
        {
            var products = _productService.GetAllProducts();
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
            var newProduct = new NewProductViewModel
            {
                Studios = studios
            };
            return View(newProduct);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudioId,ReceivedDate,Name,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status")] Product product)
        {
            
            if (!ModelState.IsValid)
            {
                var studios = _studioService.GetAllStudios();
                var newProduct = new NewProductViewModel
                {
                    Product = product,
                    Studios = studios
                };
                return View(newProduct);
            }
            _productService.Add(product);
            return RedirectToAction("Index");
            
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
