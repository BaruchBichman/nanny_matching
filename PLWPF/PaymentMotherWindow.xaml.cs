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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PaymentMotherWindow.xaml
    /// </summary>
    public partial class PaymentMotherWindow : Window
    {
        IBL bl;
        Mother mother = new Mother();

        public PaymentMotherWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();
            idComboBox.ItemsSource = bl.motherList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mother = bl.getMother(int.Parse(idComboBox.Text));
                double payment = bl.payMother(mother.Id);
                SalaryTextBox.Content = mother.FirstName + " " + mother.FamilyName + "\n" + "Total Payment: "+ payment.ToString();
                this.image.Visibility = Visibility.Hidden;
                close.Visibility = Visibility.Visible;
                this.SalaryTextBox.Visibility = Visibility.Visible;

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
