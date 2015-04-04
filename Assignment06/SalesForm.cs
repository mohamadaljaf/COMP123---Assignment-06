using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void TotalMonthlySalesTextBox_Validated(object sender, EventArgs e)
        {
            try
            {
                double salesMoney = Convert.ToDouble(TotalMonthlySalesTextBox.Text);

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
    }
}
