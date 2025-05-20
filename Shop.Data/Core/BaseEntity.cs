using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Core
{
    public abstract class BaseEntity <T>
    {
        public T Id { get; set; }

        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}
