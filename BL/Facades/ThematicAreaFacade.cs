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
    public class ThematicAreaFacade
    {
        public void CreateThematicArea(ThematicAreaDTO thematicArea)
        {
            ThematicArea newThematicArea = Mapping.Mapper.Map<ThematicArea>(thematicArea);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.ThematicAreas.Add(newThematicArea);
                context.SaveChanges();
            }
        }

        public ThematicAreaDTO GetThematicAreaById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var thematicArea = context.ThematicAreas.Find(id);
                return Mapping.Mapper.Map<ThematicAreaDTO>(thematicArea);
            }
        }



        public void UpdateThematicArea(ThematicAreaDTO thematicArea)
        {
            var newThematicArea = Mapping.Mapper.Map<ThematicArea>(thematicArea);

            using (var context = new AppDbContext())
            {
                context.Entry(newThematicArea).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteThematicArea(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var thematicArea = context.ThematicAreas.Find(id);
                context.ThematicAreas.Remove(thematicArea);
                context.SaveChanges();
            };
        }



        public void DeleteThematicArea(ThematicAreaDTO thematicArea)
        {
            var newThematicArea = Mapping.Mapper.Map<ThematicArea>(thematicArea);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(newThematicArea).State = EntityState.Deleted;
                context.SaveChanges();
            };
        }



        public List<ThematicAreaDTO> GetAllThematicAreas()
        {
            using (var context = new AppDbContext())
            {
                var thematicAreas = context.ThematicAreas.ToList();
                return thematicAreas
                    .Select(e => Mapping.Mapper.Map<ThematicAreaDTO>(e))
                    .ToList();
            }
        }

        public List<QuestionDTO> GetAllQuestions(ThematicAreaDTO area)
        {
            using (var context = new AppDbContext())
            {

                var questions = area.Questions;
                return questions
                    .Select(e => Mapping.Mapper.Map<QuestionDTO>(e))
                    .ToList();
            }
        }
    }
}
