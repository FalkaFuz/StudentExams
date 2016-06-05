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
    public class StudentGroupController : Controller
    {
        private StudentGroupFacade facade = new StudentGroupFacade();

        // GET: StudentGroup
        public ActionResult Index()
        {
            return View(facade.GetAllStudentGroups());
        }
        
        // GET: StudentGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationCode,Name")] StudentGroupDTO studentGroupDTO)
        {
            if (ModelState.IsValid)
            {
                facade.CreateStudentGroup(studentGroupDTO);
                return RedirectToAction("Index");
            }

            return View(studentGroupDTO);
        }

        // GET: StudentGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroupDTO studentGroupDTO = facade.GetStudentGroupById(id.Value);
            if (studentGroupDTO == null)
            {
                return HttpNotFound();
            }
            return View(studentGroupDTO);
        }

        // POST: StudentGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationCode,Name")] StudentGroupDTO studentGroupDTO)
        {
            if (ModelState.IsValid)
            {
                facade.UpdateStudentGroup(studentGroupDTO);
                return RedirectToAction("Index");
            }
            return View(studentGroupDTO);
        }

        // GET: StudentGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroupDTO studentGroupDTO = facade.GetStudentGroupById(id.Value);
            if (studentGroupDTO == null)
            {
                return HttpNotFound();
            }
            return View(studentGroupDTO);
        }

        // POST: StudentGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            facade.DeleteStudentGroup(id);
            return RedirectToAction("Index");
        }
        
    }
}
