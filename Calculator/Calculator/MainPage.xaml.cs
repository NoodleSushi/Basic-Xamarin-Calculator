using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private CalculatorProcessor calc = new CalculatorProcessor();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnDigitClicked(object sender, EventArgs e)
        {
            calc.InputNumber(int.Parse((sender as Button).ClassId));
            UpdateDisplay();
        }

        private void OnDelClicked(object sender, EventArgs e)
        {
            calc.Delete();
            UpdateDisplay();
        }

        private void OnDecClicked(object sender, EventArgs e)
        {
            calc.ToggleDecimal();
            UpdateDisplay();
        }

        private void OnOpClicked(object sender, EventArgs e)
        {
            calc.InputOperation((CalculatorProcessor.Operation) Enum.Parse(typeof(CalculatorProcessor.Operation), (sender as Button).ClassId));
            UpdateDisplay();
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            calc.Clear();
            UpdateDisplay();
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            calc.Evaluate();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            CalcLabel.Text = calc.GetDisplay();
        }
    }
}
