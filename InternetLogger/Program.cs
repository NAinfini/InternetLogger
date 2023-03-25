using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InternetLogger
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Boolean googleConnected;
            Boolean rogersConnected;
            Boolean routerConnected;
            Boolean currentStatus = false;
            FileManager FM = new FileManager();
            ConsolePrint printOnConsole = new ConsolePrint();
            DateTime currentTime;
            DateTime switchTime = DateTime.Now;
            Ping ping = new Ping();
            while (true)
            {
                currentTime = DateTime.Now;
                printOnConsole.currentTime = currentTime.ToString();
                PingReply pingGoogle = ping.Send(IPAddress.Parse("8.8.8.8"));
                PingReply pingRogers = ping.Send(IPAddress.Parse("4.2.2.2"));
                PingReply pingRouter = ping.Send(IPAddress.Parse("1.1.1.1"));
                googleConnected = (printOnConsole.resultFromGoogle = pingGoogle.Status) ==  IPStatus.Success;
                rogersConnected = (printOnConsole.resultFromRogers = pingRogers.Status) == IPStatus.Success;
                routerConnected = (printOnConsole.resultFromRouter = pingRouter.Status) ==  IPStatus.Success;
                Boolean pastStatus = currentStatus;
                if(currentStatus = (googleConnected || rogersConnected || routerConnected))
                {
                    printOnConsole.internetStatus = "Connected";
                }
                else
                {
                    printOnConsole.internetStatus = "Disconnected";
                }
                if(pastStatus ^ currentStatus) {
                    FM.addToFIle(currentTime.ToString("yyyy.MM.dd")+".txt", currentTime.ToString("[yyyy.MM.dd HH:mm:ss]")+ " Google: " +
                        pingGoogle.Status.ToString()+", Rogers: "+pingRogers.Status.ToString()+", Router: " 
                        + pingRogers.Status.ToString()+", Lasted for: " + (currentTime - switchTime).TotalSeconds.ToString()+" seconds");
                    switchTime = currentTime;
                }
                printOnConsole.printConsole();
                if (!currentStatus)
                {
                    Thread.Sleep(1000);
                }
                else
                {
                    Thread.Sleep(10000);
                }
                
            }
        }

        
    }
}