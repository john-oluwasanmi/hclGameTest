using hcl.game.Model;

namespace hcl.game.Services
{
    public interface IGameService
    {
        Game DetermineGameWinner(Game game);
        Game PlayGame(Player player1, Player player2);
        void GetRandomSelection(Player player);
    }
}