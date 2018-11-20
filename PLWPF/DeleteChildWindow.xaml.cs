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
    /// Interaction logic for DeleteChildWindow.xaml
    /// </summary>
    public partial class DeleteChildWindow : Window
    {
        IBL bl;
        Child child;

        public DeleteChildWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();
            child = new Child();
            idChildComboBox.ItemsSource = bl.childrenList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                child = bl.getChild(int.Parse(idChildComboBox.Text));

                var result = MessageBox.Show(child.ToString(), "Are you sure you want to remove this child?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bl.delChild(child);
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
