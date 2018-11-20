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
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        IBL bl;
        Contract contract;

        public AddContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
            this.DataContext = contract;
            bl = FactoryBl.getBL();
            id_NannyComboBox.ItemsSource = bl.nannyList();
            idChildComboBox.ItemsSource = bl.childrenList();    
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime d1=DateTime.Parse(startDateDatePicker.Text.ToString());
                DateTime d2 = DateTime.Parse(endDateDatePicker.Text.ToString());
                if (d2.Subtract(d1).TotalDays < 30)
                    throw new Exception("The contract must be at least for a month");
                bl.addContract(contract);
                MessageBox.Show(bl.contractsList().LastOrDefault().ToString(), "This contract has been added:");
                Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
            
        }

        private void payment_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.addContract(contract);
                MessageBox.Show(bl.salary(bl.contractsList().LastOrDefault()).ToString(),"סך הכל עלות:");
                bl.delContract(bl.contractsList().LastOrDefault(),true);
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }
    }
}
