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
    /// Interaction logic for MotherControl.xaml
    /// </summary>
    public partial class MotherControl : UserControl
    {
        public MotherControl()
        {
            InitializeComponent();
        }

        private void AddMother_Click(object sender, RoutedEventArgs e)
        {
            AddMotherWindow addMotherWindow = new AddMotherWindow();
            addMotherWindow.ShowDialog();

        }

        private void DeleteMother_Click(object sender, RoutedEventArgs e)
        {
            DeleteMotherWindow deleteMotherWindow = new DeleteMotherWindow();
            deleteMotherWindow.ShowDialog();
        }

        private void UpdateMother_Click(object sender, RoutedEventArgs e)
        {
            UpdateMotherWindow updateMotherWindow = new UpdateMotherWindow();
            updateMotherWindow.ShowDialog();
        }


        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            PaymentMotherWindow paymentMotherWindow = new PaymentMotherWindow();
            paymentMotherWindow.ShowDialog();
        }

        private void FindNanny_Click(object sender, RoutedEventArgs e)
        {
            FindNannyWindow findNannyWindow = new FindNannyWindow();
            findNannyWindow.Show();
        }
    }
}
