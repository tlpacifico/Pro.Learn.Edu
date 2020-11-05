using Pro.Learn.Edu.Business.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pro.Learn.Edu.Api.Controllers.Exam
{
    public static class ExamMappings
    {
        public static CreateExamCommand ToCommand(this CreateExamModel m) => m == null
        ? null
        : new CreateExamCommand(m.Name, m.ExamOccurredOn, m.Quantity, m.Answers, m.CorrectAnswerId);
    }
}
