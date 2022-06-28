using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Interface
{
    public interface IWsGameServer
    {
        public void StartGameServer();
        public void StopGameServer();
        public void RestartGameServer();
    }
}
