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
    /// Interaction logic for UpdateMotherWindow.xaml
    /// </summary>
    public partial class UpdateMotherWindow : Window
    {
        Mother selectedMother;
        IBL bl;


        public UpdateMotherWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();
            idMotherComboBox.ItemsSource = bl.motherList();
        }

        private void SetTimeBack(DayOfWork ts, TimePicker tp1, TimePicker tp2)
        {
            if (tp1.Value != null && tp2.Value != null)
            {
                ts.start = tp1.Value.Value.TimeOfDay;
                ts.end = tp2.Value.Value.TimeOfDay;
            }
        }


        private void UpdateMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTimeBack(selectedMother.Day_of_keep[0], startSundayTime, endSundayTime);
                SetTimeBack(selectedMother.Day_of_keep[1], startMondayTime, endMondayTime);
                SetTimeBack(selectedMother.Day_of_keep[2], startTuesdayTime, endTuesdayTime);
                SetTimeBack(selectedMother.Day_of_keep[3], startWednesdayTime, endWednesdayTime);
                SetTimeBack(selectedMother.Day_of_keep[4], startThursdayTime, endThursdayTime);
                SetTimeBack(selectedMother.Day_of_keep[5], startFridayTime, endFridayTime);


                familyNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                firstNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                motherAddressTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                remarksTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                phoneTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                researchAddressTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                sundayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                mondayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                tuesdayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                wednesdayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                thursdayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                fridayCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();

                bl.updateMother(selectedMother);
                System.Windows.MessageBox.Show(selectedMother.ToString(), "This mother has been updated");
                Close();
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            idMotherComboBox.IsEnabled = false;
            firstUpdateButton.Visibility = Visibility.Hidden;
            grid1.DataContext = selectedMother;
            firstPicture.Visibility = Visibility.Hidden;
            grid1.Visibility = Visibility.Visible;
            SecondPicture.Visibility = Visibility.Visible;
            thirdPicture.Visibility = Visibility.Visible;
            UpdateMotherButton.Visibility = Visibility.Visible;
            SetTime(selectedMother.Day_of_keep[0], startSundayTime, endSundayTime);
            SetTime(selectedMother.Day_of_keep[1], startMondayTime, endMondayTime);
            SetTime(selectedMother.Day_of_keep[2], startTuesdayTime, endTuesdayTime);
            SetTime(selectedMother.Day_of_keep[3], startWednesdayTime, endWednesdayTime);
            SetTime(selectedMother.Day_of_keep[4], startThursdayTime, endThursdayTime);
            SetTime(selectedMother.Day_of_keep[5], startFridayTime, endFridayTime);
        }

        private void idMotherComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMother = idMotherComboBox.SelectedItem as Mother;
        }

        private void SetTime(DayOfWork ts, TimePicker tp1, TimePicker tp2)
        {
            if (ts.start != null && ts.end != null)
            {
                tp1.Value =DateTime.Parse(ts.start.ToString());
                tp2.Value = DateTime.Parse(ts.end.ToString());
            }
        }
    }
}
