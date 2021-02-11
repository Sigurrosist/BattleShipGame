using System;
using System.Collections.Generic;
using System.Text;

namespace GameClasses
{
    public class BattleShip
    {
        string[] location;

        /// <summary>
        /// each number that is assigned to the location means:
        /// 0 : created
        /// 1 : placed
        /// 2 : attacked
        /// </summary>
        public BattleShip()
        {
            location = new string[3] { "", "", "" };
        }

        public string[] Location { get => location; set => location = value; }

        public string SetBattleShipLocation(string head, bool isVertical)
        {
            string[] battleshipLocation = new string[3];
            if (!isVertical)
            {
                char head1 = head[0];
                int head2 = (int)Char.GetNumericValue(head[1]);                
                battleshipLocation[0] = head;
                battleshipLocation[1] = new StringBuilder().Append(head1).Append((head2 + 1).ToString()).ToString();
                battleshipLocation[2] = new StringBuilder().Append(head1).Append((head2 + 2).ToString()).ToString();

            }
            else
            {
                int head1 = (int)head[0];
                char head2 = head[1];
                battleshipLocation[0] = head;
                battleshipLocation[1] = new StringBuilder().Append((char)(head1 + 1)).Append(head2).ToString();
                battleshipLocation[2] = new StringBuilder().Append((char)(head1 + 2)).Append(head2).ToString();
            }
            char sampleLoc1 = battleshipLocation[0][0];
            char sampleLoc2 = battleshipLocation[0][1];
            
            foreach(string loc in battleshipLocation)
            {
                char[] loc_char_arr = loc.ToCharArray();
                if(sampleLoc1 == loc_char_arr[0] || sampleLoc2 == loc_char_arr[1])
                {
                    if (
                        (int)loc_char_arr[0] < 65 || // if the string starts with A ~ H
                        (int)loc_char_arr[0] > 72 || // (int value for char 'A' = 65, 'H' = 73)
                        Char.GetNumericValue(loc_char_arr[1]) < 1 || // if the string's last value is integer
                        Char.GetNumericValue(loc_char_arr[1]) > 8 // accepted integer range (1 ~ 8)
                        )
                    {
                        string direction = isVertical ? "vertically" : "horizontally";
                        string resultString = "The head location " + head + " can't " + direction + " locate the battleship. Please choose other head location or direction.";
                        return resultString;
                    }
                }
            }

            this.location = battleshipLocation;
            return "Your battleship is successfully located";
        }
    }
}
