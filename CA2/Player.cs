using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public class Player
    {
        private string _name;
        private string _resultRecord;

        public string Name
        {
            get { return _name; }
            set{ _name = value; }
        }

        public string ResultRecord
        {
            get { return _resultRecord; }
            set { _resultRecord = value; }
        }

        public int ResultScore
        {
            get
            {
                return CalculateScore();
            }
        }

        public Player(string name, string resultRecord)
        {
            _name = name;
            _resultRecord = resultRecord;
        }

        public Player()
        {

        }

        public override string ToString()
        {
            return $"{Name} - {ResultRecord} - {ResultScore}";
        }

        public void UpdateRecord(char result)
        {
            _resultRecord = _resultRecord.Substring(1);
            char validCase = char.ToUpper(result);
            if (validCase == 'W' || validCase == 'D' || validCase == 'L')
            {
                _resultRecord += validCase;
            }
        }

        private int CalculateScore()
        {
            int score = 0;
            int count = _resultRecord.Length;
            string valid = _resultRecord.Substring(count - 5, 5);
            foreach(char c in valid)
            {
                if(c == 'W')
                {
                    score += 3;
                } else if(c == 'D')
                {
                    score += 1;
                }
            }
            return score;
        }
    }
}
