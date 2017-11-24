using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;
using DvdShop.Models.Services;
using DvdShop.Models.ViewModel;

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
            var studioViewModel = AutoMapper.Mapper.Map<List<NewStudioViewModel>> (result);
            return View(studioViewModel);
        }

        // GET: Studios/Details/5
        public ActionResult Details(int id)
        {
            var studio = _studioService.GetStudioById(id);
            var studioViewModel = AutoMapper.Mapper.Map<NewStudioViewModel>(studio);
            if (studio == null)
            {
                return HttpNotFound();
            }
            ViewBag.studio = studioViewModel;
            return View();
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
        public ActionResult Create(NewStudioViewModel studio,HttpPostedFileBase file)
        {
            if (!ModelState.IsValid) return View(studio);
            if (file != null || file.ContentLength == 0)
            {
                var pathsCombine = Path.Combine(Server.MapPath("~/Content/Images"), file.FileName);
                file.SaveAs(pathsCombine);
            }
            var studioViewModel = AutoMapper.Mapper.Map<Studio>(studio);
            studioViewModel.Image = file.FileName;
            studioViewModel.CreatedDate = DateTime.Now;
            studioViewModel.CreatedBy = Session["user"].ToString();
            _studioService.Add(studioViewModel);
            return RedirectToAction("Index");
        }

        // GET: Studios/Edit/5
        public ActionResult Edit(int id)
        {
           
            var studio = _studioService.GetStudioById(id);
            var studioViewModel = AutoMapper.Mapper.Map<NewStudioViewModel>(studio);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studioViewModel);
        }

        // POST: Studios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudioCode,Name,SkypeName,PhoneNumber,MobiNumber,Email,Zalo,Address,Price,Comment,Image,Owner,Amount,CreatedDate,CreatedBy,Status")] NewStudioViewModel studio, HttpPostedFileBase file)
        {
            
            if (!ModelState.IsValid) return View(studio);
            if (file != null)
            {
                var pathsCombine = Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(file.FileName));
                file.SaveAs(pathsCombine);
                studio.Image = file.FileName;
            }
            
            studio.UpdatedBy = Session["user"].ToString();
            studio.UpdatedDate = DateTime.Now;
            var studioViewModel = AutoMapper.Mapper.Map<Studio>(studio);
            _studioService.Update(studioViewModel);
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
