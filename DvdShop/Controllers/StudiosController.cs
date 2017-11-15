using System.Web.Mvc;
using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;
using DvdShop.Models.Services;

namespace DvdShop.Controllers
{
    public class StudiosController : BaseController
    {
        private readonly IStudioService _studioService;
        public StudiosController(IUnitOfWork unitOfWork,IStudioService studioService) : base(unitOfWork)
        {
            _studioService = studioService;
        }

        // GET: Studios
        public ActionResult Index()
        {
            var result = _studioService.GetAllStudios();
            return View(result);
        }

        // GET: Studios/Details/5
        public ActionResult Details(int id)
        {
            var studio = _studioService.GetStudioById(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // GET: Studios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudioCode,SkypeName,PhoneNumber,Address,Price,Amount,Name,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status")] Studio studio)
        {
            if (!ModelState.IsValid) return View(studio);
            _studioService.Add(studio);
            return RedirectToAction("Index");
        }

        // GET: Studios/Edit/5
        public ActionResult Edit(int id)
        {
           
            var studio = _studioService.GetStudioById(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudioCode,SkypeName,PhoneNumber,Address,Price,Amount,Name,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status")] Studio studio)
        {
            if (!ModelState.IsValid) return View(studio);
            _studioService.Update(studio);
            return RedirectToAction("Index");
        }

        // GET: Studios/Delete/5
        public ActionResult Delete(int id)
        {
           
            var studio = _studioService.GetStudioById(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var studio = _studioService.GetStudioById(id);
            _studioService.Delete(studio);
            return RedirectToAction("Index");
        }

        

        
    }
}
