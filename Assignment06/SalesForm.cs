///------------------------------------------------------------------------------------------
///   Project:              Assignment 06 - Sales Bonus
/// 
///   Author:               Mohamad Al-Jaf   
///   
///   Date last modified:   April 03, 2015
///   
///   Program description:  A program that calculates the sales bonus for employees.
///                         
///   Revision History:     2015-04-03: Initial build
///                         2015-04-03: Added the controls to the form
///                         2015-04-03: Completed the buttons code
///                         2015-04-03: Added documentation
///------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment06
{
    public partial class SalesForm : Form
    {
        // CONSTRUCTOR *******************************************
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {

        }

        // Throws an error if the input is greater than 160 or a negative number
        private void TotalHoursWorkedTextBox_Validated(object sender, EventArgs e)
        {
            try
            {
                int hours = Convert.ToInt32(TotalHoursWorkedTextBox.Text);

                if (hours > 160 || hours < 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                TotalHoursWorkedTextBox.Text = "Invalid Input";
            }
        }

        // converts the input to currency or displays an error if it's not a number or less than 0
        private void TotalMonthlySalesTextBox_Validated(object sender, EventArgs e)
        {
            try
            {
                double salesMoney = double.Parse(TotalMonthlySalesTextBox.Text, NumberStyles.Currency);

                if (salesMoney < 0)
                {
                    throw new Exception();
                }

                TotalMonthlySalesTextBox.Text = salesMoney.ToString("C");
            }
            catch (Exception)
            {
                TotalMonthlySalesTextBox.Text = "Invalid Input";
            }
        }

        // clears the textboxes except for total monthly sales
        private void NextButton_Click(object sender, EventArgs e)
        {
            EmployeeNameTextBox.Clear();
            EmployeeIDTextBox.Clear();
            TotalHoursWorkedTextBox.Clear();
            SalesBonusTextBox.Clear();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            
            //printForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview;
            //printForm1.Print();
        }

        //changes the language of the form to english
        private void EnglishRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //labels
            EmployeeNameLabel.Text = "Employee's Name:";
            EmployeeIDLabel.Text = "Employee ID:";
            TotalHoursWorkedLabel.Text = "Hours Worked:";
            TotalMonthlySalesLabel.Text = "Total Sales:";
            SalesBonusLabel.Text = "Sales Bonus:";

            //buttons
            CalculateButton.Text = "Calculate";
            NextButton.Text = "Next";
            PrintButton.Text = "Print";
        }

        // changes the language of the form to french
        private void FrenchRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //labels
            EmployeeNameLabel.Text = "Nom de l'employé:";
            EmployeeIDLabel.Text = "Employee ID:";
            TotalHoursWorkedLabel.Text = "Heures travaillées:";
            TotalMonthlySalesLabel.Text = "Total des ventes:";
            SalesBonusLabel.Text = "Bonus de vente:";

            //buttons
            CalculateButton.Text = "Calculer";
            NextButton.Text = "Au Suivant";
            PrintButton.Text = "Imprimer";
        }

        // calculates the sales bonus only if the input for total hours and total sales is valid
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (TotalHoursWorkedTextBox.Text != "Invalid Input" && TotalMonthlySalesTextBox.Text != "Invalid Input")
            {
                double totalHours = Convert.ToDouble(TotalHoursWorkedTextBox.Text);
                double totalSales = double.Parse(TotalMonthlySalesTextBox.Text, NumberStyles.Currency); //converts currency to double

                totalHours = totalHours/160; // percentage of total hours
                totalSales *= 0.02; // 2% of the sales
                SalesBonusTextBox.Text = String.Format("{0:C}", totalHours*totalSales);
            }
        }
    }
}
