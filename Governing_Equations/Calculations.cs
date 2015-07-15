using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Governing_Equations
{
    public class Calculations
    {
        public static List<Mx_Value> MxCalculation(double Tsat, double K, double n, double M0, double starting_Ta, double ending_Ta, double variation_Ta)
        {
            List<Mx_Value> MxValues = new List<Mx_Value>();
            for (double i = starting_Ta; i <= ending_Ta; i += variation_Ta)
            {
                double temp = -K * Math.Pow((((i + 273) / Tsat) - 1), n);
                MxValues.Add(new Mx_Value
                {
                    Ta_Value = i,
                    Mx_Result = Math.Round(M0 * Math.Exp(temp), Parameters.Round_Decimal)
                });
            }
            return MxValues;
        }
        public static List<Mmin_Value> MminCalculation(double Tsat, double K, double n, double M0, double starting_Tc, double ending_Tc, double variation_Tc)
        {
            List<Mmin_Value> MminValues = new List<Mmin_Value>();
            for (double i = starting_Tc; i <= ending_Tc; i += variation_Tc)
            {
                double temp = -K * Math.Pow((((i + 273) / Tsat) - 1), n);
                MminValues.Add(new Mmin_Value
                {
                    Tc_Value = i,
                    Mmin_Result = Math.Round(M0 * Math.Exp(temp), Parameters.Round_Decimal)
                });
            }
            return MminValues;
        }
        public static List<Tb_Value> TbCalculation(double starting_Ta, double ending_Ta, double variation_Ta, double starting_Tevap, double ending_Tevap, double variation_Tevap)
        {
            List<Tb_Value> Tb_result = new List<Tb_Value>();
            for (double i = starting_Ta; i <= ending_Ta; i += variation_Ta)
            {
                for (double j = starting_Tevap; j <= ending_Tevap; j += variation_Tevap)
                {

                    Tb_result.Add(new Tb_Value
                    {
                        Ta_Value = i,
                        Tevap_Value = j,
                        Tb_Result = Math.Round((i * i) / j, Parameters.Round_Decimal)
                    });
                }
            }
            return Tb_result;
        }
        public static List<Td_Value> TdCalculation(double starting_Ta, double ending_Ta, double variation_Ta, double starting_Tc, double ending_Tc, double variation_Tc, List<Tb_Value> Tb_Result)
        {
            List<Td_Value> Td_Result = new List<Td_Value>();
            for (double i = starting_Ta; i <= ending_Ta; i += variation_Ta)
            {
                foreach (Tb_Value Tb_value in Tb_Result)
                {
                    for (double j = starting_Tc; j <= ending_Tc; j += variation_Tc)
                    {
                        Td_Result.Add(new Td_Value
                        {
                            Ta_Value = i,
                            Tb_Value = Tb_value.Tb_Result,
                            Tc_Value = j,
                            Td_Result = Math.Round((i * Tb_value.Tb_Result) / j, Parameters.Round_Decimal)
                        });
                    }
                }
            }
            return Td_Result;
        }
        public static List<H_Value> HCalculation(double R, double CPAd, List<Mx_Value> MxResult, double CPr, double starting_Tc, double ending_Tc, double Tc_Variation, double starting_Tsat, double ending_Tsat, double Tsat_Variation)
        {
            List<H_Value> H_Result = new List<H_Value>();
            for (double i = starting_Tc; i <= ending_Tc; i += Tc_Variation)
            {
                for (double j = starting_Tsat; j <= ending_Tsat; j += Tsat_Variation)
                {
                    foreach (Mx_Value mxResult in MxResult)
                    {
                        H_Result.Add(new H_Value
                        {
                            Tc_Value = i,
                            Tsat_Value = j,
                            Mx_Value = mxResult.Mx_Result,
                            H_Result = Math.Round(R * (CPAd + (mxResult.Mx_Result * CPr)) * (i / j), Parameters.Round_Decimal)
                        });
                    }
                }
            }
            return H_Result;
        }
        public static double Integration(double lowerLimit, double upperLimit, double innerValue)
        {
            return (innerValue * upperLimit) - (innerValue * lowerLimit);
        }
        public static List<Qab_Value> QabCalculation(double CPAd, List<Mx_Value> MxResult, double CPr, double starting_Ta, double ending_Ta, double Ta_Variation, List<Tb_Value> Tb_Result)
        {
            List<Qab_Value> Qab_Result = new List<Qab_Value>();
            foreach (Mx_Value mxResult in MxResult)
            {
                foreach (Tb_Value tbValue in Tb_Result)
                {
                    for (double i = starting_Ta; i <= ending_Ta; i += Ta_Variation)
                    {
                        Qab_Result.Add(new Qab_Value
                        {
                            Ta_Value = i,
                            Tb_Value = tbValue.Tb_Result,
                            Mx_Value = mxResult.Mx_Result,
                            Qab_Result = Math.Round(Calculations.Integration(i, tbValue.Tb_Result, CPAd + (mxResult.Mx_Result * CPr)), Parameters.Round_Decimal)
                        });
                    }
                }
            }
            return Qab_Result;
        }
        public static List<Qbc_Value> QbcCalculation(double CPAd, List<Mx_Value> MxResult, double CPr, double starting_Tc, double ending_Tc, double Tc_Variation, List<Tb_Value> Tb_Result, List<Mmin_Value> MminResult, List<H_Value> HResult)
        {
            List<Qbc_Value> Qbc_Result = new List<Qbc_Value>();
            foreach (Mx_Value mxResult in MxResult)
            {
                foreach (Tb_Value tbValue in Tb_Result)
                {
                    foreach (Mmin_Value mminValue in MminResult)
                    {
                        foreach (H_Value hResult in HResult)
                        {
                            for (double i = starting_Tc; i <= ending_Tc; i += Tc_Variation)
                            {
                                Qbc_Result.Add(new Qbc_Value
                                {
                                    Tc_Value = i,
                                    Tb_Value = tbValue.Tb_Result,
                                    Mx_Value = mxResult.Mx_Result,
                                    H_Value = hResult.H_Result,
                                    Mmin_Value = mminValue.Mmin_Result,
                                    Qbc_Result = Calculations.Integration(tbValue.Tb_Result, i, CPAd + mxResult.Mx_Result * CPr) + Calculations.Integration(mminValue.Mmin_Result, mxResult.Mx_Result, hResult.H_Result)
                                });
                            }
                        }
                    }
                }
            }
            return Qbc_Result;
        }
    }
}
