using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRPG.Engine
{
    public interface IWithTimeout
    {
        long Id { get; }

        bool IsTimedOut { get; }
    }
}
