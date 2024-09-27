using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

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
        int orderNumber = 1;
        double taxRate = 0.13;
        int titleCount = 1;
        //global sound players
        SoundPlayer print = new SoundPlayer(Properties.Resources.printSound);

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
                //convert variables
                toadFeetQuantity = Convert.ToInt16(toadFeetInput.Text);
                octopusEyelidQuantity = Convert.ToInt16(octopusEyelidsInput.Text);
                fairyTearQuantity = Convert.ToInt16(fairyTearsInput.Text);

                //calculate output
                subtotal = (toadFeetQuantity * toadFeetPrice) + (octopusEyelidQuantity * octopusEyelidPrice) + (fairyTearQuantity * fairyTearPrice);
                tax = (subtotal * taxRate);
                total = (subtotal + tax);

                //display values
                subtotalOutput.Text = $"{subtotal.ToString("C")}";
                taxOutput.Text = $"{tax.ToString("C")}";
                totalOutput.Text = $"{total.ToString("C")}";
            }
            catch //in case of invalid input
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
                //convert variables
                tendered = Convert.ToDouble(tenderedInput.Text);

                
                //in case input is not enough
                if (tendered < total) 
                {
                    changeOutput.Text = "ERROR";
                }
                else
                {
                    //calculate output
                    change = (tendered - total);
                    changeOutput.Text = $"{change.ToString("C")}";
                    recieptButton.Enabled = true;
                }
                
            }
            catch //in case of invalid input
            {
                changeOutput.Text = "ERROR";
            }
        }

        private void recieptButton_Click(object sender, EventArgs e)
        {
            //receipt printing
            print.Play();
            recieptLabel.Text = $"\n        SORCERER STORE\n------------------------------";
            Thread.Sleep(750);
            Refresh();
            recieptLabel.Text += $"\n Order       #{orderNumber}";
            Thread.Sleep(750);
            Refresh();
            print.Play();
            recieptLabel.Text += $"\n September 26, 2024";
            Thread.Sleep(750);
            Refresh();
            recieptLabel.Text += $"\n\n\nToad Feet x{toadFeetQuantity}          @ {(toadFeetQuantity * toadFeetPrice).ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            print.Play();
            recieptLabel.Text += $"\nOctopus Eyelids x{octopusEyelidQuantity}    @ {(octopusEyelidQuantity * octopusEyelidPrice).ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            recieptLabel.Text += $"\nFairy Tears x{fairyTearQuantity}        @ {(fairyTearQuantity * fairyTearPrice).ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            print.Play();
            recieptLabel.Text += $"\n\n\nSubtotal                {subtotal.ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            recieptLabel.Text += $"\nTax                     {tax.ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            print.Play();
            recieptLabel.Text += $"\nTotal                   {total.ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            recieptLabel.Text += $"\n\n\nTendered                {tendered.ToString("C")}"; 
            Thread.Sleep(750);
            Refresh();
            print.Play();
            recieptLabel.Text += $"\nChange                  {change.ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            recieptLabel.Text += "\n\n\n THANK YOU FOR YOUR PATRONAGE";
            newOrderButton.Enabled = true;
        }
            //to prevent calculation before values are entered
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

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            //reset all buttons, textboxes, and outputs
          
            toadFeetInput.Text = "";
            octopusEyelidsInput.Text = "";
            fairyTearsInput.Text = "";
            subtotalOutput.Text = "0";
            taxOutput.Text = "0";
            totalOutput.Text = "0";
            tenderedInput.Text = "";
            changeOutput.Text = "0";
            recieptLabel.Text = "";
            orderNumber++;

            totalButton.Enabled = false;
            changeButton.Enabled = false;
            recieptButton.Enabled = false;
            newOrderButton.Enabled = false;

        }

        private void titleLabel_Click(object sender, EventArgs e)
        {
            //easter egg
            titleCount++;
            if (titleCount == 1)
            {
                titleLabel.Text = "Sorcerer Store";
            }
            else if (titleCount == 2)
            {
                titleLabel.Text = "Wizard Walmart";
            }
            else if (titleCount == 3)
            {
                titleLabel.Text = "Mage Market";
                titleCount = 0;
            }

        }
    }
}
            