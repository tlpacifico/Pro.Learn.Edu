using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Learn.Edu.Database
{   
    public interface IHaveId<T>
    {
        T Id { get; set; }
    }
}
