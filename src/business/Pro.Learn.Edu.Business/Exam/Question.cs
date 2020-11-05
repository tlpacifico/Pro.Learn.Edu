using System;
using System.Collections.Generic;

namespace Pro.Learn.Edu.Business.Exam
{
    public class Question
    {
        public Question(string description, long correctAnswerId, DateTimeOffset createdOn,
            string createdBy, IReadOnlyCollection<KeyValuePair<Guid, string>> answers,
            Answer correctAnsweerId)
        {
            Description = description;
            CorrectAnswerId = correctAnswerId;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            Answers = answers;
            CorrectAnsweerId = correctAnsweerId;
        }

        public string Description { get; }
        public long CorrectAnswerId { get; }
        public DateTimeOffset CreatedOn { get; }
        public string CreatedBy { get;  }
        public IReadOnlyCollection<KeyValuePair<Guid, string>> Answers { get; set; }
        public Answer CorrectAnsweerId { get; set; }
    }
}