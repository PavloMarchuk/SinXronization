using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Interloked
	{

	class Counter
		{
		public static int count;
		}


	class Program
		{
		static void Main(string[] args)
			{
			Thread[] threads = new Thread[5];

			for(int i = 0; i < threads.Length; i++)
				{
				threads[i] = new Thread(() =>
					{
						for(int j = 0; j < 1000000; j++)
							{
							//++Counter.count;
							Interlocked.Increment(ref Counter.count);
							}
					});
				threads[i].Start();
				}
			for(int i = 0; i < threads.Length; i++)
				{
				threads[i].Join();
				}
				Console.WriteLine((Counter.count));
			}
		}
	}
