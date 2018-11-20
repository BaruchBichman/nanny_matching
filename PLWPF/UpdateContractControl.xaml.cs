using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateContractControl.xaml
    /// </summary>
    public partial class UpdateContractControl : UserControl
    {
        IBL bl;
        Contract contract;
        public UpdateContractControl()
        { 
            InitializeComponent();
            bl = FactoryBl.getBL();
            contract = new Contract();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                contract =this.DataContext as Contract;
                endDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
                id_NannyTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                idChildTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                isPerMonthCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                isSignedCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                sal_Per_HourTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                sal_Per_MonthTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                startDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
                theyknowCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();

                bl.updateContract(contract);
                MessageBox.Show(contract.ToString(), "This contract has been updated:");
                var myWindow = Window.GetWindow(this);
                myWindow.Close();

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }
    }
}
