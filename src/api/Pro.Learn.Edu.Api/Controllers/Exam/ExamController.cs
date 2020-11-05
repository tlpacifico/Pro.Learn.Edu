using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pro.Learn.Edu.Api.Controllers.Exam;
using Pro.Learn.Edu.Business.Exam;

namespace Pro.Learn.Edu.Api.Exam.Controllers
{
    [ApiController]
    [Route("api/exam")]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<long> CreateExamAsync(CreateExamModel model, CancellationToken ct)
        {
            var result = await _mediator.Send(model.ToCommand());
            return result.Id;
        }
    }
}
