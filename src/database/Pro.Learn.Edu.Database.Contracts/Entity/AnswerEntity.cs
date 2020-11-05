using System;

namespace Pro.Learn.Edu.Database.Entity
{
    public class AnswerEntity: IHaveId<long>, IHaveExternalId
    {
        public long Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }

    }
}
