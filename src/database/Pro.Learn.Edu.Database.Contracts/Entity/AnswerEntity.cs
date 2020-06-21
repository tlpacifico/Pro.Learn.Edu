using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Learn.Edu.Database.Entity
{
    public class AnswerEntity: IHaveId, IHaveExternalId
    {
        public long Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<QuestionAnwserEntity> Questions { get; set; }

    }
}
