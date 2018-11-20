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
using BL;
using BE;
using System.Collections;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupNannyExpControl.xaml
    /// </summary>
    public partial class GroupNannyExpControl : UserControl
    {
       
        IBL bl;
        public GroupNannyExpControl()
        {
            
            InitializeComponent();
            bl = FactoryBl.getBL();
            for (int i = 0; i < 21; i++)
                comboBox.Items.Add(i);
            

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                listView.ItemsSource = bl.nannyWithExperience((int)comboBox.SelectedItem);

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }
    }
}
