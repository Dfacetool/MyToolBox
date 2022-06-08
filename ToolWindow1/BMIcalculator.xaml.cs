using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using ToolBox;

namespace ToolWindow1
{
    /// <summary>
    /// Interaction logic for BMIcalculator.xaml
    /// </summary>
    public partial class BMIcalculator : Window
    {
        BMI a;
        public BMIcalculator()
        {
            InitializeComponent();
            a = new BMI();
            DataContext = a;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (NumberTextBox.Text != "") 
            {
                a.High = int.Parse(NumberTextBox.Text);
            }
            
        }

        private void NumberTextBox2_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (NumberTextBox2.Text != "") 
            {
                a.Weigh = int.Parse(NumberTextBox2.Text);
            }               
        }
    }
}