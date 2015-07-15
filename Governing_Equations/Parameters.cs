using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

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
        public static double CPAd_Values { get; set; }
        public static double CPr_Values { get; set; }
        public static double R_Values { get; set; }
        public static Parameters readParameters(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Parameters));
            Parameters parameters = (Parameters)xmlSerializer.Deserialize(new StreamReader(filePath));
            return parameters;
        }
        public static void writeParameters(string filePath,Parameters parameters)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Parameters));
            xmlSerializer.Serialize(new StreamWriter(filePath),parameters);
        }
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
    public class H_Value
    {
        public double Tc_Value { get; set; }
        public double Tsat_Value { get; set; }
        public double Mx_Value { get; set; }
        public double H_Result { get; set; }
    }
    public class Qab_Value
    {
        public double Ta_Value { get; set; }
        public double Tb_Value { get; set; }
        public double Mx_Value { get; set; }
        public double Qab_Result { get; set; }
    }
    public class Qbc_Value
    {
        public double Tb_Value { get; set; }
        public double Tc_Value { get; set; }
        public double Mx_Value { get; set; }
        public double Mmin_Value { get; set; }
        public double H_Value { get; set; }
        public double Qbc_Result { get; set; }
    }
}
