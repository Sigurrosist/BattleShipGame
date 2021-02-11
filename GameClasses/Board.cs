using System;
using System.Collections.Generic;
using System.Text;

namespace GameClasses
{
    public class Board
    {
        string[,] gameBoard;
        BattleShip battleShip;

        public Board()
        {
            this.GameBoard = new string[8, 8];
            int vertical = 65;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string boardContentString = ((char)vertical).ToString();
                    boardContentString += (j + 1).ToString();

                    this.GameBoard[i, j] = boardContentString;
                }
                vertical++;
            }
            battleShip = new BattleShip();
        }

        public string[,] GameBoard { get => gameBoard; set => gameBoard = value; }
        public BattleShip BattleShip { get => battleShip; set => battleShip = value; }

        public string PrintGameboardForEnemy()
        {
            Board nboard = new Board();
            string returnString = "";
            returnString += "** SELECT 1 LOCATION TO SHOOT **\n";
            returnString += " -- -- -- -- -- -- -- -- -- -- -- -- \n";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    returnString += nboard.GameBoard[i, j] + "\t";
                }
                returnString += " \n\n\n";
            }
            Console.WriteLine(returnString);
            return returnString;
        }

        public string PrintGameboard()
        {
            string returnString = "";
            returnString += " -- -- -- -- -- -- -- -- -- -- -- -- \n";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    returnString += this.GameBoard[i, j] + "\t";
                }
                returnString += " \n\n\n";
            }

            Console.WriteLine(returnString);
            return returnString;
        }

        public string PlaceBattleShip()
        {
            string returnString = "";
            returnString += "** YOUR GAME BOARD **\n";
            returnString += " -- -- -- -- -- -- -- -- -- -- -- -- \n";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string loc = this.GameBoard[i, j];
                    foreach (string bLoc in battleShip.Location)
                    {
                        if (bLoc == loc)
                        {
                            loc = "**";
                        }
                        this.GameBoard[i, j] = loc;
                    }

                    returnString += loc + "\t";
                }
                returnString += " \n\n\n";
            }

            return returnString;
        }

        public bool IsValidAttack(string loc)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this.gameBoard[i, j] == loc)
                        return false;
                }
            }
            return true;
        }
    }
}
