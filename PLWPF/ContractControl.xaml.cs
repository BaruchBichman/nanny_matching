﻿using System;
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
    /// Interaction logic for ContractControl.xaml
    /// </summary>
    public partial class ContractControl : UserControl
    {
        public ContractControl()
        {
            InitializeComponent();
        }

        private void AddNContract_Click(object sender, RoutedEventArgs e)
        {
            AddContractWindow addContractWindow = new AddContractWindow();
            addContractWindow.ShowDialog();
        }

        private void DeleteContract_Click(object sender, RoutedEventArgs e)
        {
            DeleteContractWindow deleteContractWindow = new DeleteContractWindow();
            deleteContractWindow.ShowDialog();
        }

        private void UpdateContract_Click(object sender, RoutedEventArgs e)
        {
            UpdateContractWindow updateContractWindow = new UpdateContractWindow();
            updateContractWindow.ShowDialog();
        }
    }
}
