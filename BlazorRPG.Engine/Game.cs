using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorRPG.Engine
{
    public static class Game
    {
        private static object lockObj = new object();

        private static Dictionary<long, Player> _players = new Dictionary<long, Player>();

        public static Player[] PlayerSnapshot { get; private set; } = new Player[0];

        private static void SetSnapshots()
        {
            lock (lockObj)
            {
                PlayerSnapshot = _players
                    .Select(p => p.Value)
                    .ToArray();
            }
        }

        public static void Subscribe(Player player)
        {
            lock (lockObj)
            {
                _players.Add(player.Id, player);
            }
        }

        public static void UpdateLoop()
        {
            while (true)
            {
                try
                {
                    var next = DateTime.Now.AddMilliseconds(1000 / 120); // 120 fps, fast enough to have new frames each time a client renders

                    Update();

                    var delay = next - DateTime.Now;
                    if (delay < TimeSpan.Zero) delay = TimeSpan.Zero;

                    Thread.Sleep(delay);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private static void Update()
        {
            var allPlayers = PlayerSnapshot;

            UpdatePlayers(allPlayers);

            SetSnapshots();
        }

        private static void UpdatePlayers(Player[] players)
        {
            List<Player> toRemove = new List<Player>();

            foreach (var player in players)
            {
                if (player.IsTimedOut)
                {
                    toRemove.Add(player);
                    continue;
                }

                player.Update();
            }

            lock (lockObj)
            {
                foreach (var player in toRemove)
                {
                    _players.Remove(player.Id, out _);
                }
            }
        }
    }
}
