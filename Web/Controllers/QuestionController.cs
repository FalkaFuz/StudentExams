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
    public class QuestionController : Controller
    {

        private QuestionFacade facade = new QuestionFacade();
        private ThematicAreaFacade areaFacade = new ThematicAreaFacade();

        
        // GET: Question/Create
        public ActionResult Create(int id)
        {
            QuestionDTO model = new QuestionDTO { ThematicArea = areaFacade.GetThematicAreaById(id) };
            return View(model);
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Points,Explanation,ThematicArea")] QuestionDTO questionDTO)
        {
            if (ModelState.IsValid)
            {
                facade.CreateQuestion(questionDTO);
                return RedirectToAction("ListByArea", "Question", new { id = questionDTO.ThematicArea.Id });
            }

            return View(questionDTO);
        }

       

        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionDTO questionDTO = facade.GetQuestionById(id.Value);
            if (questionDTO == null)
            {
                return HttpNotFound();
            }
            return View(questionDTO);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Points,Explanation,ThematicArea")] QuestionDTO questionDTO)
        {
            if (ModelState.IsValid)
            {
                facade.UpdateQuestion(questionDTO);
                return RedirectToAction("ListByArea", "Question", new { id = questionDTO.ThematicArea.Id });
            }
            return View(questionDTO);
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionDTO questionDTO = facade.GetQuestionById(id.Value);
            if (questionDTO == null)
            {
                return HttpNotFound();
            }
            return View(questionDTO);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionDTO questionDTO = facade.GetQuestionById(id);
            facade.DeleteQuestion(id);
            return RedirectToAction("ListByArea", "Question", new { id = questionDTO.ThematicArea.Id});
        }

        public ActionResult ListByArea(int id) {

            var area = areaFacade.GetThematicAreaById(id);
            var models = area.Questions;
            if (models == null) {
                models = new List<QuestionDTO>();
            }
            return View("Index", new Tuple<int, IEnumerable<QuestionDTO>>(id, models));
        }

        public ActionResult Answers(int id)
        {
            return RedirectToAction("ListByQuestion", "Answer", new { id = id });
        }

        public ActionResult BackToThematicArea()
        {
            //ThematicAreaDTO ta = areaFacade.GetThematicAreaById(id);
            return RedirectToAction("Index", "ThematicArea");
        }
    }
}
