using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsProcessMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            String processName = String.Empty;
            String startUpPath = String.Empty;
            int waitMinutes = 0;

            if (args.Length == 0)
            {
                Console.WriteLine("Process Name:");
                processName = Console.ReadLine();
                Console.WriteLine("Process path:");
                startUpPath = Console.ReadLine();
                Console.WriteLine("Sleep time (minute):");
                waitMinutes = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                processName = args[0];
                startUpPath = args[1];
                waitMinutes = Convert.ToInt32(args[2]);
            }


            while (true)
            {
                System.Console.WriteLine("[" + DateTime.Now.ToString("s") + "] Start to scan process...");
                bool findFlag = false;

                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                {
                    if (p.ProcessName == processName)
                    {
                        findFlag = true;
                        break;
                    }
                }



                if (findFlag == false)
                {
                    System.Console.WriteLine("[" + DateTime.Now.ToString("s") + "] " + processName + " not found. Start the process.");
                    System.Diagnostics.Process.Start(startUpPath);
                }
                else
                {
                    System.Console.WriteLine("[" + DateTime.Now.ToString("s") + "] " + processName + " found. Do nothing.");
                }

                Thread.Sleep(waitMinutes * 60000);
            }

            System.Console.ReadLine();
        }
    }
}
