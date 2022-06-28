using GameServer.Handler;
using GameServer.Interface;
using System;
using System.Net;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameLogger logger = new Logger();
            var Playermanager = new PlayerManager(logger);
            var wsServer = new WsGameServer(IPAddress.Any, 8080, Playermanager, logger);
            wsServer.StartGameServer();
            logger.Infor("Server Start!");
            for(; ; )
            {
                var type = Console.ReadLine();
                if(type == "restart")
                {
                    wsServer.RestartGameServer();
                }
                if (type == "stop")
                {
                    wsServer.StopGameServer();
                }
            }
        }
    }
}
