using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Governing_Equations
{
    public class Calculations
    {

        // Call the function pass all parameters
        public static double[] MxCalculation(double Tsat, double K, double n, double M0, int starting_Ta, int ending_Ta, int variation)
        {
            int MxSize = (int)((ending_Ta - starting_Ta) / variation) + 1;
            double[] MxValues = new double[MxSize];
            for (int i = 0; i < MxSize; i += variation)
            {
                double temp = -K * Math.Pow((((starting_Ta + 273) / Tsat) - 1), n);
                starting_Ta += variation;
                MxValues[i] = M0 * Math.Exp(temp);
            }
            return MxValues;
        }
    }
}
