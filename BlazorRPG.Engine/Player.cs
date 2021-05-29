using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRPG.Engine
{
    public class Player : IGameObject
    {
        private static int playerIdCounter = 0;

        public long Id { get; }

        public Player()
        {
            Id = playerIdCounter++;
        }

        public void Update()
        {

        }

        private DateTime LastActive { get; set; } = DateTime.Now;
        public void Touch()
        {
            this.LastActive = DateTime.Now;
        }

        public bool IsTimedOut => LastActive.AddSeconds(5) < DateTime.Now;
    }
}
