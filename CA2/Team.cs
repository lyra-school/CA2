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
        private string _name;
        private List<Player> _players = new List<Player>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Player> Players
        {
            get { return _players; }
        }

        public int PlayerPoints
        {
            get
            {
                return PlayerPointCalc();
            }
        }

        public Team(string name)
        {
            _name = name;
        }

        public Team()
        {

        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        private int PlayerPointCalc()
        {
            int sum = 0;
            foreach (Player player in _players)
            {
                sum += player.ResultScore;
            }
            return sum;
        }

        public override string ToString()
        {
            return $"{Name} - {PlayerPoints}";
        }

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
