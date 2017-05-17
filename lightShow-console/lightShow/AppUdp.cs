using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lightShow
{
    class AppUdp
    {
        private int port;
        private int listenPort;

        public AppUdp(int _port)
        {
            port = _port;
            listenPort = _port + 1;
        }

        public void send(byte[] data)
        {
            UdpClient udpClient = new UdpClient();
            Console.WriteLine("[UDP Sender] Sending command to [localhost:{1}]", port);
            udpClient.Send(data, data.Length, "localhost", port);
        }

        public string listen()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                Console.WriteLine("[UDP Listener] Waiting for status broadcast from port {0}", listenPort);
                byte[] bytes = listener.Receive(ref groupEP);
                return  Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("[UDP Listener] Error getting status message");
                Console.WriteLine(e.ToString());
                return "error";
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
