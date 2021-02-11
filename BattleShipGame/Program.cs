using GameClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            Console.Clear();
            game.RegisterUser1();
            Console.Clear();
            game.RegisterUser2();
            Console.Clear();
            game.PlaceBattleShipsForUser1();
            Console.Clear();
            game.PlaceBattleShipsForUser2();
            Console.Clear();
            bool user1won = game.User1PlayRound();
            Console.Clear();
            bool user2won = game.User2PlayRound();
            Console.Clear();
            while (!user1won && !user2won)
            {
                user1won = game.User1PlayRound();
                Console.Clear();
                if (!user1won) user2won = game.User2PlayRound();
                Console.Clear();
            }
        }
    }
}
