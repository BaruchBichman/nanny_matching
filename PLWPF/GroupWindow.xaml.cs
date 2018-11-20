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
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        IBL bl;


        public GroupWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();
        }

        private void ContractByDistanceButton_Click(object sender, RoutedEventArgs e)
        {
            GroupDistanceControl uc = new GroupDistanceControl();
            image.Visibility = Visibility.Visible;
           
            
            new Thread(() =>
            {
                var source = bl.GroupedContract(true).ToList();
                Dispatcher.Invoke(new Action(() =>
                {
                    try
                    {
                        uc.listView.ItemsSource = source;
                        this.page.Content = uc;
                       image.Visibility = Visibility.Collapsed;
                    }
                    catch (Exception n)
                    {
                        MessageBox.Show(n.Message);
                    }
                }));
            }).Start();

        }

        private void NannyWithExpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GroupNannyExpControl uc = new GroupNannyExpControl();
                //uc.Source = bl.nannyList();
                page.Content = uc;
      
  
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
           
        }

        private void ChildrenByAgeMinButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                GroupMinAgeControl uc = new GroupMinAgeControl();
                uc.Source = bl.groupedNannies(true);
                this.page.Content = uc;

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }

        private void ChildrenByAgeMaxButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                GroupMaxAge uc = new GroupMaxAge();
                uc.Source = bl.groupedNannies(false,true);
                this.page.Content = uc;


            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }

        private void ChildrenWithoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChildWithoutNannyControl uc = new ChildWithoutNannyControl();
                uc.Source = bl.noNanniesFound();
                this.page.Content = uc;

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }

        private void ChildrenWithSpecButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpecialNeedsControl uc = new SpecialNeedsControl();
                uc.Source = bl.childSpecialNeeds();
                this.page.Content = uc;
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }

    }
}
