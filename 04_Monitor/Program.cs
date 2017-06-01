using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_Monitor
	{
	class Program
		{
		class InterlokerCounter
			{
			int field1;
			int field2;
			public int Field1
				{
				get { return field1; }
				}
			public int Field2
				{
				get { return field2; }
				}
			public void UpdateFields()
				{
				for(int i = 0; i < 1000000; ++i)
					{
					//Interlocked.Increment(ref field1);
					//if(field1 % 2 == 0)
					//	Interlocked.Increment(ref field2);
					Monitor.Enter(this);
					try
						{
						++field1;
						if(true)
							{
							if(field1 % 2 == 0)
								++field2;
							}
						}
					finally
						{
						Monitor.Exit(this);
						}
					}
				}
			}
		

		static void Main(string[] args)
			{
			InterlokerCounter counter = new InterlokerCounter();
			Thread[] threadS = new Thread[5];
			for(int i = 0; i < threadS.Length; i++)
				{
				threadS[i] = new Thread(counter.UpdateFields);
				threadS[i].Start();
				}
			
			for(int i = 0; i < threadS.Length; i++)
				{
				threadS[i].Join();
				}

			Console.WriteLine(counter.Field1);
			Console.WriteLine(counter.Field2);
			}
		}
	}
