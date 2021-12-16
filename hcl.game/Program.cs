using hcl.game.Enums;
using hcl.game.Model;
using hcl.game.Services;
using System;
using Unity;

namespace hcl.game
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = new UnityContainer();
                container.RegisterType<IGameService, GameService>();
                container.RegisterType<ISessionService, SessionService>();

                var player1TypeStr = "";
                PlayerType player1Type = PlayerType.Unknown;
                Console.WriteLine("Please enter player 1 type  in word e.g Human or Computer ");
                player1Type = GetPlayerType(player1TypeStr);

                var player2TypeStr = "";
                PlayerType player2Type = PlayerType.Unknown;
                Console.WriteLine("Please enter player 2 type  in word e.g Human or Computer ");
                player2Type = GetPlayerType(player2TypeStr);

                var session = new Session { };

                var player1 = new Player
                {
                    Name = "John",
                    Id = 1,
                    PlayerType = player1Type
                };

                var player2 = new Player
                {
                    Id = 2,
                    Name = "Caleb",
                    PlayerType = player2Type
                };

                var gameService = container.Resolve<GameService>();
                var sessionService = container.Resolve<SessionService>();

                int count = 0;

                while (count < 3)
                {
                    var humanSelection = "";
                    SelectionType selection = SelectionType.Unknown;

                    if (player1.PlayerType == Enums.PlayerType.Human)
                    {
                        Console.WriteLine("Please enter player 1 selection in word e.g Rock,Paper, Scissors");
                        selection = GetHumanSelection(humanSelection);
                        player1.CurrentSelection = selection;
                    }

                    if (player2.PlayerType == Enums.PlayerType.Human)
                    {
                        Console.WriteLine("Please enter player 2 selection in word e.g Rock,Paper, Scissors");
                        selection = GetHumanSelection(humanSelection);
                        player2.CurrentSelection = selection;
                    }

                    var game = gameService.PlayGame(player1, player2);

                    if (game.GameWinnner != null)
                    {
                        session.Games.Add(game);
                        count = count + 1;
                    }
                }

                var sessionOverallWinner = sessionService.DetermineSessionWinner(session).SessionOverallWinner;
                Console.WriteLine($"{sessionOverallWinner.Name} is the session Overall Winner and press any key to terminate");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                //log exception here
                Console.WriteLine("Error Happend and press any key to terminate");
                Console.ReadLine();
            }
        }

        private static PlayerType GetPlayerType(string input)
        {
            input = Console.ReadLine();
            PlayerType playerType = (PlayerType)Enum.Parse(typeof(PlayerType), input);
            return playerType;
        }

        private static SelectionType GetHumanSelection(string input)
        {
            input = Console.ReadLine();
            SelectionType selection = (SelectionType)Enum.Parse(typeof(SelectionType), input);
            return selection;
        }
    }
}
