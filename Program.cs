using System;
using System.Diagnostics;
using System.Linq;

namespace KillRiotProcesses
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array of process names to search and kill
            string[] processesToKill = new string[]
            {
                "VALORANT-Win64-Shipping",
                "RiotClientServices",
                "LeagueClient",
                "League of Legends",
                "RiotClientCrashHandler",
                "RiotClientUx",
                "RiotClientUxRender"
            };

            // Loop through each process name
            foreach (string processName in processesToKill)
            {
                try
                {
                    // Get the processes matching the current process name
                    Process[] matchingProcesses = Process.GetProcessesByName(processName);

                    // If there are matching processes, kill them
                    if (matchingProcesses.Any())
                    {
                        foreach (Process process in matchingProcesses)
                        {
                            Console.WriteLine($"Killing process: {process.ProcessName} (ID: {process.Id})");
                            process.Kill();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No running process found for: {processName}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to kill process: {processName}. Error: {ex.Message}");
                }
            }

            Console.WriteLine("Script execution complete.");
        }
    }
}
