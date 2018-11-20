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
    /// Interaction logic for DeleteNannyWindow.xaml
    /// </summary>
    public partial class DeleteNannyWindow : Window
    {
        
        IBL bl;
        Nanny nanny = new Nanny();
        public DeleteNannyWindow()
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

                var result = MessageBox.Show(nanny.ToString(), "Are you sure you want to remove this nanny?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bl.delNanny(nanny);
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
