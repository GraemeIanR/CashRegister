using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashRegister
{
    public partial class Form1 : Form
    {
        //global variables
        double subtotal;
        double total;
        double tax;
        double toadFeetPrice = 3.25;
        double octopusEyelidPrice = 5.00;
        double fairyTearPrice = 8.50;
        int toadFeetQuantity = 0;
        int octopusEyelidQuantity = 0;
        int fairyTearQuantity = 0;
        double tendered;
        double change;

        public Form1()
        {
            InitializeComponent();
        }

        private void subtotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void totalButton_Click(object sender, EventArgs e)
        {
            try
            {
                //define variables
                toadFeetQuantity = Convert.ToInt16(toadFeetInput.Text);
                octopusEyelidQuantity = Convert.ToInt16(octopusEyelidsInput.Text);
                fairyTearQuantity = Convert.ToInt16(fairyTearsInput.Text);

                //calculate variables
                subtotal = (toadFeetQuantity * toadFeetPrice) + (octopusEyelidQuantity * octopusEyelidPrice) + (fairyTearQuantity * fairyTearPrice);
                tax = (subtotal * 0.13);
                total = (subtotal + tax);

                //display values
                subtotalOutput.Text = $"{subtotal.ToString("C")}";
                taxOutput.Text = $"{tax.ToString("C")}";
                totalOutput.Text = $"{total.ToString("C")}";
            }
            catch
            {
                subtotalOutput.Text = "ERROR";
                taxOutput.Text = "ERROR";
                totalOutput.Text = "ERROR";
            }



        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                //define variables
                tendered = Convert.ToDouble(tenderedInput.Text);

                change = (tendered - total);
                changeOutput.Text = $"{change.ToString("C")}";
                recieptButton.Enabled = true;

                //if (tendered < total);
                {
                    //changeOutput.Text = "ERROR";
                }
        
            }
            catch
            {
                changeOutput.Text = "ERROR";
            }
        }

        private void recieptButton_Click(object sender, EventArgs e)
        {
            recieptLabel.Text = $"\nRECIEPT\n";

            
        }

        private void tenderedInput_TextChanged(object sender, EventArgs e)
        {
            changeButton.Enabled = true;
        }

        private void toadFeetInput_TextChanged(object sender, EventArgs e)
        {
            totalButton.Enabled = true;
        }

        private void octopusEyelidsInput_TextChanged(object sender, EventArgs e)
        {
            totalButton.Enabled = true;
        }

        private void fairyTearsInput_TextChanged(object sender, EventArgs e)
        {
            totalButton.Enabled = true;
        }
    }
}
            