using hcl.game.Enums;
using hcl.game.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace hcl.game.Services
{
    public class GameService : IGameService
    {
        public Game DetermineGameWinner(Game game)
        {
            if (game.Player1.CurrentSelection == SelectionType.Rock && game.Player2.CurrentSelection == SelectionType.Scissors)
            {
                game.GameWinnner = game.Player1;
            }
            else if (game.Player2.CurrentSelection == SelectionType.Rock && game.Player1.CurrentSelection == SelectionType.Scissors)
            {
                game.GameWinnner = game.Player2;
            }

            else if (game.Player1.CurrentSelection == SelectionType.Scissors && game.Player2.CurrentSelection == SelectionType.Paper)
            {
                game.GameWinnner = game.Player1;
            }
            else if (game.Player2.CurrentSelection == SelectionType.Scissors && game.Player1.CurrentSelection == SelectionType.Paper)
            {
                game.GameWinnner = game.Player2;
            }

            else if (game.Player1.CurrentSelection == SelectionType.Paper && game.Player2.CurrentSelection == SelectionType.Rock)
            {
                game.GameWinnner = game.Player1;
            }

            else if (game.Player2.CurrentSelection == SelectionType.Paper && game.Player1.CurrentSelection == SelectionType.Rock)
            {
                game.GameWinnner = game.Player2;
            }

            return game;
        }

        public Game PlayGame(Player player1, Player player2)
        {
            var game = new Game
            {
                Player1 = player1,
                Player2 = player2
            };

            if (player1.PlayerType == PlayerType.Computer)
            {
                GetRandomSelection(player1);
            }

            if (player2.PlayerType == PlayerType.Computer)
            {
                GetRandomSelection(player2);
            }

            if (player2.PlayerType != PlayerType.Computer && player2.CurrentSelection == SelectionType.Unknown)
            {
                throw new InvalidOperationException("invalid selection type");
            }

            if (player1.PlayerType != PlayerType.Computer && player1.CurrentSelection == SelectionType.Unknown)
            {
                throw new InvalidOperationException("invalid selection type");
            }

            DetermineGameWinner(game);

            return game;
        }

        public void GetRandomSelection(Player player)
        {
            var selections = Enum.GetValues(typeof(SelectionType));
            Random random = new Random();

            SelectionType randomselection = (SelectionType)selections.GetValue(random.Next(selections.Length));

            while (randomselection == SelectionType.Unknown)
            {
                randomselection = (SelectionType)selections.GetValue(random.Next(selections.Length));
            }

            player.CurrentSelection = randomselection;
            player.Selections.Add(randomselection);
        }
    }
}
