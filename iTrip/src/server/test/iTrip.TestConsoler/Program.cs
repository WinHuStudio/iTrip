using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.TestConsoler.Wcf;

namespace iTrip.TestConsoler
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("*****Read the fellowing tip to start test*****");
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("*****press 1 to test Register Account");
                    Console.WriteLine("*****press 2 to test Switch Status");
                    Console.WriteLine("*****press quit to close");

                    var line = Console.ReadLine().ToLower();
                    if (line == "quit")
                        break;
                    if (line == "1")
                    {
                        WcfPassport passport = new WcfPassport();
                        passport.Register();
                    }
                    else if (line == "2")
                    {
                        WcfStatus passport = new WcfStatus();
                        passport.SwitchStatus();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
