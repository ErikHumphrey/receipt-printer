/*
______                                   _____  _                      _ 
| ___ \                                 /  ___|| |                    | |
| |_/ / _   _  _ __   __ _   ___  _ __  \ `--. | |_   __ _  _ __    __| |
| ___ \| | | || '__| / _` | / _ \| '__|  `--. \| __| / _` || '_ \  / _` |
| |_/ /| |_| || |   | (_| ||  __/| |    /\__/ /| |_ | (_| || | | || (_| |
\____/  \__,_||_|    \__, | \___||_|    \____/  \__| \__,_||_| |_| \__,_|
                      __/ |                                              
                     |___/                                                        
*/

/* Author: Erik Humphrey
 * Project title: Project 12 - Sandwich Shop
 * Date finished: November 13th
 * Executable name: HumphreyErikSandwichShop.exe
 * Description: Displays receipt of multiple orders/recipes generated from user selection of burger/sandwich ingredients
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Used for document printing
using System.IO;
using System.Drawing.Printing;

namespace HumphreyErikSandwichShop
{
    public partial class frmBurgerStand : Form
    {
        int cdmtCount, meatCount, orderNumber, pepperShakes;

        // Initialize defaults
        string bunChoice = "Plain";
        int cheeseChoice = 0;

        // Array of acknowledgements
        string[] soundsGood = { "Okay", "Sounds good", "Alright", "Got it", "Understood", "Great", };
        int index;

        PrintDocument document = new PrintDocument();
        PrintDialog dialog = new PrintDialog();
        public frmBurgerStand()
        {
            InitializeComponent();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtAllOrders.Text, new Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular), Brushes.Black, 20, 20);
        }

  
        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            dialog.Document = document;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }

        //  + "\r\nThank you for your purchase."


        private void frmBurgerStand_Load(object sender, EventArgs e)
        {
            // The initialize thing didn't work as it normally does, so they're declared above
        }

        private void radBunPlain_CheckedChanged(object sender, EventArgs e)
        {
            bunChoice = radBunPlain.Text; // Set bun choice
            chkToasted.Enabled = true; // Re-enable "Toasted?" if doughnut was selected prior
            // Label if bun is selected after "Toasted?" is checked
            if (chkToasted.Checked)
            {
                // Combine an acknowledgement with a lowercase version of the bun choice
                lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + " bun.";
            }
            else
            {
                lblToastInfo.Text = ""; // Clear label if "Toasted?" is not checked
            }
        }

        private void radBunRye_CheckedChanged(object sender, EventArgs e)
        {
            bunChoice = radBunRye.Text;
            chkToasted.Enabled = true;
            if (chkToasted.Checked)
            {
                lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + ".";
            }
            else
            {
                lblToastInfo.Text = "";
            }
        }

        private void radBunHalloween_CheckedChanged(object sender, EventArgs e)
        {
            bunChoice = radBunHalloween.Text;
            chkToasted.Enabled = true;
            if (chkToasted.Checked)
            {
                lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + "."; // Holidays can be toasted
            }
            else
            {
                lblToastInfo.Text = "";
            }
        }

        private void radBunBread_CheckedChanged(object sender, EventArgs e)
        {
            bunChoice = radBunBread.Text;
            chkToasted.Enabled = true;
            if (chkToasted.Checked)
            {
                bunChoice = radBunBread.Text;
                lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + ".";
            }
            else
            {
                lblToastInfo.Text = "";
            }
        }

        private void radBunDoughnut_CheckedChanged(object sender, EventArgs e)
        {
            bunChoice = radBunDoughnut.Text;
            chkToasted.Enabled = false; // Prevent "Toasted?" from being checked in combination with doughnut bun
            lblToastInfo.Text = "We can't toast " + bunChoice.ToLower() + "s, sorry."; // Change label accordingly
        }

        private void radBunBagel_CheckedChanged(object sender, EventArgs e)
        {
            bunChoice = radBunBagel.Text;
            chkToasted.Enabled = true;
            if (chkToasted.Checked)
            {
                lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + ".";
            }
            else
            {
                lblToastInfo.Text = "";
            }
        }

        private void radBunRice_CheckedChanged(object sender, EventArgs e)
        {
            bunChoice = radBunRiceCake.Text;
            chkToasted.Enabled = true;
            if (chkToasted.Checked)
            {
                lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + ".";
            }
            else
            {
                lblToastInfo.Text = "";
            }
        }

        private void radBunEnglishMuffin_CheckedChanged(object sender, EventArgs e)
        {
            bunChoice = radBunEnglishMuffin.Text;
            chkToasted.Enabled = true;
            if (chkToasted.Checked)
            {
                lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + ".";
            }
            else
            {
                lblToastInfo.Text = "";
            }
        }

        private void chkToasted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToasted.Checked)
            {
                radBunDoughnut.Enabled = false;
                // Label if "Toasted?" is checked after a bun is selected
                if (bunChoice == "Plain")
                { lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + " bun."; }
                else if (bunChoice == "Rye")
                { lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + "."; }
                else if (bunChoice == "Hallowe\'en")
                { lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + "."; }
                else if (bunChoice == "Sliced bread")
                { lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + "."; }
                else if (bunChoice == "Bagel")
                { lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + "."; }
                else if (bunChoice == "Rice cake")
                { lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + "."; }
                else if (bunChoice == "English muffin")
                { lblToastInfo.Text = soundsGood[index++ % soundsGood.Length] + ", we'll toast your " + bunChoice.ToLower() + "."; }
            }
            else
            {
                // Unchecking "Toasted?" allows selection of Doughnut bun again
                radBunDoughnut.Enabled = true;
                lblToastInfo.Text = null;
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Header showing order number followed by bun choice and toasted preference
            orderNumber++;
            txtAllOrders.Text = txtAllOrders.Text + "Order #" + orderNumber + ":\r\n\r\n\t" + bunChoice + " bun";
            if (chkToasted.Checked) { txtAllOrders.Text = txtAllOrders.Text + "\r\n\t └─── Toasted"; }

            // Add cheese to order
            if (cheeseChoice == 1)
            {
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tCheddar cheese";
            }
            if (cheeseChoice == 2)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tMozzarella cheese";
            }
            if (cheeseChoice == 3)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tOka cheese";
            }

            int linesRemoved = 0;

            // Custom parameters for meats
            bool canCombineTofu = false; // Default: false
            int maxMeats = 3; // Default: 3

            // Convert maxMeats from numeric to alphabetic

            string maxMeatsToAlpha;

            if (maxMeats == 0)
            { maxMeatsToAlpha = "NO"; }

            else if (maxMeats == 1)
            { maxMeatsToAlpha = "one"; }

            else if (maxMeats == 2)
            { maxMeatsToAlpha = "two"; }

            else if (maxMeats == 3)
            { maxMeatsToAlpha = "three"; }

            else if (maxMeats == 4)
            { maxMeatsToAlpha = "four"; }

            else if (maxMeats == 5)
            { maxMeatsToAlpha = "five"; }

            else if (maxMeats == 6)
            { maxMeatsToAlpha = "six"; }

            else if (maxMeats == 7)
            { maxMeatsToAlpha = "seven"; }

            else
            {
                maxMeatsToAlpha = "undefined";
                Console.WriteLine("Could not convert maxMeats to alphabetic!"); // Should only happen if configured to be < 0 or > 7
            }

            string holdIt = "Hold it!";
            // Add meats to order
            meatCount = 0;

            if (chkMeatAngus.Checked == true)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tAngus";
            }
            if (chkMeatBacon.Checked == true)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tBacon";
            }
            if (chkMeatBeef.Checked == true)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tBeef";
            }
            if (chkMeatBuffalo.Checked == true)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tBuffalo";
            }
            if (chkMeatChicken.Checked == true)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tChicken";
            }
            if (chkMeatSalmon.Checked == true)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tSalmon";
            }
            if (chkMeatSteak.Checked == true)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tSteak";
            }
            if (chkMeatTofu.Checked == true)
            {
                meatCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tTofu";
                if (canCombineTofu == false && meatCount > 1)
                {
                    MessageBox.Show("We don't mix tofu with other meats here.", holdIt);
                    grpMeat.BackColor = System.Drawing.Color.IndianRed; // WORKS UNPREDICTABLY HERE but just fine on line 
                    while (linesRemoved < meatCount)
                    {
                        txtAllOrders.Text = txtAllOrders.Text.Remove(txtAllOrders.Text.LastIndexOf(Environment.NewLine));
                        linesRemoved++;
                    }
                }
                else
                {
                    grpMeat.BackColor = System.Drawing.SystemColors.Highlight; // Reset the GroupBox colour if tofu is not combined with another meat
                }
            }

            // Print "No Meat" on the order if no meats are checked
            // "No Condiments" is NOT printed if there are no condiments, because I virtually never see a cash register or receipt do that.

            if (meatCount == 0)
            {
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tNo Meat";
            }

            // Warn user they've selected too many meats

            if (meatCount > maxMeats)
            {
                MessageBox.Show("You can only have " + maxMeatsToAlpha + " meats on your burger!", holdIt);
                grpMeat.BackColor = System.Drawing.Color.IndianRed;

                // Remove all meats just printed on the order
                while (linesRemoved < meatCount)
                {
                    txtAllOrders.Text = txtAllOrders.Text.Remove(txtAllOrders.Text.LastIndexOf(Environment.NewLine));
                    linesRemoved++;
                }
            }
            else
            {
                grpMeat.BackColor = System.Drawing.SystemColors.Highlight; // Reset the GroupBox colour if meats do not exceed max
            }

            // Add condiments to order
            cdmtCount = 0;

            if (chkCdmtKetchup.Checked == true)
            {
                cdmtCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tKetchup";
            }
            if (chkCdmtMustard.Checked == true)
            {
                cdmtCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tMustard";
            }
            if (chkCdmtMayonnaise.Checked == true)
            {
                cdmtCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tMayonnaise";
            }
            if (chkCdmtTomatoes.Checked == true)
            {
                cdmtCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tTomatoes";
            }
            if (chkCdmtLettuce.Checked == true)
            {
                cdmtCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tLettuce";
            }
            if (chkCdmtPickles.Checked == true)
            {
                cdmtCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tPickles";
            }
            if (chkCdmtOnions.Checked == true)
            {
                cdmtCount++;
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tOnions";
            }
            if (chkCdmtPepper.Checked == true)
            {
                cdmtCount++;
                if (pepperShakes > 1)
                {
                    txtAllOrders.Text = txtAllOrders.Text + "\r\n\t" + pepperShakes + " shakes of pepper";
                }
                else { txtAllOrders.Text = txtAllOrders.Text + "\r\n\tShake of pepper"; }
            }

            // No Cheese at END of order
            if (cheeseChoice == 0)
            {
                txtAllOrders.Text = txtAllOrders.Text + "\r\n\tNo Cheese";
            }

            // Make space and horizontal divider for the next order
            txtAllOrders.Text = txtAllOrders.Text + "\r\n\r\n━━━━━━━━━━━━━━━━━\r\n";
        }

        // Set cheese choice

        private void radCheeseNone_CheckedChanged(object sender, EventArgs e)
        {
            cheeseChoice = 0;
        }

        private void radCheeseCheddar_CheckedChanged(object sender, EventArgs e)
        {
            cheeseChoice = 1;
        }

        private void radCheeseMozzarella_CheckedChanged(object sender, EventArgs e)
        {
            cheeseChoice = 2;
        }

        private void radCheeseOka_CheckedChanged(object sender, EventArgs e)
        {
            cheeseChoice = 3;
        }

        // Convert pepper shakes NumericUpDown decimal to integer (probably unnecessary)
        // Check Pepper if NUD > 0 and uncheck if NUD is set back to 0

        private void nudPepperShakes_ValueChanged(object sender, EventArgs e)
        {
            pepperShakes = Convert.ToInt32(nudPepperShakes.Value);
            if (pepperShakes > 0)
            {
                chkCdmtPepper.Checked = true;
            }
            else
            {
                chkCdmtPepper.Checked = false;
            }
        }

        // If pepper is checked, the amount of pepper will change to 1, and 0 if unchecked. Also unchecked by ResetAll.

        private void chkCdmtPepper_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCdmtPepper.Checked)
            {
                nudPepperShakes.Value = 1;
            }
            else
            {
                nudPepperShakes.Value = 0;
            }
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            txtAllOrders.Clear();
            // Defaults
            radBunPlain.Checked = true;
            chkToasted.Checked = false;
            chkMeatBeef.Checked = true;
            radCheeseNone.Checked = true;
            // Unchecking everything else
            chkMeatAngus.Checked = false;
            chkMeatBacon.Checked = false;
            chkMeatBuffalo.Checked = false;
            chkMeatChicken.Checked = false;
            chkMeatSalmon.Checked = false;
            chkMeatSteak.Checked = false;
            chkMeatTofu.Checked = false;
            chkCdmtKetchup.Checked = false;
            chkCdmtMustard.Checked = false;
            chkCdmtMayonnaise.Checked = false;
            chkCdmtTomatoes.Checked = false;
            chkCdmtLettuce.Checked = false;
            chkCdmtPickles.Checked = false;
            chkCdmtOnions.Checked = false;
            chkCdmtPepper.Checked = false;
        }

        private void btnDupeOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your credit card has been charged.", "Thank you");
        }

        // Basically verbatim of MSDN PrintDialog class documentation
        /*
        private System.Drawing.Printing.PrintDocument doctoPrint =
                new System.Drawing.Printing.PrintDocument();

        private void actuallyPrintPhysicalReceipt(System.Object sender, System.EventArgs e)
        {
            prtdlgReceipt.Document = doctoPrint;

            DialogResult result = prtdlgReceipt.ShowDialog();

            // If result is OK, print the receipt.

            if (result == DialogResult.OK)
            {
                doctoPrint.Print();
            }
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // The following code will render a simple
            // message on the printed document.
            string text = txtAllOrders.Text + "\r\nThank you for your purchase.";
            System.Drawing.Font printFont = new System.Drawing.Font
                ("Courier New", 9.75F, System.Drawing.FontStyle.Regular);

            // Draw the content.
            e.Graphics.DrawString(text, printFont,
                System.Drawing.Brushes.Black, 10, 10);
        }
         */


    }
}