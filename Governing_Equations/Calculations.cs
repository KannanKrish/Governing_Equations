using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Governing_Equations
{
    public class Calculations
    {
        static ResultDatabaseDataSetTableAdapters.QueriesTableAdapter queries = new ResultDatabaseDataSetTableAdapters.QueriesTableAdapter();

        public static void MxCalculation(double Tsat, double K, double n, double M0, double starting_Ta, double ending_Ta, double variation_Ta)
        {
            for (double i = starting_Ta; i <= ending_Ta; i += variation_Ta)
                queries.InsertMxValue(i, Math.Round(M0 * Math.Exp(-K * Math.Pow(((i / Tsat) - 1), n)), Parameters.Round_Decimal));
        }
        public static void MminCalculation(double Tsat, double K, double n, double M0, double starting_Tc, double ending_Tc, double variation_Tc)
        {
            for (double i = starting_Tc; i <= ending_Tc; i += variation_Tc)
                queries.InsertMminValue(i, Math.Round(M0 * Math.Exp(-K * Math.Pow(((i / Tsat) - 1), n)), Parameters.Round_Decimal));
        }
        public static void TbCalculation(double starting_Ta, double ending_Ta, double variation_Ta, double starting_Tevap, double ending_Tevap, double variation_Tevap)
        {
            for (double i = starting_Ta; i <= ending_Ta; i += variation_Ta)
                for (double j = starting_Tevap; j <= ending_Tevap; j += variation_Tevap)
                    queries.InsertTbValue(i, j, Math.Round((i * i) / j, Parameters.Round_Decimal));
        }
        public static void TdCalculation(double starting_Ta, double ending_Ta, double variation_Ta, double starting_Tc, double ending_Tc, double variation_Tc, List<Tb_Value> Tb_Result)
        {
            for (double i = starting_Ta; i <= ending_Ta; i += variation_Ta)
                foreach (Tb_Value Tb_value in Tb_Result)
                    for (double j = starting_Tc; j <= ending_Tc; j += variation_Tc)
                        queries.InsertTdValue(i, Tb_value.Tb_Result, j, Math.Round((i * Tb_value.Tb_Result) / j, Parameters.Round_Decimal));
        }
        public static void HCalculation(double R, double CPAd, List<Mx_Value> MxResult, double CPr, double starting_Tc, double ending_Tc, double Tc_Variation, double Tsat)
        {
            for (double i = starting_Tc; i <= ending_Tc; i += Tc_Variation)
                foreach (Mx_Value mxResult in MxResult)
                    queries.InsertHValue(i, mxResult.Mx_Result, Math.Round(R * (CPAd + (mxResult.Mx_Result * CPr)) * (i / Tsat), Parameters.Round_Decimal));
        }
        public static double Integration(double lowerLimit, double upperLimit, double innerValue)
        {
            return (innerValue * upperLimit) - (innerValue * lowerLimit);
        }
        public static void QabCalculation(double CPAd, List<Mx_Value> MxResult, double CPr, double starting_Ta, double ending_Ta, double Ta_Variation, List<Tb_Value> Tb_Result)
        {
            foreach (Mx_Value mxResult in MxResult)
                foreach (Tb_Value tbValue in Tb_Result)
                    for (double i = starting_Ta; i <= ending_Ta; i += Ta_Variation)
                        queries.InsertQabValue(i, tbValue.Tb_Result, mxResult.Mx_Result, Math.Round(Calculations.Integration(i, tbValue.Tb_Result, CPAd + (mxResult.Mx_Result * CPr)), Parameters.Round_Decimal));
        }
        public static void QbcCalculation(double CPAd, List<Mx_Value> MxResult, double CPr, double starting_Tc, double ending_Tc, double Tc_Variation, List<Tb_Value> Tb_Result, List<Mmin_Value> MminResult, List<H_Value> HResult)
        {
            for (double i = starting_Tc; i <= ending_Tc; i += Tc_Variation)
                foreach (Tb_Value tbValue in Tb_Result)
                    foreach (Mx_Value mxResult in MxResult)
                        foreach (Mmin_Value mminValue in MminResult)
                            foreach (H_Value hResult in HResult)
                                queries.InsertQbcValue(i, tbValue.Tb_Result, mxResult.Mx_Result, hResult.H_Result, mminValue.Mmin_Result, Math.Round(Calculations.Integration(tbValue.Tb_Result, i, CPAd + mxResult.Mx_Result * CPr) + Calculations.Integration(mminValue.Mmin_Result, mxResult.Mx_Result, hResult.H_Result), Parameters.Round_Decimal));

        }
    }
}
