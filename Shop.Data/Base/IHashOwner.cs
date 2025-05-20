using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Base
{
    public interface IHashOwner <T>
    {
        T OwnerId { get; set; }
    }
}
