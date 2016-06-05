﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class AnswerDTO
    {
        public int Id { set; get; }
        public string Text { set; get; }
        public Boolean IsCorrect { set; get; }
        public QuestionDTO Question { set; get; }
    }
}
