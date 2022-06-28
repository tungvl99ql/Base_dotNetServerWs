using GameServer.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Handler
{
    public class PlayerManager
    {
        public ConcurrentDictionary<string, Player> ListPlayer;
        IGameLogger _logger;
        public PlayerManager(IGameLogger logger)
        {
            _logger = logger;
            ListPlayer = new ConcurrentDictionary<string, Player>();
        }

        public void AddPlayer(string sessionId, Player player)
        {
            ListPlayer.TryAdd(sessionId, player);
            _logger.Infor($"---- Player online [{ListPlayer.Count}] ------");
            //Console.WriteLine($"--------- All {ListPlayer.Count} Player ------------");
            //foreach(var a in ListPlayer)
            //{
            //    Console.WriteLine($"{a.Key} | {a.Value}");
            //}
            //Console.WriteLine($"----------------------------------------------------");
        }

        public void RemovePlayer(string sessionId)
        {
            ListPlayer.TryRemove(sessionId, out var player);
            //Console.WriteLine($"--------- All {ListPlayer.Count} Player ------------");
            //foreach (var a in ListPlayer)
            //{
            //    Console.WriteLine($"{a.Key} | {a.Value}");
            //}
            //Console.WriteLine($"----------------------------------------------------");
            _logger.Infor($"---- Player online [{ListPlayer.Count}] ------");
        }
    }
}
