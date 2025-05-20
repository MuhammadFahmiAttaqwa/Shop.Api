using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Base
{
    public interface ICreateData
    {
        string CreateBy {  get; set; }

        string? UpadatedBy { get; set; }
    }
}
