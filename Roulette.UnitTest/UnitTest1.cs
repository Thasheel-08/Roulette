using NUnit.Framework;
using Roulette.Models.Bets;
using Roulette.Models.Player;

namespace Roulette.UnitTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Bet_Contains_NoCurrent_Payout()
        {
            //Arrange 
            Player customerBet = new Player() { Red = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { Red = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual(200, returnValues.totalPayout);
        }

        [Test]
        public void Bet_Contains_OtherPayout()
        {
            //Arrange 
            Player customerBet = new Player() { Red = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { Red = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 100);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual(300, returnValues.totalPayout);
        }
        [Test]
        public void Bet_Contains_Red()
        {
            //Arrange 
            Player customerBet = new Player() { Red = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { Red = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("Red", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_Black()
        {
            //Arrange 
            Player customerBet = new Player() { Black = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { Black = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("Black", returnValues.BetType);
        }

        [Test]
        public void Bet_Contains_No_Match()
        {
            //Arrange 
            Player customerBet = new Player() { Black = 1, Red = 1, BetAmount = 100, Number = 1 };
            PlayerBet betResult = new PlayerBet { Red = 0, Black = 0, Number = 2 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 100);


            //Assert
            Assert.AreEqual("not a winning gamble", returnValues.BetType);
            Assert.AreEqual(0, returnValues.winnings);
            Assert.AreEqual(100, returnValues.totalPayout);
        }
        [Test]
        public void Bet_Contains_Even_Number()
        {
            //Arrange 
            Player customerBet = new Player() { Even = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { Even = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("Even", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_Odd_Number()
        {
            //Arrange 
            Player customerBet = new Player() { Odd = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { Odd = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("Odd", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_Number_In_FirstHalf()
        {
            //Arrange 
            Player customerBet = new Player() { FirstHalf = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { FirstHalf = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("1-18", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_Number_In_SecondHalf()
        {
            //Arrange 
            Player customerBet = new Player() { SecondHalf = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { SecondHalf = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("19-36", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_First12()
        {
            //Arrange 
            Player customerBet = new Player() { FirstTwelve = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { FirstTwelve = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("First12", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_Second12()
        {
            //Arrange 
            Player customerBet = new Player() { SecondTwelve = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { SecondTwelve = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("Second12", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_Third12()
        {
            //Arrange 
            Player customerBet = new Player() { ThirdTwelve = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { ThirdTwelve = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("Third12", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_First2to1()
        {
            //Arrange 
            Player customerBet = new Player() { FirstTwotoOne = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { FirstTwotoOne = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("1st 2-1", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_Second2to1()
        {
            //Arrange 
            Player customerBet = new Player() { SecondTwotoOne = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { SecondTwotoOne = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("2nd 2-1", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_Third2to1()
        {
            //Arrange 
            Player customerBet = new Player() { ThirdTwotoOne = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { ThirdTwotoOne = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, returnValues.winnings);
            Assert.AreEqual("3rd 2-1", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_FullNumber()
        {
            //Arrange 
            Player customerBet = new Player() { Number = 1, NumberFull = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { Number = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(3500, returnValues.winnings);
            Assert.AreEqual("Number", returnValues.BetType);
        }
        [Test]
        public void Bet_Contains_SplitNumber()
        {
            //Arrange 
            Player customerBet = new Player() { Number = 1, NumberSplit = 1, BetAmount = 100 };
            PlayerBet betResult = new PlayerBet { Number = 1 };

            //Act
            var returnValues = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(1700, returnValues.winnings);
            Assert.AreEqual("Number", returnValues.BetType);
        }
    }
}