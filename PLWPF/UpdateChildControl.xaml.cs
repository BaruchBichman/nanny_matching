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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateChildControl.xaml
    /// </summary>
    public partial class UpdateChildControl : UserControl
    {
        IBL bl;
        //Child child;
        public UpdateChildControl()
        {
            
            InitializeComponent();
            bl = FactoryBl.getBL();
        }

        private void UpdateChildButton_Click(object sender, RoutedEventArgs e)
        {

            dobChildDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            firstNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            isSpecialNeedsCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            motherIdTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            specialNeedsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            bl.updateChild(this.DataContext as Child);
            MessageBox.Show(DataContext.ToString(), "This child has been updated");
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
