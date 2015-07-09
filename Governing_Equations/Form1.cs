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
            double[] result=Calculations.MxCalculation(290.9, 17.19, 1.66, 0.425, 20, 30,1);
            for (int i = 0; i < result.Length; i++)
            {
                MessageBox.Show(result[i].ToString());
            }
        }
    }
}
