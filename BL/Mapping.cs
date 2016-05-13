using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTO;
using StudentExams.Entities;

namespace BL
{
    public static class Mapping
    {
        public static IMapper Mapper { get; }
        static Mapping()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<StudentDTO, Student>().ReverseMap();
                c.CreateMap<StudentGroupDTO, StudentGroup>().ReverseMap();
                c.CreateMap<TeacherDTO, Teacher>().ReverseMap();
                c.CreateMap<TestDTO, Test>().ReverseMap();
                c.CreateMap<TestAccessDTO, TestAccess>().ReverseMap();
                c.CreateMap<QuestionDTO, Question>().ReverseMap();

            });
            Mapper = config.CreateMapper();
        }
    }
}
