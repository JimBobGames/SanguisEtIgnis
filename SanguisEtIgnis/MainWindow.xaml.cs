using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using SanguisEtIgnis.Core.Data;
using SanguisEtIgnis.Core.Network;
using SanguisEtIgnis.UI;

namespace SanguisEtIgnis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static StandaloneSanguisEtIgnisGame game;
        private System.Threading.Timer backgroundTimer;
        static readonly object _locker = new object();
        private static MapVisualHost mapVisualHost;
        private Controller controller;
        private static DateTime lastBackgroundUpdate = DateTime.Now;
        private static UIChanges changes = new UIChanges();

        public MainWindow()
        {
            InitializeComponent();

            // create the game
            game = new StandaloneSanguisEtIgnisGame();
            AmericanCivilWarGameCreator.CreateGame(game);
            controller = new Controller() { Game = game };


            // the visual host
            mapVisualHost = new MapVisualHost(game, controller);
            this.MainWindowCanvas.Children.Add(mapVisualHost);
            this.MainWindowCanvas.InvalidateVisual();


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += timer_Tick;
            timer.Start();

            /*
            //MapCanvas.MouseEnter += new MouseEventHandler(canvas_MouseEnter);
            MapCanvas.MouseWheel += new MouseWheelEventHandler(Canvas_MouseWheel);
            // MapCanvas.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(OnMouseLeftButtonDown);

            this.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(OnMouseRightButtonUp);
            this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(OnMouseLeftButtonUp);
            this.SizeChanged += OnWindowSizeChanged;
            */

            lastBackgroundUpdate = DateTime.Now;
            var autoEvent = new AutoResetEvent(false);
            backgroundTimer = new System.Threading.Timer(BackgroundUpdate, autoEvent, 1000, 100);
        }

        private static void BackgroundUpdate(Object stateInfo)
        {
            lock (_locker)
            {
                try
                {

                    AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
                    var currentTime = DateTime.Now;
                    lastBackgroundUpdate = DateTime.Now;
                    var timeDelta = currentTime - lastBackgroundUpdate;
                    double totalMS = timeDelta.TotalMilliseconds;

#pragma warning disable CA1416 // Validate platform compatibility
                    game.UpdateGameStates(changes, totalMS);
#pragma warning restore CA1416 // Validate platform compatibility

                    // mapVisualHost.Refresh();
                }
                catch (Exception ex)
                {

                }
                finally
                {

                }
            }


        }



        /// <summary>
        /// The dispatched timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            lock (_locker)
            {
                try
                {
                    // textBlock.Text = lastBackgroundUpdate.ToLongTimeString();

                    mapVisualHost.UpdateGameVisualsWithChangeList(changes);
                    changes = new UIChanges();
                    UpdateSelectionDisplay();
                    //mapVisualHost.UpdateGameVisuals();

                    //this.MapCanvas.InvalidateVisual();
                    //this.MapCanvas.UpdateLayout();

                    //mapVisualHost.Refresh();
                }
                catch (Exception ex)
                {

                }
                finally
                {

                }



            }
        }


        private void UpdateSelectionDisplay()
        {
            if (game.SelectedBattalion == null)
            {
                //this.SelectedDetailCanvas.Visibility = Visibility.Hidden;
            }
            else
            {
                // this.SelectedDetailCanvas.Visibility = Visibility.Visible;
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
