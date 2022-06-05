using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCalc
{
    public static class Calculations
    {
        public static async Task<(double Min, double Max)> Extremes(this double[] array)
        {
            double min, max;
            min = max = array[0];
            await Task.Run(() =>
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min) min = array[i];
                    if (array[i] > max) max = array[i];
                }
            });
            return (min, max);
        }

        public static async Task<double> Average(this double[] array)
        {
            double sum = 0;
            await Task.Run(() =>
            {
                foreach (var t in array)
                    sum += t;
            });
            return sum / array.Length;
        }

        public static async Task<double> Variance(this double[] array)
        {
            double k = array[0];
            double Ex, Ex2;
            Ex = Ex2 = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Ex += array[i] - k;
                    Ex2 += (array[i] - k) * (array[i] - k);
                }
            });
            return (Ex2 - (Ex * Ex) / array.Length) / (array.Length - 1);
        }
    }
}
