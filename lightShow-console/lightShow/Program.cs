using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lightShow
{
    class Program
    {
        static void Main(string[] args)
        {
            AppServer appServer = new AppServer();
            int httpPort;
            int udpPort;
            string input;
            while (true)
            {
                Console.WriteLine("Enter UDP port:");
                input = Console.ReadLine();
                if (Int32.TryParse(input, out udpPort))
                {
                    break;
                }
                Console.WriteLine("Invalid input. try again");

            }
            while (true)
            {
                Console.WriteLine("Enter HTTP port:");
                input = Console.ReadLine();
                if (Int32.TryParse(input, out httpPort))
                {
                    break;
                }
                Console.WriteLine("Invalid input. try again");

            }

            appServer.listen(httpPort, udpPort);
        }
    }
}
