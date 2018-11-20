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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ChildControl.xaml
    /// </summary>
    public partial class ChildControl : UserControl
    {
        public ChildControl()
        {
            InitializeComponent();
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            AddChildWindow addChildWindow = new AddChildWindow();
            addChildWindow.ShowDialog();

        }

        private void DeleteChild_Click(object sender, RoutedEventArgs e)
        {
            DeleteChildWindow deleteChildWindow = new DeleteChildWindow();
            deleteChildWindow.ShowDialog();
        }

        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            UpdateChildWindow updateChildWindow = new UpdateChildWindow();
            updateChildWindow.ShowDialog();
        }
    }
}
