using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public class Player
    {
        // Name & record attributes
        private string _name;
        private string _resultRecord;

        // Setters/getters for name & record, respectively
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

        // Calculated property; returns the value of current records
        public int ResultScore
        {
            get
            {
                return CalculateScore();
            }
        }

        // Constructor
        public Player()
        {

        }

        // String representation of a Player, used for display in listboxes
        public override string ToString()
        {
            return $"{Name} - {ResultRecord} - {ResultScore}";
        }

        /// <summary>
        /// Updates the player's record based on given char
        /// </summary>
        /// <param name="result">Char representation of a win/loss/draw; W, D and L are only accepted values</param>
        public void UpdateRecord(char result)
        {
            // All records must use uppercase letters, so it updates the input accordingly
            char validCase = char.ToUpper(result);

            // Evaluates whether char is valid; adds it to the end of the record if yes, returns early if not
            if (validCase == 'W' || validCase == 'D' || validCase == 'L')
            {
                _resultRecord += validCase;
            } else
            {
                return;
            }

            // Cuts off the first character in the record string
            _resultRecord = _resultRecord.Substring(1); 
        }
        
        /// <summary>
        /// Calculates a player's total score
        /// </summary>
        /// <returns>A player's current total score as an integer</returns>
        private int CalculateScore()
        {
            // Default score is 0
            int score = 0;

            // Stores length of the record string
            int count = _resultRecord.Length;

            // Gets last 5 records of the record string
            string valid = _resultRecord.Substring(count - 5, 5);

            // Evaluates each letter in records; adds 3 if W for win, adds 1 if D for draw, does nothing otherwise
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
