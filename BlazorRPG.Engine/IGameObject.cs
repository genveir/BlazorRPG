using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRPG.Engine
{
    public interface IGameObject : IUpdatable, IWithTimeout
    {
    }
}
