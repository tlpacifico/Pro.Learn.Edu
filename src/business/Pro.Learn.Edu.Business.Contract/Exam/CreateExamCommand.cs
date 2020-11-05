using System;

namespace Pro.Learn.Edu.Business.Exam
{
    public class CreateExamCommand : IRequest
    {
        public CreateExamCommand(string name, DateTimeOffset examOccurredOn, int quantity)
        {
            Name = name;
            ExamOccurredOn = examOccurredOn;
            Quantity = quantity;
        }

        public string Name { get; }
        public DateTimeOffset ExamOccurredOn { get; }
        public int Quantity { get; }
    }
}
