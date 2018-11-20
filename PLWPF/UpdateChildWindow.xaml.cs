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
    /// Interaction logic for UpdateChildWindow.xaml
    /// </summary>
    public partial class UpdateChildWindow : Window
    {
        IBL bl;
        public Child selectedChild;
        public UpdateChildWindow()
        {
            
            InitializeComponent();
            bl = FactoryBl.getBL();
            idChildComboBox.ItemsSource = bl.childrenList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            update.Visibility = Visibility.Visible;
            update.DataContext = selectedChild;
            idChildComboBox.IsEnabled = false;
        }

        private void idChildComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedChild = idChildComboBox.SelectedItem as Child;
        }
    }
}
