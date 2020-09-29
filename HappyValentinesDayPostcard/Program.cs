using System;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace HappyValentinesDayPostcard
{
	public class Program
	{

		static void Main(string[] args)
		{
			Random rnd = new Random();

			while (true)
			{
				int randNum = rnd.Next(30, 70);
				int randColor = rnd.Next(16);
				char heart = '@';
				char space = ' ';

				StringBuilder sb = new StringBuilder();

				for (int i = 0; i < 17; i++)
				{
					sb.Append(RepeatedString(' ', randNum));

					if (i < 3)
					{
						sb.Append(RepeatedString(space, 8 - i * 2));
						sb.Append(RepeatedString(heart, 6 + i * 4));
						sb.Append(RepeatedString(space, 11 - i * 4));
						sb.Append(RepeatedString(heart, 6 + i * 4));
					}

					if (i == 3)
					{
						sb.Append(RepeatedString(space, 2));
						sb.Append(RepeatedString(heart, 17));
						sb.Append(RepeatedString(space, 1));
						sb.Append(RepeatedString(heart, 17));
					}

					if (i == 4)
					{
						sb.Append(RepeatedString(space, 1));
						sb.Append(RepeatedString(heart, 37));
					}

					if (i > 4 && i <= 7)
					{
						sb.Append(RepeatedString(heart, 39));
					}

					if (i > 7)
					{
						sb.Append(RepeatedString(space, 2 * (i - 7)));
						sb.Append(RepeatedString(heart, 39 - 4 * (i - 7)));
					}

					sb.AppendLine();
					Console.ForegroundColor = (ConsoleColor) randColor;
					Console.Write(sb.ToString());
					Thread.Sleep(100);
				}

				Console.WriteLine(sb.ToString());
				
				Console.WriteLine();
				Console.WriteLine($"{RepeatedString(space, randNum)}С Днем Святого Валентина, Белочкин!");

				for (int i = 0; i < 10; i++)
				{
					Console.WriteLine();
					Thread.Sleep(100);
				}

				Thread.Sleep(2000);
			}
		}

		static string RepeatedString(char character, int repeatsCount)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < repeatsCount; i++)
			{
				sb.Append(character);
			}

			return sb.ToString();
		}
	}
}
