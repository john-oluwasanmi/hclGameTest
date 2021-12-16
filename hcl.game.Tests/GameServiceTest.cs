using hcl.game.Model;
using hcl.game.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hcl.game.Test
{
    [TestClass]
    public class GameServiceTest
    {
        GameService gameService;

          [TestInitialize]
        public void Setup()
        {
              gameService = new GameService { };
        }

        [TestMethod]
        public void GameService_WhenGamePlayed_DetermineGameWinner()
        {
            var game = new Game
            {
                Player1 = new Player
                {
                    CurrentSelection = Enums.SelectionType.Scissors,
                    PlayerType = Enums.PlayerType.Computer,
                    Name = "John",
                    Id = 1
                },
                Player2 = new Player
                {
                    CurrentSelection = Enums.SelectionType.Paper,
                    PlayerType = Enums.PlayerType.Computer,
                    Name = "Caleb",
                    Id = 2
                }
            };

            var gameWinnner = gameService.DetermineGameWinner(game).GameWinnner;
            Assert.AreEqual(gameWinnner.Id, 1);
        }
    }
}
