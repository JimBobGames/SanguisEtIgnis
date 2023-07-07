using SanguisEtIgnis.Core.Network;
using SanguisEtIgnis.UI;
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
        public static StandaloneSanguisEtIgnisGame game;
        private Controller controller;

        public TabbedWindow()
        {
            InitializeComponent();

            // create the game
            game = new StandaloneSanguisEtIgnisGame();
            TinyGameCreator.CreateGame(game);
            controller = new Controller() { Game = game };

            // set the bindings
           this.NationsTab.NationsListView.ItemsSource = game.NationsListAlphabetical;
           this.SolarSystemsTab.SolarSystemsListView.ItemsSource = game.SolarSystemsListAlphabetical;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.NationsTab.DataContext = game.NationsListAlphabetical;
        }

        private void btnTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = MainTabControl.SelectedIndex - 1;
            if (newIndex < 0)
                newIndex = MainTabControl.Items.Count - 1;
            MainTabControl.SelectedIndex = newIndex;
        }
    }
}
