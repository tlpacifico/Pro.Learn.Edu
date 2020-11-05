using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Learn.Edu.Database.Entity
{
    public class QuestionAnwserEntity : IHaveId<long>
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public long AnswerId { get; set; }
    }
}
