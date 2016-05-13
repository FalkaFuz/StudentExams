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
    public class QuestionTypeFacade
    {
        public void CreateQuestionType(QuestionTypeDTO questionType)
        {
            QuestionType newQuestionType = Mapping.Mapper.Map<QuestionType>(questionType);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.QuestionTypes.Add(newQuestionType);
                context.SaveChanges();
            }
        }

        public QuestionTypeDTO GetQuestionTypeById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var questionType = context.QuestionTypes.Find(id);
                return Mapping.Mapper.Map<QuestionTypeDTO>(questionType);
            }
        }



        public void UpdateQuestionType(QuestionTypeDTO questionType)
        {
            var newQuestionType = Mapping.Mapper.Map<QuestionType>(questionType);

            using (var context = new AppDbContext())
            {
                context.Entry(newQuestionType).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteQuestionType(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var questionType = context.QuestionTypes.Find(id);
                context.QuestionTypes.Remove(questionType);
                context.SaveChanges();
            };
        }



        public void DeleteQuestionType(QuestionTypeDTO questionType)
        {
            var newQuestionType = Mapping.Mapper.Map<QuestionType>(questionType);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(newQuestionType).State = EntityState.Deleted;
                context.SaveChanges();
            };
        }



        public List<QuestionTypeDTO> GetAllQuestionTypes()
        {
            using (var context = new AppDbContext())
            {
                var questionTypes = context.QuestionTypes.ToList();
                return questionTypes
                    .Select(e => Mapping.Mapper.Map<QuestionTypeDTO>(e))
                    .ToList();
            }
        }
    }
}
