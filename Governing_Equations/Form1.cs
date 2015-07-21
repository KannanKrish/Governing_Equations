using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Governing_Equations
{
    public partial class Form1 : Form
    {
        Parameters parameters = new Parameters();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save_Values();
            load_Values();
            Test_Function();
        }

        private void load_Values()
        {
            parameters = Parameters.readParameters("settings.xml");
            //MessageBox.Show(parameters.CPAd_Values.ToString());
        }

        private void save_Values()
        {
            //A.C-Methonal            
            parameters.Tsat = 290.9;
            parameters.K_value = 17.19;
            parameters.n_value = 1.66;
            parameters.M0_value = 0.425;
            parameters.Ta_Starting = 20+273;
            parameters.Ta_Ending = 60+273;
            parameters.Ta_Variance = 1;
            parameters.Tc_Starting = 90+273;
            parameters.Tc_Ending = 140+273;
            parameters.Tc_Variance = 1;
            parameters.Tevap_Starting = 0+273;
            parameters.Tevap_Ending = 5+273;
            parameters.Tevap_Variance = 1;
            parameters.CPAd_Values = 0.711;
            parameters.CPr_Values = 2.534;
            parameters.R_Values = 0.287;
            Parameters.writeParameters("settings.xml", parameters);
        }
        private void Test_Function()
        {
            List<Mx_Value> Mx_Result = Calculations.MxCalculation(parameters.Tsat, parameters.K_value, parameters.n_value, parameters.M0_value, parameters.Ta_Starting, parameters.Ta_Ending, parameters.Ta_Variance);
            List<Mmin_Value> Mmin_Result = Calculations.MminCalculation(parameters.Tsat, parameters.K_value, parameters.n_value, parameters.M0_value, parameters.Tc_Starting, parameters.Tc_Ending, parameters.Tc_Variance);
            List<Tb_Value> Tb_Result = Calculations.TbCalculation(parameters.Ta_Starting, parameters.Ta_Ending, parameters.Ta_Variance, parameters.Tevap_Starting, parameters.Tevap_Ending, parameters.Tevap_Variance);
            List<Td_Value> Td_Result = Calculations.TdCalculation(parameters.Ta_Starting, parameters.Ta_Ending, parameters.Ta_Variance, parameters.Tc_Starting, parameters.Tc_Ending, parameters.Tc_Variance, Tb_Result);
            List<H_Value> H_Result = Calculations.HCalculation(parameters.R_Values, parameters.CPAd_Values, Mx_Result, parameters.CPr_Values, parameters.Tc_Starting, parameters.Tc_Ending, parameters.Tc_Variance, parameters.Tsat);
            List<Qab_Value> Qab_Result = Calculations.QabCalculation(parameters.CPAd_Values, Mx_Result, parameters.CPr_Values, parameters.Ta_Starting, parameters.Ta_Ending, parameters.Ta_Variance, Tb_Result);
            List<Qbc_Value> Qbc_Result = Calculations.QbcCalculation(parameters.CPAd_Values, Mx_Result, parameters.CPr_Values, parameters.Tc_Starting, parameters.Tc_Ending, parameters.Tc_Variance, Tb_Result, Mmin_Result, H_Result);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = Mx_Result;
            dataGridView1.Refresh();
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = Mmin_Result;
            dataGridView2.Refresh();
            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.DataSource = Tb_Result;
            dataGridView3.Refresh();
            dataGridView4.AutoGenerateColumns = true;
            dataGridView4.DataSource = Td_Result;
            dataGridView4.Refresh();
            dataGridView5.AutoGenerateColumns = true;
            dataGridView5.DataSource = H_Result;
            dataGridView5.Refresh();
            dataGridView6.AutoGenerateColumns = true;
            dataGridView6.DataSource = Qab_Result;
            dataGridView6.Refresh();
            dataGridView7.AutoGenerateColumns = true;
            dataGridView7.DataSource = Qbc_Result;
            dataGridView7.Refresh();
        }
    }
}
