using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lightShow
{
    class AppServer
    {
        HttpListener listener = new HttpListener();
        AppUdp appUdp;

        public void listen(int httpPort, int udpPort)
        {
            string url = "http://*:" + httpPort + "/";

            appUdp = new AppUdp(udpPort);

            listener.Prefixes.Add(url);
            Console.WriteLine("Listening to [" + url + "]");
            listener.Start();

            while (true)
            {
                var context = listener.GetContext();
                var response = context.Response;
                string responseString;
                string htmlPath = Directory.GetCurrentDirectory() + "\\index.html";
                Console.WriteLine("Request recieved: " + context.Request.RawUrl);
                switch (context.Request.RawUrl)
                {
                    case "/do-a":
                        appUdp.send(BitConverter.GetBytes(1));
                        responseString = "doing A";
                        break;
                    case "/do-b":
                        appUdp.send(BitConverter.GetBytes(2));
                        responseString = "doing B";
                        break;
                    case "/status":
                        responseString = "Everything is OK";
                        break;
                    default:
                        responseString = File.ReadAllText(htmlPath);
                        break;
                }

                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                var output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }

        }


    }
}
