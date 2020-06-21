using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Learn.Edu.Database.Entity
{
    public class QuestionAnwserEntity
    {
        public long QuestionId { get; set; }
        public long AnswerId { get; set; }
        public virtual QuestionEntity Question { get; set; }
        public virtual AnswerEntity Answer { get; set; }

    }
}
