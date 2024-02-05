using System;
using System.Collections.Generic;
using System.Text;

namespace mbf_date
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentDate = 0;
            int previousDate = 0;
            int nextDate = 0;
            String dateFormat = null;

            Getopt g = new Getopt("mbf_date", args, "?cpnf:");
            int c;
            while ((c = g.getopt()) != -1)
            {
            	switch(c)
            	{
                    case 'c':
                        currentDate = 1;
                        break;
            		case 'p':
                        previousDate = 1;
                        break;
            		case 'n':
                        nextDate = 1;
            			break;
            		case 'f':
                        dateFormat = g.Optarg;
            			break;
            		case '?':
                        Console.WriteLine("mbf_date [-c|-p|-n] [-f<date_format>]");
                        Console.WriteLine("-c Current date");
                        Console.WriteLine("-p Previous date");
                        Console.WriteLine("-n Next date");
                        Console.WriteLine("format : yyyyMMdd where yyyy is year, MM is month, dd is day");
                        Environment.Exit(1);
            			break;
            		default:
            			Console.WriteLine("getopt() returned " + c);
            			break;
            	}
            }

            if ((currentDate + previousDate + nextDate) > 1)
            {
                Console.WriteLine("Options -c, -p and -n could not be simultaneous!");
                Environment.Exit(2);
            }

            MBFDate d;

            if (dateFormat == null)
            {
                d = new MBFDate();
            }
            else
            {
                d = new MBFDate(dateFormat);
            }

            if (currentDate == 1)
            {
                Console.Write("{0}", d.getCurrentDate());
            }
            else if (previousDate == 1)
            {
                Console.Write("{0}", d.getPreviousDate());
            }
            else if (nextDate == 1)
            {
                Console.Write("{0}", d.getNextDate());
            }
            else
            {
                Console.Write("{0}", d.getCurrentDate());
            }
        }
    }
}
