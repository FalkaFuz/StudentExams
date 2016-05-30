using BL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class AnswerFacade
    {
        public void CreateAnswer(AnswerDTO answer)
        {
            Answer newAnswer = Mapping.Mapper.Map<Answer>(answer);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Answers.Add(newAnswer);
                context.SaveChanges();
            }
        }

        public AnswerDTO GetAnswerById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var answer = context.Answers.Find(id);
                return Mapping.Mapper.Map<AnswerDTO>(answer);
            }
        }



        public void UpdateAnswer(AnswerDTO answer)
        {
            var newAnswer = Mapping.Mapper.Map<Answer>(answer);

            using (var context = new AppDbContext())
            {
                context.Entry(newAnswer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteAnswer(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var answer = context.Answers.Find(id);
                context.Answers.Remove(answer);
                context.SaveChanges();
            };
        }



        public void DeleteAnswer(AnswerDTO answer)
        {
            var newAnswer = Mapping.Mapper.Map<Answer>(answer);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(newAnswer).State = EntityState.Deleted;
                context.SaveChanges();
            };
        }



        public List<AnswerDTO> GetAllAnswers()
        {
            using (var context = new AppDbContext())
            {
                var answers = context.Answers.ToList();
                return answers
                    .Select(e => Mapping.Mapper.Map<AnswerDTO>(e))
                    .ToList();
            }
        }
    }
}
