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
    /// Interaction logic for NannyControl.xaml
    /// </summary>
    public partial class NannyControl : UserControl
    {
        public NannyControl()
        {
            InitializeComponent();
        }

        private void AddNanny_Click(object sender, RoutedEventArgs e)
        {
            AddNannyWindow addNannyWindow = new AddNannyWindow();
            addNannyWindow.ShowDialog();
        }

        private void DeleteNanny_Click(object sender, RoutedEventArgs e)
        {
            DeleteNannyWindow deleteNannyWindow = new DeleteNannyWindow();
            deleteNannyWindow.ShowDialog();

        }

        private void UpdateNanny_Click(object sender, RoutedEventArgs e)
        {
            UpdateNannyWindow updateNannyWindow = new UpdateNannyWindow();
            updateNannyWindow.ShowDialog();
        }

        private void Salary_Click(object sender, RoutedEventArgs e)
        {
            SalaryNanny salaryNanny = new SalaryNanny();
            salaryNanny.ShowDialog();
        }
    }
}
