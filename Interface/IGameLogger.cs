using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Interface
{
    public interface IGameLogger
    {
        void Print(string msg);
        void Infor(string msg);
        void Warning(string msg,Exception ex);
        void Error(string msg,Exception ex);

    }
}
