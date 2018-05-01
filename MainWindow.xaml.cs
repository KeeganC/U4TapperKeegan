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
using Tapper;

namespace U4TapperKeegan
{
    enum GameState{SplashScreen, GameOn, GameOver}

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //global variables
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        int counter = 0;
        System.Windows.Media.MediaPlayer mediaPlayer = new MediaPlayer();
        Background background;
        GameState gameState;
        int lives = 0;
        int level = 0;
        Player player;

        public MainWindow()
        {
            InitializeComponent();

            //play music
            mediaPlayer.Open(new Uri("ragTimeMusic.mp3", UriKind.Relative));
            //NIU mediaPlayer.Play();

            //ragtime music: http://freemusicarchive.org/music/Scott_Joplin/Frog_Legs_Ragtime_Era_Favorites/Scott_Joplin_-_08_-_Pine_Apple_Rag_1908_piano_roll

            //start timer

            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000/60);
            gameTimer.Start();

            //add background
            background = new Tapper.Background(myCanvas, this);

            //set gamestate
            gameState = GameState.SplashScreen;
        }

        private void setupGame()
        {
            lives = 3;
            level = 0;
            gameState = GameState.GameOn;
            player = new Player(myCanvas, this);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == GameState.SplashScreen)
            {
                this.Title = "SplashScreen";
                if (Keyboard.IsKeyDown(Key.Enter))
                {
                    setupGame();
                }
            }
            else if (gameState == GameState.GameOn)
            {
                this.Title = "GameOn";

            }
            else if (gameState == GameState.GameOver)
            {
                this.Title = "GameOver";

            }
        }
    }
}
