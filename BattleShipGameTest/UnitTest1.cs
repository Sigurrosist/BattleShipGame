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
            resultString += "** YOUR GAME BOARD **\n";
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

    }
}
