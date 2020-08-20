using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailNotification;

namespace MailNotificationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Notification Test = new Notification();
            var Result = Test.Connect("./Settings.json").Result;
            Console.WriteLine(Result);
            Test.SendCloseMessage("");
            Console.ReadLine();
        }
    }
}
