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
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for FindNannyWindow.xaml
    /// </summary>
    public partial class FindNannyWindow : Window
    {
        IBL bl;
        Mother selectedMother;
        Child selectedChild;
        Nanny selectedNanny;
        Contract contract;
        bool flexible = false;
        int distance = 50;
        bool byCar = false;
        int minYears;
        int maxFloor = 50;
        bool elevator = false;
        bool tamat = false;

        public FindNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();
            MotherIdComboBox.ItemsSource = bl.motherList();
            for (int i = 0; i < 51; i++)
            {
                DistanceComboBox.Items.Add(i);
                YearsOfExpComboBox.Items.Add(i);
            }
            for(int i=50;i!=-1;i--)
                MaxFloorComboBox.Items.Add(i);
            contract = new Contract();
        }

        private void SelectChild_Click(object sender, RoutedEventArgs e)
        {
            selectedChild = ChildIdComboBox.SelectedItem as Child;
            SelectChild.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Visible;
            ChildIdComboBox.IsEnabled = false;
            FindNanny.Visibility = Visibility.Visible;
        }

        private void SelectMother_Click(object sender, RoutedEventArgs e)
        {
            SelectMother.Visibility = Visibility.Hidden;
            textBlock1.Visibility = Visibility.Visible;
            ChildIdComboBox.ItemsSource = bl.childrenList(item => item.MotherId == selectedMother.Id);
            MotherIdComboBox.IsEnabled = false;
            ChildIdComboBox.Visibility = Visibility.Visible;
            grid2.Visibility = Visibility.Visible;
        }

        private void MotherIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedMother = MotherIdComboBox.SelectedItem as Mother;
                List<Child> children = bl.childrenList(int.Parse(selectedMother.Id.ToString()));
                if(children.Count==0)
                    throw new Exception("This mother doesn't have children");
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }

        private void SelectNanny_Click(object sender, RoutedEventArgs e)
        {
            contract.IdChild = selectedChild.Id;
            contract.Id_Nanny = selectedNanny.Id;
            contract.Sal_Per_Hour = selectedNanny.SalPerHour;
            contract.Sal_Per_Month = selectedNanny.SalPerMonth;
            contract.IsSigned = true;
            SelectNanny.Visibility = Visibility.Hidden;
            contractGrid.DataContext = contract;
            contractGrid.Visibility = Visibility.Visible;

        }

        private void FindNanny_Click(object sender, RoutedEventArgs e)
        {
            Waiting.Visibility = Visibility.Visible;
            flexible = (bool)flexibleTimeCheckBox.IsChecked;
            distance = int.Parse(DistanceComboBox.SelectedItem.ToString());
            byCar = (bool)byCarCheckBox.IsChecked;
            minYears = int.Parse(YearsOfExpComboBox.SelectedItem.ToString());
            maxFloor = int.Parse(MaxFloorComboBox.SelectedItem.ToString());
            elevator = (bool)elevatorCheckBox.IsChecked;
            tamat = (bool)tamatCheckBox.IsChecked;
            foundNanniesDataGrid.Visibility = Visibility.Visible;
            image1.Visibility = Visibility.Hidden;
            SelectNanny.Visibility = Visibility.Visible;
            FindNanny.Visibility = Visibility.Hidden;
            List<Nanny> found = new List<Nanny>();
            new Thread(() =>
            {
                try
                {
                    found = bl.findNanny(selectedMother, flexible, distance, byCar, minYears, maxFloor, elevator, tamat);
                }
                catch (Exception m)
                {
                    MessageBox.Show(m.Message);
                }
                Dispatcher.Invoke(new Action(() =>
                {
                    try
                    {
                        foundNanniesDataGrid.ItemsSource = found;
                        Waiting.Visibility = Visibility.Hidden;
                    }
                    catch (Exception n)
                    {
                        MessageBox.Show(n.Message);
                    }
                }));
            }).Start();

        }

       

        private void foundNanniesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedNanny = foundNanniesDataGrid.SelectedItem as Nanny;
        }

        private void payment_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.addContract(contract);
                MessageBox.Show(bl.salary(bl.contractsList().LastOrDefault()).ToString(), "סך הכל עלות:");
                bl.delContract(bl.contractsList().LastOrDefault(), true);
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime d1 = DateTime.Parse(startDateDatePicker.Text.ToString());
                DateTime d2 = DateTime.Parse(endDateDatePicker.Text.ToString());
                if (d2.Subtract(d1).TotalDays < 30)
                    throw new Exception("The contract must be at least for a month");
                bl.addContract(contract);
                MessageBox.Show(bl.contractsList().LastOrDefault().ToString(), "This contract has been added:");
                Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }
    }
}
