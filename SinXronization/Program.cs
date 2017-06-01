using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SinXronization
	{
	class Program
		{
		static void Procedure()
			{
			Console.WriteLine($"Secondary Thread Start Id = {Thread.CurrentThread.ManagedThreadId}");
			Console.ForegroundColor = ConsoleColor.Yellow;

			//do
			//	{
			//	Console.Write(".");
			//	Thread.Sleep(50);
			//	} while(true);
			for(int i = 0; i < 50; i++)
				{
				Console.Write(".");
				Thread.Sleep(50);
				}
			Console.WriteLine($"\nSecondary Thread End");
			}
		static void Main(string[] args)
			{
			Thread thread = new Thread(Procedure);
			thread.IsBackground = true;
			Console.WriteLine($"\nMAIN Thread Start Id = {Thread.CurrentThread.ManagedThreadId}");
			thread.Start();
			Thread.Sleep(1000);
			Console.WriteLine($"\nMAIN Thread End");
			
			}
		}
	}
