using System;
namespace Laba5ChM
{
    class Program
    {
        static void Main(string[] args)
        {
            double e = 0.000001;
			//int a0 = 1, a1 = -4, a2 = 2, a3 = 1, a4 = -3, a5 = 4;
            Console.WriteLine("Полiном:\n4*x^5-3*x^4+1*x^3+2*x^2-4*x^1+1 = 0\nТочнiсть:{0}\n", e);
            /*double a = -1;*/ /*double b = -0.5;*/
			double a = -1; double b = -0.5;
			Show(a, b, e);
			a = 0.2;  b = 0.5;
			Show(a, b, e);
			a = 0.5; b = 1;
			Show(a, b, e);
		}
		public static void Show(double a, double b, double e)
        {
			class5L L = new class5L();
			Console.WriteLine(L.HordMethod(a, b, e));
			Console.WriteLine(L.NewtonMethod(e, a));
			Console.WriteLine(L.BisekMethod(a, b, e));
            Console.WriteLine();
		}
	}
	public class class5L
	{
		double funk(double x)
		{
			return (4 * Math.Pow(x, 5) - 3 * Math.Pow(x, 4) + Math.Pow(x, 3) + 2 * Math.Pow(x, 2) - 4 * x + 1);
		}

		double df(double x)
		{
			return (20 * Math.Pow(x, 4) - 12 * Math.Pow(x, 3) + 3 * Math.Pow(x, 2) + 4 * x - 4);
		}

		public string NewtonMethod(double e, double x0)
		{
			int n = 0;
			double x = x0;
			do
			{
				x = x - funk(x) / df(x);
				n++;
			}
			while (Math.Abs(funk(x)) >= e);
            Console.WriteLine("NewtonMethod:");
			return $"x = {x:f6};	Number of iterations: " + n;
		}

		public string HordMethod(double a, double b, double e)
		{
			int n = 0;
			while (Math.Abs((b) - (a)) > e)
			{
				a = b - (b - a) * funk(b) / (funk(b) - funk(a));
				b = a -(a - b) * funk(a) / (funk(a) - funk(b));
				n++;
			}
            Console.WriteLine("HordMethod:");
			return $"x = {b:f6};	Number of iterations: " + n;
		}

		public string BisekMethod(double a, double b, double e)
		{
			double c;
			int n = 0;
			while (b - a > e)
			{
				c = (a + b) / 2;
				if (funk(b) * funk(c) < 0)
				{
					a = c;
				}
				else
				{
					b = c;
				}
				n++;
			}
            Console.WriteLine("BisekMethod:");
			return $"x = {((a + b) / 2):f6}	Number of iterations: " + n;
		}
	}
}
