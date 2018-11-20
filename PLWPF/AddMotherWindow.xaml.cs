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
using Xceed.Wpf.Toolkit;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddMotherWindow.xaml
    /// </summary>
    /// 
    

    public partial class AddMotherWindow : Window
    {
        IBL bl;
        Mother mother;
        public AddMotherWindow()
        {
            InitializeComponent();
            mother = new Mother();
            this.DataContext = mother;
            bl = FactoryBl.getBL();
          
        }

        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTime(mother.Day_of_keep[0], startSundayTime, endSundayTime);
                SetTime(mother.Day_of_keep[1], startMondayTime, endMondayTime);
                SetTime(mother.Day_of_keep[2], startTuesdayTime, endTuesdayTime);
                SetTime(mother.Day_of_keep[3], startWednesdayTime, endWednesdayTime);
                SetTime(mother.Day_of_keep[4], startThursdayTime, endThursdayTime);
                SetTime(mother.Day_of_keep[5], startFridayTime, endFridayTime);

                int id;
                if (idTextBox.Text.Length != 9 || !int.TryParse(idTextBox.Text, out id))
                    throw new Exception("The id must be 9 digits");
                idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                bl.addMother(mother);
                System.Windows.MessageBox.Show(mother.ToString(), "This mother has been added:");
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
