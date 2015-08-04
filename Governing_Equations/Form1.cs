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
        int HValueIndex = 1;
        int MminValueIndex = 1;
        int MxValueIndex = 1;
        int QabValueIndex = 1;
        int QbcValueIndex = 1;
        int TbValueIndex = 1;
        int TdValueIndex = 1;
        int loadAmount = 4;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save_Values();            
            //Test_Function();
            load_Values();
            TestQueries();
        }

        private void TestQueries()
        {
            Calculations.MxCalculation(parameters.Tsat, parameters.K_value, parameters.n_value, parameters.M0_value, parameters.Ta_Starting, parameters.Ta_Ending, parameters.Ta_Variance);
            Calculations.MminCalculation(parameters.Tsat, parameters.K_value, parameters.n_value, parameters.M0_value, parameters.Tc_Starting, parameters.Tc_Ending, parameters.Tc_Variance);                        
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
            parameters.Ta_Starting = 20 + 273;
            parameters.Ta_Ending = 60 + 273;
            parameters.Ta_Variance = 1;
            parameters.Tc_Starting = 90 + 273;
            parameters.Tc_Ending = 140 + 273;
            parameters.Tc_Variance = 1;
            parameters.Tevap_Starting = 0 + 273;
            parameters.Tevap_Ending = 5 + 273;
            parameters.Tevap_Variance = 1;
            parameters.CPAd_Values = 0.711;
            parameters.CPr_Values = 2.534;
            parameters.R_Values = 0.287;
            Parameters.writeParameters("settings.xml", parameters);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region "Next and Back Button Activity"
        private void MxNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.pickMxValueTableAdapter.Fill(this.databaseDataSet.pickMxValue, MxValueIndex, MxValueIndex + loadAmount);
                MxValueIndex += loadAmount + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MxPrevious_Click(object sender, EventArgs e)
        {
            if (MxValueIndex <= 0)
                return;
            try
            {
                MxValueIndex -= loadAmount + 1;
                this.pickMxValueTableAdapter.Fill(this.databaseDataSet.pickMxValue, MxValueIndex, MxValueIndex + loadAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MminNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.pickMminValueTableAdapter.Fill(this.databaseDataSet.pickMminValue, MminValueIndex, MminValueIndex + loadAmount);
                MminValueIndex += loadAmount + 1;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void MminPrevious_Click(object sender, EventArgs e)
        {
            if (MminValueIndex <= 0)
                return;
            try
            {
                MminValueIndex -= loadAmount + 1;
                this.pickMminValueTableAdapter.Fill(this.databaseDataSet.pickMminValue, MminValueIndex, MminValueIndex + loadAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TbNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.pickTbValueTableAdapter.Fill(this.databaseDataSet.pickTbValue, TbValueIndex, TbValueIndex + loadAmount);
                TbValueIndex += loadAmount + 1;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void TbPrevious_Click(object sender, EventArgs e)
        {
            if (TbValueIndex <= 0)
                return;
            try
            {
                TbValueIndex -= loadAmount + 1;
                this.pickTbValueTableAdapter.Fill(this.databaseDataSet.pickTbValue, TbValueIndex, TbValueIndex + loadAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}
