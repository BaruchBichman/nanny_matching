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
    /// Interaction logic for SalaryNanny.xaml
    /// </summary>
    public partial class SalaryNanny : Window
    {
        IBL bl;
        Nanny nanny = new Nanny();
        public SalaryNanny()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();
            idNannyComboBox.ItemsSource = bl.nannyList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nanny = bl.getNanny(int.Parse(idNannyComboBox.Text));
                double salary = bl.salaryNanny(nanny.Id);
                SalaryTextBox.Content = nanny.FirstName+" "+nanny.FamilyName+"\n" + "Salary: " +salary.ToString();
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
