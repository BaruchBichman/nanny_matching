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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();           
        }

        private void SetVisibiltyHidden()
        {
            nanny.Visibility = Visibility.Hidden;
            mother.Visibility = Visibility.Hidden;
            child.Visibility = Visibility.Hidden;
            contract.Visibility = Visibility.Hidden;
            //image.Visibility = Visibility.Hidden;
        }

        private void Mother_Click(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
            mother.Visibility = Visibility.Visible;
            //MotherWindow motherWindow = new MotherWindow();
            //this.Hide();
            //motherWindow.ShowDialog();
        }

        

        private void Nanny_Click(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
            nanny.Visibility = Visibility.Visible;
            //NannyWindow nannyWindow = new NannyWindow();
            //this.Hide();
            //nannyWindow.ShowDialog();

        }
    
        private void Contract_Click(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
            contract.Visibility = Visibility.Visible;
            //ContractWindow contractWindow = new ContractWindow();
            //this.Hide();
            //contractWindow.ShowDialog();
        }
        private void Child_Click(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
            child.Visibility = Visibility.Visible;
            //ChildWindow childWindow = new ChildWindow();
            //this.Hide();
            //childWindow.ShowDialog();
        }

        private void image_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void GroupingButton_Click(object sender, RoutedEventArgs e)
        {
            GroupWindow groupWindow = new GroupWindow();
            groupWindow.ShowDialog();
        }
    }
}
