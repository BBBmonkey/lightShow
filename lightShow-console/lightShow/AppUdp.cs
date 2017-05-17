using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lightShow
{
    class AppUdp
    {
        private int port;

        public AppUdp(int _port)
        {
            port = _port;
        }

        public void send(byte[] data)
        {
            UdpClient udpClient = new UdpClient();
            udpClient.Send(data, data.Length, "localhost", port);
        }
    }
}
