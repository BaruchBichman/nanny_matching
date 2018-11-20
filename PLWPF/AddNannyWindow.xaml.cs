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
using Xceed.Wpf.Toolkit;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddNannyWindow.xaml
    /// </summary>
    public partial class AddNannyWindow : Window
    {
        Nanny nanny;
        IBL bl;

        public AddNannyWindow()
        {
            InitializeComponent();
            nanny = new Nanny();
            this.DataContext = nanny;
            bl = FactoryBl.getBL();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTime(nanny.Week_of_work[0], startSundayTime, endSundayTime);
                SetTime(nanny.Week_of_work[1], startMondayTime, endMondayTime);
                SetTime(nanny.Week_of_work[2], startTuesdayTime, endTuesdayTime);
                SetTime(nanny.Week_of_work[3], startWednesdayTime, endWednesdayTime);
                SetTime(nanny.Week_of_work[4], startThursdayTime, endThursdayTime);
                SetTime(nanny.Week_of_work[5], startFridayTime, endFridayTime);
                int id;
                if (idTextBox.Text.Length != 9 || !int.TryParse(idTextBox.Text.ToString(), out id))
                    throw new Exception("The id must be 9 digits");
                idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                bl.addNanny(nanny);
                System.Windows.MessageBox.Show(bl.nannyList().LastOrDefault().ToString());
                Close();
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message);
            }
        }

        private void SetTime(DayOfWork ts, TimePicker tp1, TimePicker tp2)
        {
            if (tp1.Value != null && tp2.Value != null)
            {
                ts.start = tp1.Value.Value.TimeOfDay;
                ts.end = tp2.Value.Value.TimeOfDay;
            }
        }

        private void idTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            int id;
            if (idTextBox.Text.Length != 9 || !int.TryParse(idTextBox.Text, out id))
            {
                idTextBox.FontSize = 12;
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
