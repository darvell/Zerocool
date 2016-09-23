using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zerocool.API.Entities
{
    public interface IStandardRequest
    {
        Exception Error { get; set; }
    }
}
