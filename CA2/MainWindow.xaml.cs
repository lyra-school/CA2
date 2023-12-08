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
        // holds a list of teams
        private List<Team> _teams = new List<Team>();
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads in the default data for teams and their respective players; assigns the first listbox's source to the teams list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
            teamList.ItemsSource = _teams;
        }

        /// <summary>
        /// Method with data provided by the questions. Creates teams, adds them to the teams list, creates players, adds them to the respective team
        /// </summary>
        private void GetData()
        {
            // Creates teams, adds them to teams list
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

            // Adds to French team
            t1.AddPlayer(p1);
            t1.AddPlayer(p2);
            t1.AddPlayer(p3);

            //Italian players
            Player p4 = new Player() { Name = "Marco", ResultRecord = "WWDLL" };
            Player p5 = new Player() { Name = "Giovanni", ResultRecord = "LLLLD" };
            Player p6 = new Player() { Name = "Valentina", ResultRecord = "DLWWW" };

            // Adds to Italian team
            t2.AddPlayer(p4);
            t2.AddPlayer(p5);
            t2.AddPlayer(p6);

            //Spanish players
            Player p7 = new Player() { Name = "Maria", ResultRecord = "WWWWW" };
            Player p8 = new Player() { Name = "Jose", ResultRecord = "LLLLL" };
            Player p9 = new Player() { Name = "Pablo", ResultRecord = "DDDDD" };

            // Adds to Spanish team
            t3.AddPlayer(p7);
            t3.AddPlayer(p8);
            t3.AddPlayer(p9);
        }

        /// <summary>
        /// Methods that reacts to teamList updates and changes playerList's source according to the team picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If none selected, default to doing nothing
            if(teamList.SelectedItem == null)
            {
                return;
            }

            // Players displayed belong to the team selected
            Team t = (Team)teamList.SelectedItem;
            playerList.ItemsSource = t.Players;
        }

        /// <summary>
        /// Updates a player's record with a win when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void win_Click(object sender, RoutedEventArgs e)
        {
            // If none selected, default to doing nothing
            if(playerList.SelectedItem == null)
            {
                return;
            }

            // Gets the selected player, calls UpdateRecord() with appropriate char
            Player pl = (Player)playerList.SelectedItem;
            pl.UpdateRecord('W');
            
            // Refreshes player list but does not reassign the source back; this is necessary because this function deselects the team 
            playerList.ItemsSource = null;

            // Refreshes team list
            teamList.ItemsSource = null;
            teamList.ItemsSource = _teams;

            // Sort all teams because points are updated
            _teams.Sort();
        }

        /// <summary>
        /// Updates a player's record with a loss when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loss_Click(object sender, RoutedEventArgs e)
        {
            // If none selected, default to doing nothing
            if (playerList.SelectedItem == null)
            {
                return;
            }

            // Gets the selected player, calls UpdateRecord() with appropriate char
            Player pl = (Player)playerList.SelectedItem;
            pl.UpdateRecord('L');

            // Refreshes player list but does not reassign the source back; this is necessary because this function deselects the team 
            playerList.ItemsSource = null;

            // Refreshes team list
            teamList.ItemsSource = null;
            teamList.ItemsSource = _teams;

            // Sort all teams because points are updated
            _teams.Sort();
        }

        /// <summary>
        /// Updates a player's record with a draw when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void draw_Click(object sender, RoutedEventArgs e)
        {
            // If none selected, default to doing nothing
            if (playerList.SelectedItem == null)
            {
                return;
            }

            // Gets the selected player, calls UpdateRecord() with appropriate char
            Player pl = (Player)playerList.SelectedItem;
            pl.UpdateRecord('D');

            // Refreshes player list but does not reassign the source back; this is necessary because this function deselects the team 
            playerList.ItemsSource = null;

            // Refreshes team list
            teamList.ItemsSource = null;
            teamList.ItemsSource = _teams;

            // Sort all teams because points are updated
            _teams.Sort();
        }

        /// <summary>
        /// Updates the star image whenever the selection in playerList is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If none selected, default to zero solid stars and return
            if(playerList.SelectedItem == null)
            {
                ImageUpdater(0);
                return;
            }

            // Calls ImageUpdater() with the selected player's score
            Player pl = (Player)playerList.SelectedItem;
            ImageUpdater(pl.ResultScore);
        }

        /// <summary>
        /// The function responsible for updating star images
        /// </summary>
        /// <param name="score">Score to evaluate against set limits</param>
        private void ImageUpdater(int score)
        {
            /* score = 0 or > 15; no solid stars
             * 1 <= score <= 5; one solid star
             * 6 <= score <= 10; two solid stars
             * 11 <= score <= 15; three solid stars
             */
            if(score == 0 || score > 15)
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
