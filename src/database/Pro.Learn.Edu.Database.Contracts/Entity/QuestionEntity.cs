using System;
using System.Collections.Generic;

namespace Pro.Learn.Edu.Database.Entity
{
    public class QuestionEntity : IHaveId<long>, IHaveExternalId
    {
        public long Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }      
        public long CorrectAnswerId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<QuestionAnwserEntity> Answers { get; set; }

        public virtual AnswerEntity CorrectAnsweer { get; set; }
    }

}
