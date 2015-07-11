using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Governing_Equations
{
    public class Parameters
    {
        public static int Round_Decimal = 4;
        public static double Tsat { get; set; }
        public static double K_value { get; set; }
        public static double n_value { get; set; }
        public static double M0_value { get; set; }
        public static double Ta_Starting { get; set; }
        public static double Ta_Ending { get; set; }
        public static double Ta_Variance { get; set; }
        public static double Tc_Starting { get; set; }
        public static double Tc_Ending { get; set; }
        public static double Tc_Variance { get; set; }
        public static double Tb_Values { get; set; }
        public static double Td_Values { get; set; }
        public static double H_Values { get; set; }
        public static double CPAd_Values { get; set; }
        public static double CPr_Values { get; set; }
        public static double R_Values { get; set; }
        public static double Qab_Values { get; set; }
        public static double Qbc_Values { get; set; }
    }
    public class Mmin_Value
    {
        public double Tc_Value { get; set; }
        public double Mmin_Result { get; set; }
    }
    public class Mx_Value
    {
        public double Ta_Value { get; set; }
        public double Mx_Result { get; set; }
    }
    public class Tb_Value
    {
        public double Ta_Value { get; set; }
        public double Tevap_Value { get; set; }
        public double Tb_Result { get; set; }
    }
    public class Td_Value
    {
        public double Ta_Value { get; set; }
        public double Tb_Value { get; set; }
        public double Tc_Value { get; set; }
        public double Td_Result { get; set; }
    }
}
