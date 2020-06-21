using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Learn.Edu.Database
{
    public interface IHaveExternalId
    {
        Guid ExternalId { get; set; }
    }
}
