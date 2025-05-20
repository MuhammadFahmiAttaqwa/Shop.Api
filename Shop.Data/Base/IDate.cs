using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Base
{
    public interface IDate
    {
        DateTime DateCreated { get; set; }

        DateTime? DateUpdated { get; set; }
    }
}
