using NumericPrecisionLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeric_Precision
{
    public partial class Demonstration : Form
    {
        NumericPrecision numPrecision = new NumericPrecision();

        public Demonstration()
        {
            InitializeComponent();
        }

        private void btnMainCalculate_Click(object sender, EventArgs e)
        {
            string result = "";

            switch(cboMainOperator.Text)
            {
                case "Addition":
                    result = numPrecision.Addition(txtMainInput1.Text, txtMainInput2.Text);
                    break;
                case "Subtraction":
                    result = numPrecision.Subtraction(txtMainInput1.Text, txtMainInput2.Text);
                    break;
                case "Multiplication":
                    break;
                case "Division":
                    break;
                default:
                    break;
            }

            ConsoleWriteLine(result);
        }

        private void ConsoleWriteLine(string text)
        {
            txtMainDisplay.Text += text + "\n";
        }
    }
}
