using BL.DTO;
using DAL;
using DAL.Entities;
using StudentExams.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class QuestionFacade
    {
        public void CreateQuestion(QuestionDTO question)
        {
            //System.Diagnostics.Debug.WriteLine(question.ThematicArea.Id);
            Question newQuestion = Mapping.Mapper.Map<Question>(question);
            //System.Diagnostics.Debug.WriteLine(newQuestion.ThematicArea.Id);
            using (var context = new AppDbContext())
            {
                ThematicArea newThematicArea = context.ThematicAreas.Find(question.ThematicArea.Id);
                newQuestion.ThematicArea = newThematicArea;
                context.Database.Log = Console.WriteLine;
                context.Questions.Add(newQuestion);
                context.SaveChanges();
            }
        }

        public QuestionDTO GetQuestionById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var question = context.Questions.Include(a => a.Answers).First(a => a.Id == id);
                return Mapping.Mapper.Map<QuestionDTO>(question);
            }
        }



        public void UpdateQuestion(QuestionDTO question)
        {
            var newQuestion = Mapping.Mapper.Map<Question>(question);

            using (var context = new AppDbContext())
            {
                context.Entry(newQuestion).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteQuestion(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var question = context.Questions.Find(id);
                context.Questions.Remove(question);
                context.SaveChanges();
            };
            
        }



        public void DeleteQuestion(QuestionDTO question)
        {
            var newQuestion = Mapping.Mapper.Map<Question>(question);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(newQuestion).State = EntityState.Deleted;
                context.SaveChanges();
            };
        }



        public List<QuestionDTO> GetAllQuestions()
        {
            using (var context = new AppDbContext())
            {
                var questions = context.Questions.ToList();
                return questions
                    .Select(e => Mapping.Mapper.Map<QuestionDTO>(e))
                    .ToList();
            }
        }

        

        public int GetThematicAreaId(QuestionDTO question)
        {
            var newQuestion = Mapping.Mapper.Map<Question>(question);

            using (var context = new AppDbContext())
            {
                context.Entry(newQuestion).Reference(x => x.ThematicArea).Load();
                var ta = newQuestion.ThematicArea;
                return ta.Id;
            }
        }
    }
}
