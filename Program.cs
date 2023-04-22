using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine(@"
-- PineCone Version 1 --
-- Created By ShadowX --
-- Type Help For A List Of Commands --
");
        Console.ResetColor();

        List<string> commands = new List<string>();

        while (true)
        {
            // Read user input from the console
            string input = Console.ReadLine();

            // Reset color
            Console.ResetColor();

            if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Available commands:");
                Console.WriteLine("- Cls: Clears the console.");
                Console.WriteLine("- Print(\"foo\"): Prints the specified text.");
                Console.WriteLine("- Run: Runs the previously entered commands in order.");
                Console.WriteLine("- Wait(n): Waits for n seconds before executing the next command.");
                Console.WriteLine("- End: Ends the program.");
                Console.WriteLine("- Help: Opens the help menu.");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("- Notice: When You Recieve An Error, You Must Restart The Program.");
                Console.ForegroundColor = ConsoleColor.White;
                continue; // Start the loop again
            }

            if (input.Equals("cls", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear(); // Clear the console

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(@"
-- PineCone Version 1 --
-- Created By ShadowX --
-- Type Help For A List Of Commands --
");
                Console.ResetColor();

                continue; // Start the loop again
            }

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Equals("run", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    foreach (string command in commands)

                    {
                        if (command.Equals("cls", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Clear();
                            commands.Clear();
                        }
                        else if (command.ToLower().Contains("print(\"") && command.EndsWith("\")"))
                        {
                            // Extract the text inside the quotes
                            int startIndex = command.IndexOf("\"") + 1;
                            int endIndex = command.LastIndexOf("\"");
                            string textToPrint = command.Substring(startIndex, endIndex - startIndex);

                            Console.WriteLine(textToPrint);
                        }
                        else if (command.ToLower().StartsWith("wait(") && command.EndsWith(")"))
                        {
                            // Extract the number of seconds to wait
                            int waitTime;
                            if (int.TryParse(command.Substring(5, command.Length - 6), out waitTime))
                            {
                                Thread.Sleep(waitTime * 1000); // Wait for the specified time
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Invalid number of seconds specified in Wait command.");
                                Console.ResetColor();
                            }
                        }
                        else if (command.Equals("end", StringComparison.OrdinalIgnoreCase))
                        {
                            Environment.Exit(0); // End the program
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Unknown command '" + command + "'.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.ResetColor();
                }
                else
                {
                    commands.Add(input);
                }
            }
        }
    }
}
