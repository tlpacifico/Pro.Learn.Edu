using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Learn.Edu.Database.Entity
{
    public class ExamQuestionEntity: IHaveId<long>
    {
        public long Id { get; set; }
        public long ExamId { get; set; }
        public long QuestionId { get; set; }
    }
}
