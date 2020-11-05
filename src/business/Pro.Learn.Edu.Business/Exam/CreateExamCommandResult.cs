using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Learn.Edu.Business.Exam
{
    public class CreateExamCommandResult
    {
        public CreateExamCommandResult(long id)
        {
            Id = id;
        }

        public long Id { get; }     
    }
}
