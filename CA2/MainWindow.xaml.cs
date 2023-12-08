/* S00233718
 * Date: 3/12/2023
 * Desc: CA2
 * GitHub Repo: https://github.com/lyra-school/CA2
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Team> _teams = new List<Team>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
            teamList.ItemsSource = _teams;
        }

        private void GetData()
        {
            Team t1 = new Team() { Name = "France" };
            Team t2 = new Team() { Name = "Italy" };
            Team t3 = new Team() { Name = "Spain" };

            _teams.Add(t1);
            _teams.Add(t2);
            _teams.Add(t3);

            //French players
            Player p1 = new Player() { Name = "Marie", ResultRecord = "WWDDL" };
            Player p2 = new Player() { Name = "Claude", ResultRecord = "DDDLW" };
            Player p3 = new Player() { Name = "Antoine", ResultRecord = "LWDLW" };

            t1.AddPlayer(p1);
            t1.AddPlayer(p2);
            t1.AddPlayer(p3);

            //Italian players
            Player p4 = new Player() { Name = "Marco", ResultRecord = "WWDLL" };
            Player p5 = new Player() { Name = "Giovanni", ResultRecord = "LLLLD" };
            Player p6 = new Player() { Name = "Valentina", ResultRecord = "DLWWW" };

            t2.AddPlayer(p4);
            t2.AddPlayer(p5);
            t2.AddPlayer(p6);

            //Spanish players
            Player p7 = new Player() { Name = "Maria", ResultRecord = "WWWWW" };
            Player p8 = new Player() { Name = "Jose", ResultRecord = "LLLLL" };
            Player p9 = new Player() { Name = "Pablo", ResultRecord = "DDDDD" };

            t3.AddPlayer(p7);
            t3.AddPlayer(p8);
            t3.AddPlayer(p9);
        }

        private void teamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(teamList.SelectedItem == null)
            {
                return;
            }
            Team t = (Team)teamList.SelectedItem;
            playerList.ItemsSource = t.Players;
        }

        private void win_Click(object sender, RoutedEventArgs e)
        {
            if(playerList.SelectedItem == null)
            {
                return;
            }

            Player pl = (Player)playerList.SelectedItem;
            pl.UpdateRecord('W');
            
            playerList.ItemsSource = null;

            teamList.ItemsSource = null;
            teamList.ItemsSource = _teams;

            _teams.Sort();
        }

        private void loss_Click(object sender, RoutedEventArgs e)
        {
            if (playerList.SelectedItem == null)
            {
                return;
            }

            Player pl = (Player)playerList.SelectedItem;
            pl.UpdateRecord('L');

            playerList.ItemsSource = null;

            teamList.ItemsSource = null;
            teamList.ItemsSource = _teams;

            _teams.Sort();
        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {
            if (playerList.SelectedItem == null)
            {
                return;
            }

            Player pl = (Player)playerList.SelectedItem;
            pl.UpdateRecord('D');

            playerList.ItemsSource = null;

            teamList.ItemsSource = null;
            teamList.ItemsSource = _teams;

            _teams.Sort();
        }

        private void playerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(playerList.SelectedItem == null)
            {
                ImageUpdater(0);
                return;
            }

            Player pl = (Player)playerList.SelectedItem;
            ImageUpdater(pl.ResultScore);
        }

        private void ImageUpdater(int score)
        {
            if(score == 0)
            {
                star1.Source = new BitmapImage(new Uri("Images/staroutline.png", UriKind.Relative));
                star2.Source = new BitmapImage(new Uri("Images/staroutline.png", UriKind.Relative));
                star3.Source = new BitmapImage(new Uri("Images/staroutline.png", UriKind.Relative));
            } else if(score >= 1 && score <= 5)
            {
                star1.Source = new BitmapImage(new Uri("Images/starsolid.png", UriKind.Relative));
                star2.Source = new BitmapImage(new Uri("Images/staroutline.png", UriKind.Relative));
                star3.Source = new BitmapImage(new Uri("Images/staroutline.png", UriKind.Relative));
            } else if(score >= 6 && score <= 10)
            {
                star1.Source = new BitmapImage(new Uri("Images/starsolid.png", UriKind.Relative));
                star2.Source = new BitmapImage(new Uri("Images/starsolid.png", UriKind.Relative));
                star3.Source = new BitmapImage(new Uri("Images/staroutline.png", UriKind.Relative));
            } else
            {
                star1.Source = new BitmapImage(new Uri("Images/starsolid.png", UriKind.Relative));
                star2.Source = new BitmapImage(new Uri("Images/starsolid.png", UriKind.Relative));
                star3.Source = new BitmapImage(new Uri("Images/starsolid.png", UriKind.Relative));
            }
        }
    }
}
