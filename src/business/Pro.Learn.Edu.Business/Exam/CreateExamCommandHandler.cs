using MediatR;
using Microsoft.Extensions.Logging;
using Pro.Learn.Edu.Database;
using Pro.Learn.Edu.Database.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pro.Learn.Edu.Business.Exam
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, CreateExamCommandResult>
    {
        private readonly ILogger<CreateExamCommandHandler> _logger;
        private readonly IRepository<ExamEntity> _exam;
        private readonly IRepository<QuestionEntity> _question;
        private readonly IRepository<AnswerEntity> _answer;
        private readonly IRepository<QuestionAnwserEntity> questionAnwser;

        public CreateExamCommandHandler(
            ILogger<CreateExamCommandHandler> logger,
            IRepository<ExamEntity> exam,
            IRepository<QuestionEntity> question,
            IRepository<AnswerEntity> answer,
            IRepository<QuestionAnwserEntity> questionAnwser)
        {
            _logger = logger;
            _exam = exam;
            _question = question;
            _answer = answer;
            this.questionAnwser = questionAnwser;
        }

        public async Task<CreateExamCommandResult> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
           var exam = await _exam.AddAsync(new ExamEntity()
            {
                Name = request.Name,
                ExternalId = Guid.NewGuid(),
                Quantity = request.Quantity,
                ExamOccurredOn = request.ExamOccurredOn,
                CreatedOn = DateTimeOffset.Now,
                CreatedBy = "sdfsdf"
           }, cancellationToken);

            return new CreateExamCommandResult(exam.Id);
        }
    }
}
