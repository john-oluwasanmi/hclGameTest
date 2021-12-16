using hcl.game.Model;

namespace hcl.game.Services
{
    public interface ISessionService
    {
        Session DetermineSessionWinner(Session session);
    }
}