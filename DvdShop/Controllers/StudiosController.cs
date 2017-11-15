﻿using System.Collections.Generic;
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
            return View(studioViewModel);
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
        public ActionResult Create([Bind(Include = "Id,StudioCode,SkypeName,PhoneNumber,Address,Price,Amount,Name,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status")] NewStudioViewModel studio)
        {
            if (!ModelState.IsValid) return View(studio);
            var studioViewModel = AutoMapper.Mapper.Map<Studio>(studio);
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
        public ActionResult Edit([Bind(Include = "Id,StudioCode,SkypeName,PhoneNumber,Address,Price,Amount,Name,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status")] NewStudioViewModel studio)
        {
            if (!ModelState.IsValid) return View(studio);
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
