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

namespace PLWPF
{

    /// <summary>
    /// Interaction logic for DeleteMotherWindow.xaml
    /// </summary>
    public partial class DeleteMotherWindow : Window
    {
        IBL bl;
        Mother mother;
        public DeleteMotherWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBL();
            mother = new Mother();
            idMotherComboBox.ItemsSource = bl.motherList();     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mother = bl.getMother(int.Parse(idMotherComboBox.Text));
                bl.delMother(mother);
                MessageBox.Show(mother.ToString(), "This mother has been deleted:");
                Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }
    }
}
