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
    /// Interaction logic for DeleteContractWindow.xaml
    /// </summary>
    public partial class DeleteContractWindow : Window
    {
        IBL bl;
        Contract contract;
        public DeleteContractWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();
            contractNumberComboBox.ItemsSource = bl.contractsList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contract = bl.getContract(int.Parse(contractNumberComboBox.Text));
                var result= MessageBox.Show(contract.ToString(), "Are you sure you want to remove this contract?", MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bl.delContract(contract, false);
                    Close();
                }
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
           
        }
    }
}
