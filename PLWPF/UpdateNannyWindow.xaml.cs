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
using Xceed.Wpf.Toolkit;
using BL;
using BE;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateNannyWindow.xaml
    /// </summary>
    public partial class UpdateNannyWindow : Window
    {
        Nanny selectedNanny;
        IBL bl;
        public UpdateNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();
            idNannyComboBox.ItemsSource = bl.nannyList();

        }

        private void idNannyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedNanny = idNannyComboBox.SelectedItem as Nanny;

        }

        private void firstUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            idNannyComboBox.IsEnabled = false;
            firstUpdateButton.Visibility = Visibility.Hidden;
            grid1.DataContext = selectedNanny;
            firstPicture.Visibility = Visibility.Hidden;
            grid1.Visibility = Visibility.Visible;
            thirdPicture.Visibility = Visibility.Visible;
            UpdateNannyButton.Visibility = Visibility.Visible;
            SetTime(selectedNanny.Week_of_work[0], startSundayTime, endSundayTime);
            SetTime(selectedNanny.Week_of_work[1], startMondayTime, endMondayTime);
            SetTime(selectedNanny.Week_of_work[2], startTuesdayTime, endTuesdayTime);
            SetTime(selectedNanny.Week_of_work[3], startWednesdayTime, endWednesdayTime);
            SetTime(selectedNanny.Week_of_work[4], startThursdayTime, endThursdayTime);
            SetTime(selectedNanny.Week_of_work[5], startFridayTime, endFridayTime);
        }
        private void SetTime(DayOfWork ts, TimePicker tp1, TimePicker tp2)
        {
            if (ts.start != null && ts.end != null)
            {
                tp1.Value = DateTime.Parse(ts.start.ToString());
                tp2.Value = DateTime.Parse(ts.end.ToString());
            }
        }

        private void UpdateNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTimeBack(selectedNanny.Week_of_work[0], startSundayTime, endSundayTime);
                SetTimeBack(selectedNanny.Week_of_work[1], startMondayTime, endMondayTime);
                SetTimeBack(selectedNanny.Week_of_work[2], startTuesdayTime, endTuesdayTime);
                SetTimeBack(selectedNanny.Week_of_work[3], startWednesdayTime, endWednesdayTime);
                SetTimeBack(selectedNanny.Week_of_work[4], startThursdayTime, endThursdayTime);
                SetTimeBack(selectedNanny.Week_of_work[5], startFridayTime, endFridayTime);

                addressTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                expYearsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                familyNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                firstNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                floorTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                maxAgeMonthTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                maxChildrenTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                minAgeMonthTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                recommendationsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                salPerHourTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                salPerMonthTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                elevatorCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                isSalPerHourCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                isTamatCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();

                dobDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();


                sundayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                mondayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                tuesdayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                wednesdayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                thursdayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                fridayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();

                bl.updateNanny(selectedNanny);
                System.Windows.MessageBox.Show(selectedNanny.ToString(), "This nanny has been updated");
                Close();
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message);
            }

        }

        private void SetTimeBack(DayOfWork ts, TimePicker tp1, TimePicker tp2)
        {
            if (tp1.Value != null && tp2.Value != null)
            {
                ts.start = tp1.Value.Value.TimeOfDay;
                ts.end = tp2.Value.Value.TimeOfDay;
            }
        }

    }
}
