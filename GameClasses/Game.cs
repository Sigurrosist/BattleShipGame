using System;
using System.Collections.Generic;
using System.Text;

namespace GameClasses
{
    public class Game
    {
        User user1;
        User user2;

        List<string> history_user1;
        List<string> history_user2;

        int userScore_1;
        int userScore_2;

        public Game()
        {
            this.User1 = new User();
            this.User2 = new User();
            history_user1 = new List<string>();
            history_user2 = new List<string>();
            userScore_1 = 0;
            userScore_2 = 0;
        }

        public User User1 { get => user1; set => user1 = value; }
        public User User2 { get => user2; set => user2 = value; }

        public void Start()
        {
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("* * * * * * * * * * * * *BattleShip Game Challenge* * * * * * * * * * * * * * *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("\n\n\n\n\n                                                           Press Enter To Start");
            Console.ReadLine();
        }

        public void RegisterUser1()
        {
            Console.WriteLine("Please enter the first user name :");
            string user1name = Console.ReadLine();

            User1.Name = user1name;
        }

        public void RegisterUser2()
        {
            Console.WriteLine("Please enter the second user name :");
            string user2name = Console.ReadLine();

            User2.Name = user2name;
        }

        public void PlaceBattleShipsForUser1()
        {
            string successString = "Your battleship is successfully located";
            string resultString = "";

            // show the gameboard to user so they can choose the battleship location from.
            Console.WriteLine(user1.UserBoard.PrintGameboard());
            Console.WriteLine(user1.Name + ", Please select your battleship head location. (Ex : C4)");
            string user1loc = Console.ReadLine();
            Console.WriteLine(user1.Name + ", Do you want to place it vertically? Enter y to place vertically, n to place horizontally.");
            string user1dir = Console.ReadLine();
            bool user1direction = user1dir == "y" ? true : false;
            resultString = user1.UserBoard.BattleShip.SetBattleShipLocation(user1loc, user1direction);
            while(resultString != successString)
            {
                Console.WriteLine(resultString);
                Console.WriteLine(user1.Name + ", Please select your battleship head location. (Ex : C4)");
                user1loc = Console.ReadLine();
                Console.WriteLine(user1.Name + ", Do you want to place it vertically? Enter y to place vertically, n to place horizontally.");
                user1dir = Console.ReadLine();
                user1direction = user1dir == "y" ? true : false;
                resultString = user1.UserBoard.BattleShip.SetBattleShipLocation(user1loc, user1direction);
            }
            user1.UserBoard.PlaceBattleShip();
            Console.Clear();
            Console.WriteLine("This is your current location");
            user1.UserBoard.PrintGameboard();
            Console.WriteLine("\n\n\n------------ Thanks, " + user1.Name + "! Please press enter to place " + user2.Name + "'s battleship.");
            Console.ReadLine();
        }

        public void PlaceBattleShipsForUser2()
        {
            string successString = "Your battleship is successfully located";
            string resultString = "";

            // show the gameboard to user so they can choose the battleship location from.
            Console.WriteLine(user2.UserBoard.PrintGameboard());
            Console.WriteLine(user2.Name + ", Please select your battleship head location. (Ex : C4)");
            string user1loc = Console.ReadLine();
            Console.WriteLine(user2.Name + ", Do you want to place it vertically? Enter y to place vertically, n to place horizontally.");
            string user1dir = Console.ReadLine();
            bool user1direction = user1dir == "y" ? true : false;
            resultString = user2.UserBoard.BattleShip.SetBattleShipLocation(user1loc, user1direction);
            while (resultString != successString)
            {
                Console.WriteLine(resultString);

                Console.WriteLine(user2.Name + ", Please select your battleship head location. (Ex : C4)");
                user1loc = Console.ReadLine();
                Console.WriteLine(user2.Name + ", Do you want to place it vertically? Enter y to place vertically, n to place horizontally.");
                user1dir = Console.ReadLine();
                user1direction = user1dir == "y" ? true : false;
                resultString = user2.UserBoard.BattleShip.SetBattleShipLocation(user1loc, user1direction);
            }
            user2.UserBoard.PlaceBattleShip();
            Console.Clear();
            Console.WriteLine("This is your current location");
            user2.UserBoard.PrintGameboard();
            Console.WriteLine("\n\n\n------------ Thanks, " + user2.Name + "! Please enter to start the game!");
            Console.ReadLine();
        }

        private bool isThisAttackAlreadyTried(int usernum, string loc)
        {
            bool alreadyTried = false;
            if (usernum == 1)
            {
                alreadyTried = history_user1.Exists(x => x == loc);
            }
            else
            {
                alreadyTried = history_user2.Exists(x => x == loc);
            }

            return alreadyTried;
        }

        private bool isGameFinished(int usernum)
        {
            if(usernum == 1)
            {
                if (userScore_1 > 2) return true;
            }
            else
            {
                if (userScore_2 > 2) return true;
            }
            return false;
        }

        private void printWinnerMsg(int usernum)
        {
            string username = usernum == 1 ? user1.Name : user2.Name;

            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine(username + " won the game! Congrats!");
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("To quit the game, please press enter.");
            Console.ReadLine();
        }
        public bool User1PlayRound()
        {
            user2.UserBoard.PrintGameboardForEnemy();
            // User 1 attack
            Console.WriteLine(user1.Name + ", Please enter the location name (ex : A4) ");
            string attack = Console.ReadLine();
            while(isThisAttackAlreadyTried(1, attack))
            {
                Console.WriteLine(user1.Name + ", you already have tried this attack. Please try other location name ");
                attack = Console.ReadLine();
            }
            history_user1.Add(attack);
            if (user2.UserBoard.IsValidAttack(attack))
            {
                userScore_1++;
                Console.WriteLine("You obtained 1 score! Your current score is " + userScore_1);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Uh-oh, you aimed a wrong location!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            if(isGameFinished(1))
            {
                Console.WriteLine(user1.Name + ", You scored 3 times and you won!");
                Console.WriteLine("This is " + user2.Name + "'s battleship location.");
                user2.UserBoard.PrintGameboard();
                printWinnerMsg(1);
                return isGameFinished(1);
            }
            return false;
        }

        public bool User2PlayRound()
        {
            user1.UserBoard.PrintGameboardForEnemy();
            // User 2 attack
            Console.WriteLine(user2.Name + ", Please enter the location name (ex : A4) ");
            string attack = Console.ReadLine();
            while (isThisAttackAlreadyTried(1, attack))
            {
                Console.WriteLine(user2.Name + ", you already have tried this attack. Please try other location name ");
                attack = Console.ReadLine();
            }
            history_user2.Add(attack);
            if (user1.UserBoard.IsValidAttack(attack))
            {
                userScore_2++;
                Console.WriteLine("You obtained 1 score! Your current score is " + userScore_2);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Uh-oh, you aimed a wrong location!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            if (isGameFinished(2))
            {
                Console.WriteLine(user2.Name + ", You scored 3 times and you won!");
                Console.WriteLine("This is " + user1.Name + "'s battleship location.");
                user1.UserBoard.PrintGameboard();
                printWinnerMsg(2);
                return isGameFinished(2);
            }
            return false;
        }

    }
}
