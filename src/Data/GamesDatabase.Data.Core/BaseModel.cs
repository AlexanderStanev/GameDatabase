using System;
using System.Collections.Generic;
using System.Text;

namespace GamesDatabase.Data.Core
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
    }
}
