using hcl.game.Model;
using hcl.game.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hcl.game.Test
{
    [TestClass]
    public class SessionServiceTest
    {
        SessionService sessionService;

        [TestInitialize]
        public void Setup()
        {
            sessionService = new SessionService { };
      
        }

        [TestMethod]
        public void SessionService_WhenGamePlayed_DetermineSessionWinner()
        {
            var session = new Session
            {
                Games = new System.Collections.Generic.List<Game>
                {
                    new Game
                    {
                        Player1 = new Player
                        {
                            CurrentSelection = Enums.SelectionType.Rock,
                         PlayerType= Enums.PlayerType.Computer,
                         Name="John",
                         Id=1
                        },
                     Player2 = new Player
                     {
                         CurrentSelection = Enums.SelectionType.Scissors,
                         PlayerType= Enums.PlayerType.Computer,
                         Name="Caleb",
                         Id=2


                     },
                      GameWinnner =  new Player
                        {
                            CurrentSelection = Enums.SelectionType.Rock,
                         PlayerType= Enums.PlayerType.Computer,
                         Name="John",
                         Id=1
                        }

                    },
                   new Game
                    {
                        Player1 = new Player
                        {
                            CurrentSelection = Enums.SelectionType.Scissors,
                         PlayerType= Enums.PlayerType.Computer,
                         Name="John",
                         Id=1
                        },
                     Player2 = new Player
                     {
                         CurrentSelection = Enums.SelectionType.Paper,
                         PlayerType= Enums.PlayerType.Computer,
                         Name="Caleb",
                         Id=2
                     },
                      GameWinnner =  new Player
                        {
                            CurrentSelection = Enums.SelectionType.Rock,
                         PlayerType= Enums.PlayerType.Computer,
                         Name="John",
                         Id=1
                        }
                    },new Game
                    {
                        Player1 = new Player
                        {
                            CurrentSelection = Enums.SelectionType.Paper,
                         PlayerType= Enums.PlayerType.Computer,
                         Name="John",
                         Id=1
                        },
                     Player2 = new Player
                     {
                         CurrentSelection = Enums.SelectionType.Rock,
                         PlayerType= Enums.PlayerType.Computer,
                         Name="Caleb",
                         Id=2
                     },
                      GameWinnner =new Player
                     {
                         CurrentSelection = Enums.SelectionType.Rock,
                         PlayerType= Enums.PlayerType.Computer,
                         Name="Caleb",
                         Id=2
                     }
                    },
                }
            };

            var sessionOverallWinner = sessionService.DetermineSessionWinner(session).SessionOverallWinner;

            Assert.AreEqual(sessionOverallWinner.Id, 1);
        }
    }
}
