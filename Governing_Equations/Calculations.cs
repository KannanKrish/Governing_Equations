using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Governing_Equations
{
    public class Calculations
    {
        static AppData.DatabaseDataSetTableAdapters.QueriesTableAdapter query = new AppData.DatabaseDataSetTableAdapters.QueriesTableAdapter();
        public static double Integration(double lowerLimit, double upperLimit, double innerValue)
        {
            return (innerValue * upperLimit) - (innerValue * lowerLimit);
        }
        public static void MxCalculation(double Tsat, double K, double n, double M0, double starting_Ta, double ending_Ta, double variation_Ta)
        {
            for (double i = starting_Ta; i <= ending_Ta; i += variation_Ta)
                query.InsertMxValue(i, Math.Round(M0 * Math.Exp(-K * Math.Pow(((i / Tsat) - 1), n)), Parameters.Round_Decimal));
        }
        public static void MminCalculation(double Tsat, double K, double n, double M0, double starting_Tc, double ending_Tc, double variation_Tc)
        {
            for (double i = starting_Tc; i <= ending_Tc; i += variation_Tc)
                query.InsertMminValue(i, Math.Round(M0 * Math.Exp(-K * Math.Pow(((i / Tsat) - 1), n)), Parameters.Round_Decimal));
        }
        public static void TbCalculation(double starting_Ta, double ending_Ta, double variation_Ta, double starting_Tevap, double ending_Tevap, double variation_Tevap)
        {
            for (double i = starting_Ta; i <= ending_Ta; i += variation_Ta)
                for (double j = starting_Tevap; j <= ending_Tevap; j += variation_Tevap)
                    query.InsertTbValue(i, j, Math.Round((i * i) / j, Parameters.Round_Decimal));
        }        
        public static void TdCalculation(double starting_Ta, double ending_Ta, double variation_Ta, double starting_Tc, double ending_Tc, double variation_Tc)
        {
            AppData.DatabaseDataSetTableAdapters.pickTbResultTableAdapter Tb_Result = new AppData.DatabaseDataSetTableAdapters.pickTbResultTableAdapter();
            for (double i = starting_Ta; i <= ending_Ta; i += variation_Ta)
                foreach (DataRow Tb_value in Tb_Result.GetData().Rows)
                    for (double j = starting_Tc; j <= ending_Tc; j += variation_Tc)
                        query.InsertTdValue(i, Convert.ToDouble(Tb_value.ItemArray[0]), j, Math.Round((i * Convert.ToDouble(Tb_value.ItemArray[0])) / j, Parameters.Round_Decimal));
        }
        public static void HCalculation(double R, double CPAd, double CPr, double starting_Tc, double ending_Tc, double Tc_Variation, double Tsat)
        {
            AppData.DatabaseDataSetTableAdapters.pickMxResultTableAdapter Mx_Result = new AppData.DatabaseDataSetTableAdapters.pickMxResultTableAdapter();
            for (double i = starting_Tc; i <= ending_Tc; i += Tc_Variation)
                foreach (DataRow mxResult in Mx_Result.GetData().Rows)
                    query.InsertHValue(i, Convert.ToDouble(mxResult.ItemArray[0]), Math.Round(R * (CPAd + (Convert.ToDouble(mxResult.ItemArray[0]) * CPr)) * (i / Tsat), Parameters.Round_Decimal));
        }
        public static void QabCalculation(double CPAd, double CPr, double starting_Ta, double ending_Ta, double Ta_Variation)
        {
            AppData.DatabaseDataSetTableAdapters.pickMxResultTableAdapter Mx_Result = new AppData.DatabaseDataSetTableAdapters.pickMxResultTableAdapter();
            AppData.DatabaseDataSetTableAdapters.pickTbResultTableAdapter Tb_Result = new AppData.DatabaseDataSetTableAdapters.pickTbResultTableAdapter();
            foreach (DataRow mxResult in Mx_Result.GetData().Rows)
                foreach (DataRow tbValue in Tb_Result.GetData().Rows)
                    for (double i = starting_Ta; i <= ending_Ta; i += Ta_Variation)
                        query.InsertQabValue(i, Convert.ToDouble(tbValue.ItemArray[0]), Convert.ToDouble(mxResult.ItemArray[0]), Math.Round(Calculations.Integration(i, Convert.ToDouble(tbValue.ItemArray[0]), CPAd + (Convert.ToDouble(mxResult.ItemArray[0]) * CPr)), Parameters.Round_Decimal));
        }
        public static void QbcCalculation(double CPAd, double CPr, double starting_Tc, double ending_Tc, double Tc_Variation)
        {
            AppData.DatabaseDataSetTableAdapters.pickMxResultTableAdapter Mx_Result = new AppData.DatabaseDataSetTableAdapters.pickMxResultTableAdapter();
            AppData.DatabaseDataSetTableAdapters.pickTbResultTableAdapter Tb_Result = new AppData.DatabaseDataSetTableAdapters.pickTbResultTableAdapter();
            AppData.DatabaseDataSetTableAdapters.pickMminResultTableAdapter Mmin_Result = new AppData.DatabaseDataSetTableAdapters.pickMminResultTableAdapter();
            AppData.DatabaseDataSetTableAdapters.pickHResultTableAdapter H_Result = new AppData.DatabaseDataSetTableAdapters.pickHResultTableAdapter();
            for (double i = starting_Tc; i <= ending_Tc; i += Tc_Variation)
                foreach (DataRow tbValue in Tb_Result.GetData().Rows)
                    foreach (DataRow mxResult in Mx_Result.GetData().Rows)
                        foreach (DataRow mminValue in Mmin_Result.GetData().Rows)
                            foreach (DataRow hResult in H_Result.GetData().Rows)
                                query.InsertQbcValue(i, Convert.ToDouble(tbValue.ItemArray[0]), Convert.ToDouble(mxResult.ItemArray[0]), Convert.ToDouble(hResult.ItemArray[0]), Convert.ToDouble(mminValue.ItemArray[0]), Math.Round(Calculations.Integration(Convert.ToDouble(tbValue.ItemArray[0]), i, CPAd + Convert.ToDouble(mxResult.ItemArray[0]) * CPr) + Calculations.Integration(Convert.ToDouble(mminValue.ItemArray[0]), Convert.ToDouble(mxResult.ItemArray[0]), Convert.ToDouble(hResult.ItemArray[0])), Parameters.Round_Decimal));

        }
    }
}
