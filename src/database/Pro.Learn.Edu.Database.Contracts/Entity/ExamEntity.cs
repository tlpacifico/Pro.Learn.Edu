using System;
using System.Collections.Generic;

namespace Pro.Learn.Edu.Database.Entity
{
    public class ExamEntity : IHaveId<long>, IHaveExternalId
    {
        public long Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset ExamOccurredOn { get; set; }
        public int Quantity { get; set; }     
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }

    }
}
