﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Governing_Equations
{
    public partial class MainForm : Form
    {
        Parameters parameters = new Parameters();
        int HValueIndex = 1;
        int MminValueIndex = 1;
        int MxValueIndex = 1;
        int QabValueIndex = 1;
        int QbcValueIndex = 1;
        int TbValueIndex = 1;
        int TdValueIndex = 1;
        int loadAmount = 19;
        public MainForm()
        {
            InitializeComponent();
        }
        private void Calculate()
        {
            Calculations.MxCalculation(parameters.Tsat, parameters.K_value, parameters.n_value, parameters.M0_value, parameters.Ta_Starting, parameters.Ta_Ending, parameters.Ta_Variance);
            Calculations.MminCalculation(parameters.Tsat, parameters.K_value, parameters.n_value, parameters.M0_value, parameters.Tc_Starting, parameters.Tc_Ending, parameters.Tc_Variance);
            Calculations.TbCalculation(parameters.Ta_Starting, parameters.Ta_Ending, parameters.Ta_Variance, parameters.Tevap_Starting, parameters.Tevap_Ending, parameters.Tevap_Variance);
            Calculations.TdCalculation(parameters.Ta_Starting, parameters.Ta_Ending, parameters.Ta_Variance, parameters.Tc_Starting, parameters.Tc_Ending, parameters.Tc_Variance);
            Calculations.HCalculation(parameters.R_Values, parameters.CPAd_Values, parameters.CPr_Values, parameters.Tc_Starting, parameters.Tc_Ending, parameters.Tc_Variance, parameters.Tsat);
            Calculations.QabCalculation(parameters.CPAd_Values, parameters.CPr_Values, parameters.Ta_Starting, parameters.Ta_Ending, parameters.Ta_Variance);
            Calculations.QbcCalculation(parameters.CPAd_Values, parameters.CPr_Values, parameters.Tc_Starting, parameters.Tc_Ending, parameters.Tc_Variance);
        }

        private void load_into_Controls()
        {
            txtCPAdValue.Text = parameters.CPAd_Values.ToString();
            txtCPrValue.Text = parameters.CPr_Values.ToString();
            txtKValue.Text = parameters.K_value.ToString();
            txtM0Value.Text = parameters.M0_value.ToString();
            txtNValue.Text = parameters.n_value.ToString();
            txtRValue.Text = parameters.R_Values.ToString();
            txtTaEndValue.Text = parameters.Ta_Ending.ToString();
            txtTaStartValue.Text = parameters.Ta_Starting.ToString();
            txtTcEndValue.Text = parameters.Tc_Ending.ToString();
            txtTcStartValue.Text = parameters.Tc_Starting.ToString();
            txtTevapEndValue.Text = parameters.Tevap_Ending.ToString();
            txtTevapStartValue.Text = parameters.Tevap_Starting.ToString();
            txtTsatValue.Text = parameters.Tsat.ToString();
            nupFloatRoundValue.Value = Parameters.Round_Decimal;
            nupTaVariationValue.Value = (decimal)parameters.Ta_Variance;
            nupTcVariationValue.Value = (decimal)parameters.Tc_Variance;
            nupTevapVariationValue.Value = (decimal)parameters.Tevap_Variance;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region "Button Animation"
        private void PreviousMouseMove(object sender, MouseEventArgs e)
        {
            ((ToolStripStatusLabel)sender).Image = Properties.Resources.left_arrow_hover;
        }
        private void PreviousMouseDown(object sender, MouseEventArgs e)
        {
            ((ToolStripStatusLabel)sender).Image = Properties.Resources.left_arrow_clicke;
        }
        private void PreviousMouseLeave(object sender, EventArgs e)
        {
            ((ToolStripStatusLabel)sender).Image = Properties.Resources.left_arrow;
        }
        private void PreviousMouseHover(object sender, EventArgs e)
        {
            ((ToolStripStatusLabel)sender).Image = Properties.Resources.left_arrow_hover;
        }
        private void NextMouseLeave(object sender, EventArgs e)
        {
            ((ToolStripStatusLabel)sender).Image = Properties.Resources.right_arrow;
        }
        private void NextMouseMove(object sender, MouseEventArgs e)
        {
            ((ToolStripStatusLabel)sender).Image = Properties.Resources.right_arrow_hover;
        }
        private void NextMouseDown(object sender, MouseEventArgs e)
        {
            ((ToolStripStatusLabel)sender).Image = Properties.Resources.right_arrow_click;
        }
        private void NextMouseHover(object sender, EventArgs e)
        {
            ((ToolStripStatusLabel)sender).Image = Properties.Resources.right_arrow_hover;
        }
        #endregion

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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
        private void TdNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.pickTdValueTableAdapter.Fill(this.databaseDataSet.pickTdValue, TdValueIndex, TdValueIndex + loadAmount);
                TdValueIndex += loadAmount + 1;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TdPrevious_Click(object sender, EventArgs e)
        {
            if (TdValueIndex <= 0)
                return;
            try
            {
                TdValueIndex -= loadAmount + 1;
                this.pickTdValueTableAdapter.Fill(this.databaseDataSet.pickTdValue, TdValueIndex, TdValueIndex + loadAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.pickHValueTableAdapter.Fill(this.databaseDataSet.pickHValue, HValueIndex, HValueIndex + loadAmount);
                HValueIndex += loadAmount + 1;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HPrevious_Click(object sender, EventArgs e)
        {
            if (HValueIndex <= 0)
                return;
            try
            {
                HValueIndex -= loadAmount + 1;
                this.pickHValueTableAdapter.Fill(this.databaseDataSet.pickHValue, HValueIndex, HValueIndex + loadAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QabNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.pickQabValueTableAdapter.Fill(this.databaseDataSet.pickQabValue, QabValueIndex, QabValueIndex + loadAmount);
                QabValueIndex += loadAmount + 1;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QabPrevious_Click(object sender, EventArgs e)
        {
            if (QabValueIndex <= 0)
                return;
            try
            {
                QabValueIndex -= loadAmount + 1;
                this.pickQabValueTableAdapter.Fill(this.databaseDataSet.pickQabValue, QabValueIndex, QabValueIndex + loadAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QbcNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.pickQbcValueTableAdapter.Fill(this.databaseDataSet.pickQbcValue, QbcValueIndex, QbcValueIndex + loadAmount);
                QbcValueIndex += loadAmount + 1;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QbcPrevious_Click(object sender, EventArgs e)
        {
            if (QbcValueIndex <= 0)
                return;
            try
            {
                QbcValueIndex -= loadAmount + 1;
                this.pickQbcValueTableAdapter.Fill(this.databaseDataSet.pickQbcValue, QbcValueIndex, QbcValueIndex + loadAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "A.C-Methonal":
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
                    load_into_Controls();
                    break;
                case "Zeolite-Water":
                    //Zeolite Water                    
                    parameters.Tsat = 288.3;
                    parameters.K_value = 10.21;
                    parameters.n_value = 1.39;
                    parameters.M0_value = 0.284;
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
                    load_into_Controls();
                    break;
                default:
                    break;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppData.DatabaseDataSetTableAdapters.QueriesTableAdapter query = new AppData.DatabaseDataSetTableAdapters.QueriesTableAdapter();
            switch (tabControl1.SelectedTab.Text)
            {
                case "Mx Result":
                    MxRowCountStatus.Text = "Mx Total Rows : " + query.pickMxCount();
                    break;
                case "Mmin Result":
                    MminRowCountStatus.Text = "Mmin Total Rows : " + query.pickMminCount();
                    break;
                case "Tb Result":
                    TbRowCountStatus.Text = "Tb Total Rows : " + query.pickTbCount();
                    break;
                case "Td Result":
                    TdRowCountStatus.Text = "Td Total Rows : " + query.pickTdCount();
                    break;
                case "H Result":
                    HRowCountStatus.Text = "H Total Rows : " + query.pickHCount();
                    break;
                case "Qab Result":
                    QabRowCountStatus.Text = "Qab Total Rows : " + query.pickQabCount();
                    break;
                case "Qbc Result":
                    QbcRowCountStatus.Text = "Qbc Total Rows : " + query.pickQbcCount();
                    break;
                default:
                    break;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            parameters = Parameters.readParameters("settings.xml");
            load_into_Controls();
            MessageBox.Show("Settings are loaded", "Loaded", MessageBoxButtons.OK);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            parameters.CPAd_Values = Convert.ToDouble(txtCPAdValue.Text);
            parameters.CPr_Values = Convert.ToDouble(txtCPrValue.Text);
            parameters.K_value = Convert.ToDouble(txtKValue.Text);
            parameters.M0_value = Convert.ToDouble(txtM0Value.Text);
            parameters.n_value = Convert.ToDouble(txtNValue.Text);
            parameters.R_Values = Convert.ToDouble(txtRValue.Text);
            parameters.Ta_Ending = Convert.ToDouble(txtTaEndValue.Text);
            parameters.Ta_Starting = Convert.ToDouble(txtTaStartValue.Text);
            parameters.Ta_Variance = (double)nupTaVariationValue.Value;
            parameters.Tc_Ending = Convert.ToDouble(txtTcEndValue.Text);
            parameters.Tc_Starting = Convert.ToDouble(txtTcStartValue.Text);
            parameters.Tc_Variance = (double)nupTcVariationValue.Value;
            parameters.Tevap_Ending = Convert.ToDouble(txtTevapEndValue.Text);
            parameters.Tevap_Starting = Convert.ToDouble(txtTevapStartValue.Text);
            parameters.Tevap_Variance = (double)nupTevapVariationValue.Value;
            Parameters.Round_Decimal = (int)nupFloatRoundValue.Value;
            Parameters.writeParameters("settings.xml", parameters);
            MessageBox.Show("Settings are saved", "Saved", MessageBoxButtons.OK);
        }
    }
}
