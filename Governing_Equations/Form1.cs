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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Test_Function();
            MessageBox.Show(Calculations.Integration(4, 6, 28).ToString());
        }
        private void Test_Function()
        {
            List<Mx_Value> Mx_Result = Calculations.MxCalculation(290.9, 17.19, 1.66, 0.425, 20, 30, 1);
            List<Mmin_Value> Mmin_Result = Calculations.MminCalculation(290.9, 17.19, 1.66, 0.425, 90, 140, 1);
            List<Tb_Value> Tb_Result = Calculations.TbCalculation(20, 30, 1, 1, 5, 1);
            List<Td_Value> Td_Result = Calculations.TdCalculation(20, 21, 1, 90, 91, 1, Tb_Result);
            List<H_Value> H_Result = Calculations.HCalculation(0.287, 0.711, Mx_Result, 2.534, 20, 30, 1, 1, 5, 1);
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
        }
    }
}
