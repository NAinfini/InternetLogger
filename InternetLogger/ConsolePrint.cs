using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace InternetLogger
{
    internal class ConsolePrint
    {
        
        
        public string internetStatus;
        public IPStatus resultFromGoogle;
        public IPStatus resultFromRogers;
        public IPStatus resultFromRouter;
        public string currentTime;

        private string[] itemsToPrint;
        private string emptyString = "                                                                              ";
        public ConsolePrint()
        {
            itemsToPrint = new string[5];
            internetStatus = "Disconnected";
            resultFromGoogle = IPStatus.Unknown;
            resultFromRogers = IPStatus.Unknown;
            resultFromRouter = IPStatus.Unknown;
        }

        public void printConsole()
        {
            try
            {
                itemsToPrint[0] = "         Time:" + currentTime + emptyString;
                itemsToPrint[1] = "         Internet status:" + internetStatus + emptyString;
                itemsToPrint[2] = "         Ping Google: " + resultFromGoogle + emptyString;
                itemsToPrint[3] = "         Ping Rogers: " + resultFromRogers + emptyString;
                itemsToPrint[4] = "         Ping Router: " + resultFromRouter + emptyString;
                for (int i = 0; i < itemsToPrint.Length; i++)
                {
                    Console.SetCursorPosition(0, i + 1);
                    Console.Write(itemsToPrint[i]);
                }
            }
            catch(Exception e)
            {
                Console.SetCursorPosition(0, 10);
                Console.WriteLine(e.ToString());
            }
            

        }
    }
}
