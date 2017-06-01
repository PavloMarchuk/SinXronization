using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_ThreadState
	{
	class Program
		{		
		class MyThread
			{
			int testVar=0;
			Thread thread;
			public MyThread()
				{
				thread = new Thread(ThreadFunc);
				thread.IsBackground = true;
				Console.WriteLine($"ThreadState = {thread.ThreadState}");
				thread.Start();
				Console.WriteLine($"ThreadState = {thread.ThreadState}");
				}
			private void ThreadFunc()
				{
				Console.WriteLine($"ID вторинного потоку {thread.ManagedThreadId}");
				while(true)
					{
					if(testVar == 0)
						{
						Thread.Sleep(100);
						Console.WriteLine(".");
						}
					else
						{						
						thread.Abort();
						}					
					}
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Вторинний поток завершено");
				
				}

			public void WaitOne()
				{
				thread.Suspend();
				}
			public void Resume()
				{
				thread.Resume();
				}
			public void Stop()
				{
				thread.Suspend();
				testVar = 1;
				thread.Resume();
				Thread.Sleep(1000);				
				}
			}

		static void Main(string[] args)
			{
			MyThread my = new MyThread();
			Thread.Sleep(1000);
			my.WaitOne();
			Console.WriteLine("Вторинний поток зупинено");
			Console.ReadKey();
			my.Resume();
			Console.ReadKey();
			my.Stop();
			}
		}
	}
