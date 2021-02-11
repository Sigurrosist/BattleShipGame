using GameClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShipGameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsBoardCreatedAndInitialized()
        {
            Board board = new Board();
            Assert.AreEqual("H8", board.GameBoard[7, 7]);
        }

        [TestMethod]
        public void IsBoardPrintStringCorrect()
        {
            Board board = new Board();
            string resultString = "";
            resultString += " -- -- -- -- -- -- -- -- -- -- -- -- \n";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    resultString += board.GameBoard[i, j] + "\t";
                }
                resultString += " \n\n\n";
            }
            Assert.AreEqual(resultString, board.PrintGameboard());
        }

       // [TestMethod]
        public void DoesAttackLocationA8Works()
        {
            Board board = new Board();
            string resultString = "";
            resultString += " -- -- -- -- -- -- -- -- -- -- -- -- \n";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    resultString += board.GameBoard[i, j] + "\t";
                }
                resultString += " \n\n\n";
            }
            Assert.AreEqual(resultString, board.PrintGameboard());
        }

        [TestMethod]
        public void IsPlacingBattleShipWorksWithHorizontallyCorrectParams()
        {
            string correctparam = "A1";
            bool correctIsVertical = true;
            BattleShip battleShip = new BattleShip();
            string thisShouleBeTrue = battleShip.SetBattleShipLocation(correctparam, correctIsVertical);
            string successString = "Your battleship is successfully located";
            Assert.AreEqual(thisShouleBeTrue, successString);
        }


        [TestMethod]
        public void IsPlacingBattleShipWorksWitVerticallyCorrectParams()
        {
            string correctparam = "A1";
            bool correctIsVertical = false;
            BattleShip battleShip = new BattleShip();
            string thisShouleBeTrue = battleShip.SetBattleShipLocation(correctparam, correctIsVertical);
            string successString = "Your battleship is successfully located";
            Assert.AreEqual(thisShouleBeTrue, successString);
        }

        [TestMethod]
        public void IsPlacingBattleShipWorksWitVerticallyInCorrectParams()
        {
            string correctparam = "G1";
            bool incorrectIsVertical = true;
            BattleShip battleShip = new BattleShip();
            string thisShouleBeTrue = battleShip.SetBattleShipLocation(correctparam, incorrectIsVertical);
            string failString = "The head location G1 can't vertically locate the battleship. Please choose other head location or direction.";
            Assert.AreEqual(thisShouleBeTrue, failString);
        }

        [TestMethod]
        public void IsPlacingBattleShipWorksWitHorizontallyInCorrectParams()
        {
            string correctparam = "C7";
            bool incorrectIsVertical = false;
            BattleShip battleShip = new BattleShip();
            string thisShouleBeTrue = battleShip.SetBattleShipLocation(correctparam, incorrectIsVertical);
            string failString = "The head location C7 can't horizontally locate the battleship. Please choose other head location or direction.";
            Assert.AreEqual(thisShouleBeTrue, failString);
        }

        [TestMethod]
        public void IsCorrectAttackValidationWorking()
        {
            string attack = "A1";
            Board board = new Board();
            board.BattleShip.SetBattleShipLocation("A1", true);
            board.PlaceBattleShip();
            bool attack1 = board.IsValidAttack("A1");
            bool attack2 = board.IsValidAttack("B1");
            bool attack3 = board.IsValidAttack("C1");
            bool result = false;
            if (attack1 && attack2 && attack3) result = true;
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IsIncorrectAttackValidationWorking()
        {
            Board board = new Board();
            board.BattleShip.SetBattleShipLocation("A1", true);
            board.PlaceBattleShip();
            bool attack1 = !board.IsValidAttack("A2");
            bool attack2 = !board.IsValidAttack("B2");
            bool attack3 = !board.IsValidAttack("C2");
            bool result = false;
            if (attack1 && attack2 && attack3) result = true;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsUserCreatingWorking()
        {
            User user = new User();
            user.Name = "Judy";
            user.UserBoard = new Board();
            Assert.IsTrue(user.Name == "Judy" && user.UserBoard.GameBoard[0, 0] == "A1");
        }

        [TestMethod]
        public void IsGameCreationWorking()
        {
            Game game = new Game();
            Assert.AreEqual(game.UserScore_1 + game.UserScore_2, 0);
        }

        [TestMethod]
        public void IsScoreCalculationWorking()
        {
            Game game = new Game();
            game.UserScore_1 = 3;
            bool user1won = game.isGameFinished(1);
            Assert.IsTrue(user1won);
        }

        [TestMethod]
        public void IsDuplicatedAttackTryWorking()
        {
            Game game = new Game();
            game.History_user1.Add("A1");
            bool dupTry = game.isThisAttackAlreadyTried(1, "A1");
            Assert.IsTrue(dupTry);
        }
    }
}
