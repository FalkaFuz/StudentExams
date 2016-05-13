using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.DTO;
using BL.Facades;
using Web.Models;

namespace Web.Controllers
{
    public class InformationController : Controller
    {
      StudentFacade studentFacade = new StudentFacade();

       
        public ActionResult Redirect()
        {
            return Redirect("http://google.sk");
        }

       public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            
            return View();
        }

        public ActionResult Students()
        {
            var model = studentFacade.GetAllStudents();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentDTO student)
        {
            studentFacade.CreateStudent(student);
            return RedirectToAction("Students");
        }

        public ActionResult Delete(int id)
        {
            studentFacade.DeleteStudent(id);
            return RedirectToAction("Students");
        }

        public ActionResult Edit(int id)
        {
            var student = studentFacade.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(int id, StudentDTO student)
        {
            var originalStudent = studentFacade.GetStudentById(id);
            originalStudent.FirstName = student.FirstName;
            originalStudent.Surname = student.Surname;
            originalStudent.Email = student.Email;

            studentFacade.UpdateStudent(originalStudent);

            return RedirectToAction("Students");
        }
    }
}