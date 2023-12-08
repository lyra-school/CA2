using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public class Team
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

        public override string ToString()
        {
            return $"{Name} - ";
        }
    }
}
