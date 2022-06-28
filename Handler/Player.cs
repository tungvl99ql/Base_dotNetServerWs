using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GameServer.Interface;
using GameServer.Messaging;
using NetCoreServer;
using Newtonsoft.Json;

namespace GameServer.Handler
{
    public class Player :WsSession
    {
        
        public string SessionId { get; set; }
        public string Name { get; set; }

        private bool IsDisconnected { get; set; }
        public object UserInfo { get; private set; }
        IGameLogger _logger;
        public Player(WsServer server, IGameLogger logger) : base(server)
        {
            SessionId = this.Id.ToString();
            IsDisconnected = false;
            _logger = logger;

        }


        public override bool Disconnect()
        {
            return base.Disconnect();
        }


        public override void OnWsConnected(HttpRequest request)
        {
            //Console.WriteLine("Player Connected!");
            IsDisconnected = false;
        }


        public override void OnWsDisconnected()
        {
            base.OnWsDisconnected();
            IsDisconnected = false;
        }
        public override void OnWsReceived(byte[] buffer, long offset, long size)
        {
            var mess = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            //Console.WriteLine($"CLient {SessionId} send message {mess}");
           
            try
            {
                var WSmess = JsonConvert.DeserializeObject<WsMessage<object>>(mess);
                switch (WSmess.Tags)
                {  
                    case Tags.LOGIN:
                        var loginData = JsonConvert.DeserializeObject<LoginData>(WSmess.Data.ToString());
                        _logger.Infor($" Mess [{WSmess.Tags}] -- username:{loginData.Username} | password:{loginData.Password}");
                        SendMessage("login thanh cong");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                _logger.Error("OnWsReceived error", e);
            }
        }




        public bool SendMessage(string mes)
        {
            return this.SendTextAsync(mes);
        }



        //====================================

        public override void OnWsError(string error)
        {
            base.OnWsError(error);
        }

        public override void OnWsError(SocketError error)
        {
            base.OnWsError(error);
        }

        public override void OnWsPing(byte[] buffer, long offset, long size)
        {
            base.OnWsPing(buffer, offset, size);
        }

        public override void OnWsPong(byte[] buffer, long offset, long size)
        {
            base.OnWsPong(buffer, offset, size);
        }

        

        public override long Receive(byte[] buffer)
        {
            return base.Receive(buffer);
        }

        public override long Receive(byte[] buffer, long offset, long size)
        {
            return base.Receive(buffer, offset, size);
        }

        public override string Receive(long size)
        {
            return base.Receive(size);
        }

        public override void ReceiveAsync()
        {
            base.ReceiveAsync();
        }

        public override long Send(byte[] buffer)
        {
            return base.Send(buffer);
        }

        public override long Send(byte[] buffer, long offset, long size)
        {
            return base.Send(buffer, offset, size);
        }

        public override long Send(string text)
        {
            return base.Send(text);
        }

        public override bool SendAsync(byte[] buffer)
        {
            return base.SendAsync(buffer);
        }

        public override bool SendAsync(byte[] buffer, long offset, long size)
        {
            return base.SendAsync(buffer, offset, size);
        }

        public override bool SendAsync(string text)
        {
            return base.SendAsync(text);
        }

        protected override void Dispose(bool disposingManagedResources)
        {
            base.Dispose(disposingManagedResources);
        }

        protected override void OnConnected()
        {
            base.OnConnected();
        }

        protected override void OnConnecting()
        {
            base.OnConnecting();
        }

        protected override void OnDisconnected()
        {
            base.OnDisconnected();
        }

        protected override void OnDisconnecting()
        {
            base.OnDisconnecting();
        }

        protected override void OnEmpty()
        {
            base.OnEmpty();
        }

        protected override void OnError(SocketError error)
        {
            base.OnError(error);
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            base.OnReceived(buffer, offset, size);
        }

        protected override void OnReceivedRequest(HttpRequest request)
        {
            base.OnReceivedRequest(request);
        }

        protected override void OnReceivedRequestError(HttpRequest request, string error)
        {
            base.OnReceivedRequestError(request, error);
        }

        protected override void OnReceivedRequestHeader(HttpRequest request)
        {
            base.OnReceivedRequestHeader(request);
        }

    }
}
