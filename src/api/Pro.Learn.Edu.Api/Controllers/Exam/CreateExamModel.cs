using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pro.Learn.Edu.Api.Controllers.Exam
{
    public class CreateExamModel
    {
        public CreateExamModel(string name, DateTimeOffset examOccurredOn, int quantity,
            IReadOnlyCollection<KeyValuePair<Guid, string>> answers, Guid correctAnswerId)
        {
            Name = name;
            ExamOccurredOn = examOccurredOn;
            Quantity = quantity;
            Answers = answers;
            CorrectAnswerId = correctAnswerId;
        }

        public string Name { get; }
        public DateTimeOffset ExamOccurredOn { get; }
        public int Quantity { get; }       
        public IReadOnlyCollection<KeyValuePair<Guid, string>> Answers { get; }
        public Guid CorrectAnswerId { get; }
    }
}
