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
    /// Interaction logic for AddChildWindow.xaml
    /// </summary>
    public partial class AddChildWindow : Window
    {
        Child child;
        IBL bl;
        public AddChildWindow()
        {
            InitializeComponent();
            child = new Child();
            this.DataContext = child;
            bl = FactoryBl.getBL();
            motherIdComboBox.ItemsSource = bl.motherList();
        }
       
        private void AddChildButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                if (idTextBox.Text.Length != 9 || !int.TryParse(idTextBox.Text.ToString(), out id))
                    throw new Exception("The id must be 9 digits");
                idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                bl.addChild(child);
                MessageBox.Show(bl.childrenList().LastOrDefault().ToString(), "This child has been added:");
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void idTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            int id;
            if (idTextBox.Text.Length != 9||!int.TryParse(idTextBox.Text, out id))
            {
                idTextBox.FontSize =12;
                idTextBox.Text = "The id must be 9 digits";
            }

        }

        private void idTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            idTextBox.Text = null;
            idTextBox.FontSize = 16;
        }
    }
}
