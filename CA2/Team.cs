using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public class Team : IComparable<Team>
    {
        // Name & player list attributes; the list is made every time the object is initialized
        private string _name;
        private List<Player> _players = new List<Player>();

        // Getters and setters for name & player list, respectively
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Player> Players
        {
            get { return _players; }
        }

        // Calculated property; gets total of all player points in the team
        public int PlayerPoints
        {
            get
            {
                return PlayerPointCalc();
            }
        }

        // Constructor
        public Team()
        {

        }

        /// <summary>
        /// Adds a player to the team
        /// </summary>
        /// <param name="player">The player to add</param>
        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        /// <summary>
        /// Calculates total player points in a team
        /// </summary>
        /// <returns>Total player points as an integer</returns>
        private int PlayerPointCalc()
        {
            // Total defaults to 0
            int sum = 0;

            // Retrieves scores from players and sums them up
            foreach (Player player in _players)
            {
                sum += player.ResultScore;
            }

            return sum;
        }

        // String representation of a team, used for display in listboxes
        public override string ToString()
        {
            return $"{Name} - {PlayerPoints}";
        }

        /// <summary>
        /// Sorts by points (higher points = closer to the beginning of the list) and otherwise alphabetically by name
        /// </summary>
        /// <param name="other">The team to compare against</param>
        /// <returns>Returns an integer (-1, 1, 0) used in list sorting</returns>
        public int CompareTo(Team other)
        {
            if (this.PlayerPoints > other.PlayerPoints)
            {
                return -1;
            }
            else if(this.PlayerPoints < other.PlayerPoints)
            {
                return 1;
            } else
            {
                return this.Name.CompareTo(other.Name);
            }
        }
    }
}
