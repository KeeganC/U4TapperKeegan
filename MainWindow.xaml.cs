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

namespace U4TapperKeegan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Media.MediaPlayer mediaPlayer = new MediaPlayer();

            //play music
            mediaPlayer.Open(new Uri("ragTimeMusic.mp3", UriKind.Relative));
            mediaPlayer.Play();

            //ragtime music: http://freemusicarchive.org/music/Scott_Joplin/Frog_Legs_Ragtime_Era_Favorites/Scott_Joplin_-_08_-_Pine_Apple_Rag_1908_piano_roll

            //start timer

            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000/60);
            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            this.Title = counter.ToString();
        }
    }
}
