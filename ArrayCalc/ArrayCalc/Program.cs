using System;
using System.Diagnostics;

namespace ArrayCalc
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            double[] tab = { 5, 3, 6, 8, 2, 1, 0, -9, -2, 4, -6 };
            st.Start();
            var res = tab.Extremes();
            var avg = tab.Average();
            var variance = tab.Variance();
            //Task.WaitAll(res, avg, variance);
            st.Stop();
            Console.WriteLine($"Extremes={res.Result}, Average={avg.Result}, Variance={variance.Result}");
            Console.WriteLine(st.ElapsedTicks);
        }
    }
}