using BL.DTO;
using DAL;
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
            Question newQuestion = Mapping.Mapper.Map<Question>(question);

            using (var context = new AppDbContext())
            {
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
                var question = context.Questions.Find(id);
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

        public List<AnswerDTO> GetAllAnswers(QuestionDTO question)
        {
            using (var context = new AppDbContext())
            {
                
                var answers = question.Answers;
                return answers
                    .Select(e => Mapping.Mapper.Map<AnswerDTO>(e))
                    .ToList();
            }
        }
    }
}
