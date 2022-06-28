using GameServer.Interface;
using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Handler
{
    public class WsGameServer : WsServer, IWsGameServer
    {
        private int _port;
        public PlayerManager _playermanager;
        public IGameLogger _logger;
        public WsGameServer(IPAddress address,int port,PlayerManager playermanager, IGameLogger logger) : base(address, port)
        {
            _port = port;
            _playermanager = playermanager;
            _logger = logger;
        }
        protected override TcpSession CreateSession()
        {
            //Console.WriteLine("New Session connected!");
            _logger.Infor("New Session connected!");
            var player = new Player(this,_logger);
            _playermanager.AddPlayer(player.Id.ToString(), player);
            return player;
        }


        public void StartGameServer()
        {
            // Start GameServer
            if (Start())
            {
                Console.WriteLine("Server Start on port " + _port);
            }
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine("Server Start error : " + error);
        }
        public void StopGameServer()
        {
            // Stop GameServer
            this.Stop();
        }

        public void RestartGameServer()
        {
            // RestartStart GameServer
            this.Restart();
        }

        //-----------------------------

        //protected override void OnConnected(TcpSession session)
        //{
        //    Console.WriteLine(session.Id + " => Connected");
        //    var player = new Player(this);
        //    _playermanager.AddPlayer(session.Id.ToString(), player);
            
        //}

        protected override void OnDisconnected(TcpSession session)
        {
            //Console.WriteLine(session.Id + " => Disconnected");
            _logger.Infor($"{session.Id} Disconnected");
            _playermanager.RemovePlayer(session.Id.ToString());
        }

        

    }
}
