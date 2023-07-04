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

namespace SanguisEtIgnis
{
    /// <summary>
    /// Interaction logic for TabbedWindow.xaml
    /// </summary>
    public partial class TabbedWindow : Window
    {
        public TabbedWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tcSample.SelectedIndex - 1;
            if (newIndex < 0)
                newIndex = tcSample.Items.Count - 1;
            tcSample.SelectedIndex = newIndex;
        }
    }
}
