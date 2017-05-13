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
            appServer.listen();
        }
    }
}
