using System;

namespace SimpleCheckLab
{
	class Program
	{
		static void Main(string[] args)
		{
			bool isSequenceIncreasing = true;
			int currentValue = 0;
			int previousValue = Int32.MinValue;

			Console.WriteLine("Start enter sequence:");

			do
			{
				currentValue = Int32.Parse(Console.ReadLine());
				if (previousValue > currentValue && currentValue >=0)
				{
					isSequenceIncreasing = false;
				}

				previousValue = currentValue;
			} while (currentValue >= 0);

			if (isSequenceIncreasing)
			{
				Console.WriteLine("Sequence is ordered");
			}
			else
			{
				Console.WriteLine("Sequence is out of order");
			}

			Console.ReadLine();
		}
	}
}
