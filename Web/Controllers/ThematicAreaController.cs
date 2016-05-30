using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL.DTO;
using Web.Models;
using BL.Facades;

namespace Web.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class ThematicAreaController : Controller
    {
        private ThematicAreaFacade facade = new ThematicAreaFacade();

        // GET: ThematicAreaDTOes
        public ActionResult Index()
        {
            return View(facade.GetAllThematicAreas());
        }

        // GET: ThematicAreaDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicAreaDTO thematicAreaDTO = facade.GetThematicAreaById(id.Value);
            if (thematicAreaDTO == null)
            {
                return HttpNotFound();
            }
            return View(thematicAreaDTO);
        }

        // GET: ThematicAreaDTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThematicAreaDTOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ThematicAreaDTO thematicAreaDTO)
        {
            if (ModelState.IsValid)
            {
                facade.CreateThematicArea(thematicAreaDTO);
                return RedirectToAction("Index");
            }

            return View(thematicAreaDTO);
        }

        // GET: ThematicAreaDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicAreaDTO thematicAreaDTO = facade.GetThematicAreaById(id.Value);
            if (thematicAreaDTO == null)
            {
                return HttpNotFound();
            }
            return View(thematicAreaDTO);
        }

        // POST: ThematicAreaDTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ThematicAreaDTO thematicAreaDTO)
        {
            if (ModelState.IsValid)
            {
                facade.UpdateThematicArea(thematicAreaDTO);
                return RedirectToAction("Index");
            }
            return View(thematicAreaDTO);
        }

        // GET: ThematicAreaDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicAreaDTO thematicAreaDTO = facade.GetThematicAreaById(id.Value);
            if (thematicAreaDTO == null)
            {
                return HttpNotFound();
            }
            return View(thematicAreaDTO);
        }

        // POST: ThematicAreaDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            facade.DeleteThematicArea(id);
            return RedirectToAction("Index");
        }

        public ActionResult Questions(int id)
        {
            return RedirectToAction("ListByArea", "Question", new { id = id });
        }
    }
}
