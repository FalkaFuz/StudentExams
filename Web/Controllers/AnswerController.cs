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
    public class AnswerController : Controller
    {
        private AnswerFacade facade = new AnswerFacade();
        private QuestionFacade qFacade = new QuestionFacade();

        

        // GET: Answer/Create
        public ActionResult Create(int id)
        {
            AnswerDTO model = new AnswerDTO { Question = qFacade.GetQuestionById(id) };
            return View(model);
        }

        // POST: Answer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,IsRight,Question")] AnswerDTO answerDTO)
        {
            if (ModelState.IsValid)
            {
                facade.CreateAnswer(answerDTO);
                return RedirectToAction("ListByQuestion", "Answer", new { id = answerDTO.Question.Id });
            }

            return View(answerDTO);
        }

        // GET: Answer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerDTO answerDTO = facade.GetAnswerById(id.Value);
            if (answerDTO == null)
            {
                return HttpNotFound();
            }
            return View(answerDTO);
        }

        // POST: Answer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,IsRight,Question")] AnswerDTO answerDTO)
        {
            if (ModelState.IsValid)
            {
                facade.UpdateAnswer(answerDTO);
                return RedirectToAction("ListByQuestion", "Answer", new { id = answerDTO.Question.Id });
            }
            return View(answerDTO);
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerDTO answerDTO = facade.GetAnswerById(id.Value);
            if (answerDTO == null)
            {
                return HttpNotFound();
            }
            return View(answerDTO);
        }

        // POST: Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnswerDTO answerDTO = facade.GetAnswerById(id);
            facade.DeleteAnswer(id);
            return RedirectToAction("ListByQuestion", "Answer", new { id = answerDTO.Question.Id });
        }


        public ActionResult ListByQuestion(int id)
        {

            var question = qFacade.GetQuestionById(id);
            var models = question.Answers;
            if (models == null)
            {
                models = new List<AnswerDTO>();
            }
            return View("Index", new Tuple<int, IEnumerable<AnswerDTO>>(id,models));
        }

        public ActionResult BackToQuestion(int id)
        {
            QuestionDTO ques = qFacade.GetQuestionById(id);
            return RedirectToAction("ListByArea", "Question", new { id = ques.ThematicArea.Id});
        }

    }
}
