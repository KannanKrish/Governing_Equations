using System.IO;
using System.Xml.Serialization;

namespace Governing_Equations
{
    public class Parameters
    {
        [XmlIgnore]
        public static int Round_Decimal = 4;
        public double Tsat { get; set; }
        public double K_value { get; set; }
        public double n_value { get; set; }
        public double M0_value { get; set; }
        public double Ta_Starting { get; set; }
        public double Ta_Ending { get; set; }
        public double Ta_Variance { get; set; }
        public double Tc_Starting { get; set; }
        public double Tc_Ending { get; set; }
        public double Tc_Variance { get; set; }
        public double Tevap_Starting { get; set; }
        public double Tevap_Ending { get; set; }
        public double Tevap_Variance { get; set; }
        public double CPAd_Values { get; set; }
        public double CPr_Values { get; set; }
        public double R_Values { get; set; }
        public static Parameters readParameters(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Parameters));
            Parameters parameters = (Parameters)xmlSerializer.Deserialize(streamReader);
            streamReader.Close();
            return parameters;
        }
        public static void writeParameters(string filePath, Parameters parameters)
        {
            StreamWriter streamWriter = new StreamWriter(filePath);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Parameters));
            xmlSerializer.Serialize(streamWriter, parameters);
            streamWriter.Close();
        }
    }
    public class Mx_Value
    {
        public long ID { get; set; }
        public double Ta_Value { get; set; }
        public double Mx_Result { get; set; }
    }
    public class Mmin_Value
    {
        public long ID { get; set; }
        public double Tc_Value { get; set; }
        public double Mmin_Result { get; set; }
    }
    public class Tb_Value
    {
        public long ID { get; set; }
        public double Ta_Value { get; set; }
        public double Tevap_Value { get; set; }
        public double Tb_Result { get; set; }
    }
    public class Td_Value
    {
        public long ID { get; set; }
        public double Ta_Value { get; set; }
        public double Tb_Value { get; set; }
        public double Tc_Value { get; set; }
        public double Td_Result { get; set; }
    }
    public class H_Value
    {
        public long ID { get; set; }
        public double Tc_Value { get; set; }
        public double Mx_Value { get; set; }
        public double H_Result { get; set; }
    }
    public class Qab_Value
    {
        public long ID { get; set; }
        public double Ta_Value { get; set; }
        public double Tb_Value { get; set; }
        public double Mx_Value { get; set; }
        public double Qab_Result { get; set; }
    }
    public class Qbc_Value
    {
        public long ID { get; set; }
        public double Tb_Value { get; set; }
        public double Tc_Value { get; set; }
        public double Mx_Value { get; set; }
        public double Mmin_Value { get; set; }
        public double H_Value { get; set; }
        public double Qbc_Result { get; set; }
    }
}